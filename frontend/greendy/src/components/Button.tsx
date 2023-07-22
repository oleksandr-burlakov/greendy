interface ButtonProps {
  text: string,
  color: "primary" | "secondary" | "black" | "white",
  addClass?: string
}

function Button(props: ButtonProps) {

  let classList = "mt-4 px-4 py-1 rounded-md";
  let color = "bg-white";
  if (props.color == 'primary') {
    color = 'bg-primary'
  }

  return (
    <>
      <button className={classList + ' ' + color + ' ' + props.addClass}>{props.text}</button>
    </>
  )
}

export default Button;