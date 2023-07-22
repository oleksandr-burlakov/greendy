import { useState } from "react";
import Button from "../../components/Button";
import Input from "../../components/form/Input";
import { client, useAuthStore } from "../../services/axiosService";
import { useNavigate } from "react-router-dom";

function Login() {
  const [login, setLogin] = useState('');
  const [password, setPassword] = useState('');
  const authStore = useAuthStore();
  const navigate = useNavigate();

  const submitForm = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    client.post('Account/login', {
      login: login,
      password: password
    })
      .then(res => {
        localStorage.setItem('token', res.data.token as string);
        authStore.setToken(res.data.token as string);
        navigate('/');
      })
      .catch(e => console.error(e));
    return false;
  };

  return (
    <div className="flex h-full">
      <div className="w-10/12 bg-white h-full">
        <div className="grid h-full place-items-center">
          <form onSubmit={submitForm}>
            <div className="my-2">
              <Input label="Login" value={login} onInput={e => setLogin((e.target as HTMLInputElement).value)}/>
            </div>
            <div className="my-2">
              <Input label="Password" value={password} type="password" onInput={e => setPassword((e.target as HTMLInputElement).value)} />
            </div>
            <div className="w-full flex justify-center">
              <Button text="Sign-in" color="primary" addClass="w-full text-white font-medium"/>
            </div>
          </form>
        </div>
      </div>
      <div className="w-2/12">
        <div className="h-full flex justify-center flex-col p-5">
          <h2 className="text-3xl font-bold text-center mb-4">New Here?</h2>
          <h4>Sign up and discover great ammount of opportunities!</h4>
          <Button text="Sign up" color="white"/>
        </div>
      </div>
    </div>
  )
}

export default Login;