import { Link, Outlet, useNavigate } from "react-router-dom";
import { FaArrowRightFromBracket, FaHouse, FaListCheck, FaRegStar, FaUser } from 'react-icons/fa6';
import { useEffect } from "react";
import 'react-confirm-alert/src/react-confirm-alert.css'; // Import css
import { useAuthStore } from "../../services/axiosService";

function AuthorizedLayout() {
  const navigate = useNavigate();
  const token = useAuthStore((state) => state.token);

  useEffect(() => {
    if (token === null || token === '') {
      navigate('/auth');
    }
  }, [token]);
  return (
    <>
        <>
          <div className="fixed top-0 left-0 z-40 w-64 h-screen transition-transform -translate-x-full sm:translate-x-0">
            <div className="h-full px-3 py-4 overflow-y-auto bg-gray-50">
              <ul className="space-y-2 font-medium">
                <li>
                  <Link to='/' className="flex items-center p-2 text-gray-900 rounded-lg 
                    dark:text-white hover:bg-gray-100 dark:hover:bg-gray-700 group">
                      <FaHouse />
                      <span className="ml-2">
                        Home
                      </span>
                  </Link>
                </li>
                <li>
                  <Link to="tasks" className="flex items-center p-2 text-gray-900 rounded-lg 
                    dark:text-white hover:bg-gray-100 dark:hover:bg-gray-700 group">
                    <FaListCheck />
                    <span className="ml-2">
                      Tasks
                    </span>
                  </Link>
                </li>
                <li>
                  <Link to="#" className="flex items-center p-2 text-gray-900 rounded-lg 
                    dark:text-white hover:bg-gray-100 dark:hover:bg-gray-700 group">
                    <FaRegStar />
                    <span className="ml-2">
                      Achievements
                    </span>
                  </Link>
                </li>
                <li>
                  <Link to="#" className="flex items-center p-2 text-gray-900 rounded-lg 
                    dark:text-white hover:bg-gray-100 dark:hover:bg-gray-700 group">
                    <FaUser />
                    <span className="ml-2">
                      Profile 
                    </span>
                  </Link>
                </li>
                <li>
                  <Link to="#" className="flex items-center p-2 text-gray-900 rounded-lg 
                    dark:text-white hover:bg-gray-100 dark:hover:bg-gray-700 group">
                    <FaArrowRightFromBracket />
                    <span className="ml-2">
                      Logout
                    </span>
                  </Link>
                </li>
              </ul>
            </div>
          </div>
          <div className="ml-64">
            <Outlet />
          </div>
        </> 
    </>
  );
}

export default AuthorizedLayout;