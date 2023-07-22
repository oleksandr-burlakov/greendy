import { useState } from "react";
import Input from "../../components/form/Input";
import TextArea from "../../components/form/TextArea";
import { client } from "../../services/axiosService";

type Props = {
  onSetShowModal: (showModal: boolean) => void;
  onTaskStorageAdd: (id: string, name: string) => void;
}

function CreateTaskStorageModal(props: Props) {
    const [name, setName] = useState<string>();
    const [description, setDescription] = useState<string>();

    const createNewTaskStorage = () => {
      client.post('TrackStorage/create', {
        name: name,
        description: description
      })
      .then(data => {
        props.onTaskStorageAdd(data.data as string, name as string);
        props.onSetShowModal(false);
      })
      .catch(error => {
        props.onSetShowModal(false);
      })
    };

    return (
      <>
        <div
          className="justify-center items-center flex overflow-x-hidden overflow-y-auto fixed inset-0 z-50 outline-none focus:outline-none"
        >
        <div className="relative w-auto my-6 mx-auto max-w-3xl">
            <div className="border-0 rounded-lg shadow-lg relative flex flex-col w-full bg-white outline-none focus:outline-none">
            <div className="flex items-start justify-between p-5 border-b border-solid border-slate-200 rounded-t">
                <h3 className="text-3xl font-semibold">
                  Add new board
                </h3>
            </div>
            <div className="relative p-6 flex-auto">
              <form>
                <Input value={name} onInput={(event) => setName((event.target as HTMLInputElement).value)} label="Name"/>
                <TextArea onInput={(event) => setDescription((event.target as HTMLTextAreaElement).value)} label="Description" />
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
                  onClick={() => createNewTaskStorage()}
                >
                Save Changes
                </button>
            </div>
            </div>
        </div>
        </div>
        <div className="opacity-25 fixed inset-0 z-40 bg-black"></div>
      </>
    )
}

export default CreateTaskStorageModal;