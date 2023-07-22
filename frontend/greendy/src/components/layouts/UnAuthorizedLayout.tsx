import { Navigate, Outlet } from "react-router-dom";

function UnAuthorizedLayout() {
  const token = localStorage.getItem('token');
  return (
    <>
    {token == null ? 
      <div className="w-full h-screen bg-primary">
        <Outlet />
      </div> : 
      <Navigate to={'/'} />}
    </>
  )
}

export default UnAuthorizedLayout;