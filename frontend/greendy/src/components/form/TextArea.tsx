type Props = {
	label?: string,
	onInput: React.FormEventHandler<HTMLTextAreaElement>  
};

function TextArea(props: Props) {
	return (
		<div className="my-2">
			{props.label != null ? (<label className="block">{props.label}</label>) : (<></>)}
			<textarea className="font-medium bg-white border-gray-300 block p-1 text-md rounded-lg border hover:bg-gray-50" onInput={props.onInput} > 
			</textarea>
		</div>
	);
}

export default TextArea;