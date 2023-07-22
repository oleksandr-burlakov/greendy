import { create } from "zustand";

type State = {
    activeStorage?: string,
    setActiveStorage: (storage: string) => void;
}

export const useTaskStorageStore = create<State>((set) => ({
   activeStorage: undefined,
   setActiveStorage: (storage: string) => set({activeStorage: storage}) 
}));