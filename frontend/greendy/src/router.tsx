import { createBrowserRouter } from "react-router-dom";
import UnAuthorizedLayout from './components/layouts/UnAuthorizedLayout';
import App from './App';
import Login from "./views/auth/Login";
import AuthorizedLayout from "./components/layouts/AutorizedLayout";
import TaskStoragesList from "./views/tasksStorages/TaskStoragesList";

export const router = createBrowserRouter([
  {
    path: '/',
    element: <AuthorizedLayout/>,
    children: [
      {
        path: '',
        element: <App/>
      },
      {
        path: 'tasks',
        children: [
          {
            path: '',
            element: <TaskStoragesList />
          }
        ]
      }
    ]
  },
  {
    path: '/auth',
    element: <UnAuthorizedLayout/>,
    children: [
      {
        path: '',
        element: <Login/>
      }
    ]
  }
])