import { useState } from "react";
import Input from "../../components/form/Input";
import TextArea from "../../components/form/TextArea";

type Props = {
  onSetShowModal: (showModal: boolean) => void;
}

function CreateTrackItemModal(props: Props) {
    const [name, setName] = useState<string>();
    const [description, setDescription] = useState<string>();

    return (
      <>
        <div
          className="justify-center items-center flex overflow-x-hidden overflow-y-auto fixed inset-0 z-50 outline-none focus:outline-none"
        >
        <div className="relative w-2/4 my-6 mx-auto max-w-3xl">
            <div className="border-0 rounded-lg shadow-lg relative flex flex-col w-full bg-white outline-none focus:outline-none">
            <div className="flex items-start justify-between p-5 border-b border-solid border-slate-200 rounded-t">
                <h3 className="text-3xl font-semibold">
                    Create new item
                </h3>
            </div>
            <div className="relative p-6 flex-auto">
              <form className="flex flex-row">
                <div>
                    <Input value={name} onInput={(event) => setName((event.target as HTMLInputElement).value)} label="Name"/>
                    <TextArea onInput={(event) => setDescription((event.target as HTMLTextAreaElement).value)} label="Description" />
                </div>
                <div>
                     
                </div>
              </form>
            </div>
            <div className="flex items-center justify-end p-6 border-t border-solid border-slate-200 rounded-b">
                <button
                  className="text-red-500 background-transparent font-bold uppercase px-6 py-2 text-sm outline-none focus:outline-none mr-1 mb-1 ease-linear transition-all duration-150"
                  type="button"
                  onClick={() => props.onSetShowModal(false)}
                >
                Close
                </button>
                <button
                  className="bg-emerald-500 text-white active:bg-emerald-600 font-bold uppercase text-sm px-6 py-3 rounded shadow hover:shadow-lg outline-none focus:outline-none mr-1 mb-1 ease-linear transition-all duration-150"
                  type="button"
                  onClick={() => false}
                >
                    Save
                </button>
            </div>
            </div>
        </div>
        </div>
        <div className="opacity-25 fixed inset-0 z-40 bg-black"></div>
      </>
    )
}

export default CreateTrackItemModal;