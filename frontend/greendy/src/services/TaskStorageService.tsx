import { AxiosError } from "axios";
import { client } from "./axiosService";

export interface NewCategory {
    id: string,
    name: string
};


async function addNewCategoryAsync(event: React.FormEvent<HTMLFormElement>, categoryName: string, activeTaskStorage: string | undefined): Promise<NewCategory> {
    event.preventDefault();
    return await client.post('TrackItemCategories/create', {
      name: categoryName,
      trackStorageId: activeTaskStorage
    })
    .then(data => {
      let id = data.data;
      let result: NewCategory = {
        id: id,
        name: categoryName
      };
      return result; 
    })
    .catch((error: AxiosError) => {
      throw error;
    });
  };

export {addNewCategoryAsync};