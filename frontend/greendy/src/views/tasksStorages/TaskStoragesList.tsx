import { useEffect, useState } from "react";
import { client } from "../../services/axiosService";
import { TaskStorage } from "../../models/tasks/TaskStorage";
import { TaskStorageCategory } from "../../models/tasks/TaskStorageCategory";
import { FaPlus, FaTrash } from "react-icons/fa6";
import CreateTaskStorageModal from "./CreateTaskStorageModal";
import CategoriesList from "./CategoriesList";
import { useTaskCategoriesStore } from "../../stores/TaskCategoriesStore";
import { useTaskStorageStore } from "../../stores/TaskStorageStore";
import { confirmAlert } from "react-confirm-alert";
import TrackItemList from "./TrackItemList";

function TaskStoragesList() {
    const [activeTask, setActiveTask] = useState<string>();
    const [taskStorages, setTaskStorages] = useState<TaskStorage[]>([]);
    const [showModal, setShowModal] = useState<boolean>(false);
    const hasAnyCategories = useTaskCategoriesStore((state) => state.hasAnyCategories);

    const taskStorageAdd = function (id: string, name: string) {
      let localStorages = taskStorages;
      localStorages.push({
        name: name,
        trackStorageId: id
      });
      setTaskStorages(localStorages);
    }

    const setActiveStorage = useTaskStorageStore((state) => state.setActiveStorage);
    const activeStorageCategory = useTaskCategoriesStore((state) => state.activeTaskCategory);

    const loadTaskContent = function (taskStorageId: string) {
      setActiveTask(taskStorageId);
      setActiveStorage(taskStorageId);
    };

    const sendDeleteStorageRequest = function () {
      client.delete(`TrackStorage/delete?trackStorageId=${activeTask}`)
        .then(data => {
          setTaskStorages(taskStorages.filter(i => i.trackStorageId != activeTask));
          if (taskStorages.length) {
            setActiveTask(taskStorages[0].trackStorageId);
          }
          else {
            setActiveTask('');
          }
        })
        .catch(error => {
          console.error(error);
        });
    };

    const deleteActiveStorage = function () {
      if (hasAnyCategories) {
        confirmAlert({
          title: "Confirm delete",
          message: "Do you want to delete also everything related to storage?",
          buttons: [
            {
              label: 'Yes',
              onClick: () => sendDeleteStorageRequest(),
            },
            {
              label: 'No'
            }
          ]
        });
      } else {
        sendDeleteStorageRequest();
      }
    };

    useEffect(() => {
        client.get('TrackStorage/get-my')
            .then(data => 
              {
                let localTasks = data.data as TaskStorage[];
                if (localTasks.length)
                {
                  loadTaskContent(localTasks[0].trackStorageId);
                }
                setTaskStorages(localTasks);
              })
            .catch(error => console.error(error));
    }, [client]);

    return (
        <>
          <ul className="flex flex-wrap text-sm font-medium text-center text-gray-500 border-b border-gray-200 dark:border-gray-700 dark:text-gray-400">
            {
              taskStorages.map(d =>
                <li key={d.trackStorageId} onClick={() => loadTaskContent(d.trackStorageId)}>
                    <a href="#" 
                      className={d.trackStorageId == activeTask ? "inline-block p-4 secondary bg-gray-100 active dark:bg-gray-800 dark:text-blue-500" : "inline-block p-4 rounded-t-lg hover:text-gray-600 hover:bg-gray-50 dark:hover:bg-gray-800 dark:hover:text-gray-300"}>
                      {d.name} 
                    </a>
                </li>
              )
            }
            {
             activeTask ? 
              <li className="mr-2" onClick={() => false}>
                  <a href="#" 
                    onClick={() => deleteActiveStorage()}
                    className="red inline-block items-center flex p-4 h-full rounded-t-lg hover:text-gray-600 hover:bg-red-50 dark:hover:bg-gray-800 dark:hover:text-gray-300">
                      <FaTrash className="text-red-700" />
                  </a>
              </li>
             :
             <></>
            }
            <li className="mr-2" onClick={() => false}>
                <a href="#" 
                  onClick={() => setShowModal(true)}
                  className="inline-block items-center flex p-4 h-full rounded-t-lg hover:text-gray-600 hover:bg-gray-50 dark:hover:bg-gray-800 dark:hover:text-gray-300">
                    <FaPlus />
                </a>
            </li>
          </ul>
          <div className="w-full flex px-4 min-h-screen">
            <div className="w-3/4">
              <div className="w-2/4 m-auto">
                <h2 className="text-2xl p-2 font-medium uppercase primary text-center">Tracking Tasks:</h2>
                {activeStorageCategory != null ? <TrackItemList trackItemCategoryId={activeStorageCategory} /> : 
                  <div className="text-center">Choose category from the list</div>}
              </div>
            </div>
            <div className="w-1/4 border-l-2 p-2 min-h-full">
              <CategoriesList/>
            </div>
          </div>
          {showModal ? (
           <CreateTaskStorageModal onTaskStorageAdd={taskStorageAdd} onSetShowModal={setShowModal} /> 
          ) : null}
      </>
    );
}

export default TaskStoragesList;