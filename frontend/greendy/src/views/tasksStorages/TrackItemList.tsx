import { useEffect, useState } from "react";
import { useTaskCategoriesStore } from "../../stores/TaskCategoriesStore";
import { client } from "../../services/axiosService";
import { TrackItem } from "../../models/tasks/TrackItem";
import { TrackItemService } from "../../services/TrackItemService";
import { FaPlus } from "react-icons/fa6";
import CreateTrackItemModal from "./CreateTrackItemModal";

type Props = {
  trackItemCategoryId: string
}

function TrackItemList(props: Props) {
  const [trackItemsList, setTrackItemsList] = useState<TrackItem[]>([]);
  const [showModal, setShowModal] = useState<boolean>(false);

  useEffect(() => {
    TrackItemService.GetTrackItemsByCategory(props.trackItemCategoryId)
      .then((value) => setTrackItemsList(value));
  }, [props.trackItemCategoryId]);

  return (
    <>
      <div className="w-full flex flex-row">
        <button className="border-gray-100 border-2 p-3 w-full flex items-center hover:bg-gray-100"
                onClick={() => setShowModal(true)}>
          <FaPlus />
          <span className="ml-4">
            Add new tasks...
          </span>
        </button>
      </div>
      {
        trackItemsList.map((item) => {
          return 
          (<>
            {item.name}
          </>);
        })
      }
      {
        showModal ? 
          <CreateTrackItemModal onSetShowModal={(i) => setShowModal(i)} />
          :
          <></>
      }
    </>
  );
}

export default TrackItemList;