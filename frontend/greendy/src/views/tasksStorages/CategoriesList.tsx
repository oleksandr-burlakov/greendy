import { useEffect, useState } from "react";
import Input from "../../components/form/Input";
import { TaskStorageCategory } from "../../models/tasks/TaskStorageCategory";
import Button from "../../components/Button";
import { client } from "../../services/axiosService";
import { useTaskStorageStore } from "../../stores/TaskStorageStore";
import { FaTrash } from "react-icons/fa6";
import { useTaskCategoriesStore } from "../../stores/TaskCategoriesStore";
import { addNewCategoryAsync } from "../../services/TaskStorageService";
import { AxiosError } from "axios";


function CategoriesList() {
  const [categoryName, setCategoryName] = useState<string>();
  const activeTaskStorage = useTaskStorageStore((state) => state.activeStorage);
  const activeTaskCategoryStorage = useTaskCategoriesStore();
  const [taskStorageCategory, setTaskStorageCategory] = useState<TaskStorageCategory[]>([]);
  
  const setActiveCategory = (taskCategoryId: string) => {
    activeTaskCategoryStorage.setActiveTaskCategory(taskCategoryId);
  };

  const addNewCategory = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    try {
      let result = await addNewCategoryAsync(event, categoryName as string, activeTaskStorage);
      let id = result.id;
      let localCategories = taskStorageCategory;
      localCategories.push({
        name: categoryName as string,
        trackItemCategoryId: id
      });
      setTaskStorageCategory(localCategories);
      setCategoryName(""); 
    } catch (error) {
      console.error(error);
    }
  };

  const deleteCategory = (id: string) => {
    client.delete(`TrackItemCategories/delete?trackItemCategoryId=${id}`)
      .then(data => {
        if (activeTaskCategoryStorage.activeTaskCategory == id) {
          activeTaskCategoryStorage.setActiveTaskCategory(null);
        }
        let localCategories = taskStorageCategory.filter(i => i.trackItemCategoryId != id);
        setTaskStorageCategory(localCategories);
      })
      .catch(error => {
        console.error(error);
      });
  };

  useEffect(() => {
    activeTaskCategoryStorage.setActiveTaskCategory(null);
    if (activeTaskStorage)
    {
      client.get(`TrackItemCategories/get-by-storage?trackStorageId=${activeTaskStorage}`)
        .then(data => {
          let localCategories = data.data as TaskStorageCategory[];
          if (localCategories.length) {
            activeTaskCategoryStorage.setHasAnyCategories(true);
            setActiveCategory(localCategories[0].trackItemCategoryId);
          } else {
            activeTaskCategoryStorage.setHasAnyCategories(false);
          }
          setTaskStorageCategory(localCategories);
        })
        .catch(error => console.error(error));
    }
  }, [activeTaskStorage]);

  return (
    <>
      <h2 className="text-2xl font-medium uppercase primary">
        Categories list:
      </h2>
      <ul className="flex flex-col flex-wrap items-center justify-center text-gray-900">
        {
          taskStorageCategory.map(d => 
            <li className="flex flex-row justify-between w-6/12" key={d.trackItemCategoryId}>
              <a onClick={() => setActiveCategory(d.trackItemCategoryId)} className={"hover:underline hover:cursor-pointer w-full" + (d.trackItemCategoryId == activeTaskCategoryStorage.activeTaskCategory ? " primary " : "")} >{d.name}</a>
              <button onClick={() => deleteCategory(d.trackItemCategoryId)}><FaTrash /></button>
            </li>
          )
        }
      </ul>
      <div className="w-full">
        <form onSubmit={addNewCategory} className="flex items-end gap-2">
          <div>
            <Input onInput={(event) => setCategoryName((event?.target as HTMLInputElement).value)} value={categoryName} label="Name" />
          </div>
          <Button color="primary" text="Add" />
        </form>
      </div>
    </>
  );
}

export default CategoriesList;