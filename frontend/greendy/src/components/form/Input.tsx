interface InputProps {
  label?: string,
  type?: "text" | "password",
  onInput: React.FormEventHandler<HTMLInputElement>,
  value?: string
}

function Input(props: InputProps) {
  return (
    <>
      {props.label != null ? (<label className="block">{props.label}</label>) : (<></>)}
      <input value={props.value ?? ''} type={props.type ?? 'text'} className="font-medium bg-white border-gray-300 block p-1 text-md rounded-lg border hover:bg-gray-50" onInput={props.onInput} /> 
    </>
  );
}

export default Input;