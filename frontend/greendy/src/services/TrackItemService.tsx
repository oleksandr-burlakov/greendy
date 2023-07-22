import { TrackItem } from "../models/tasks/TrackItem";
import { client } from "./axiosService";

function GetTrackItemsByCategory(categoryId: string): Promise<TrackItem[]> {
    return client.get(`TrackItem/get-by-category?categoryId=${categoryId}`)
      .then((data) => data.data as TrackItem[])
      .catch((error) => { throw error; });
}

const TrackItemService = {
    GetTrackItemsByCategory
}

export {TrackItemService};