import { StoreApi, UseBoundStore, create } from "zustand";

type State = {
    activeTaskCategory?: string | null,
    hasAnyCategories: boolean,
    setActiveTaskCategory: (category: string | null) => void;
    setHasAnyCategories: (hasAnyCategory: boolean) => void;
}

export const useTaskCategoriesStore = create<State>((set) => ({
    activeTaskCategory: undefined,
    hasAnyCategories: false,
    setActiveTaskCategory: (category: string | null) => set((state: State) => ({ activeTaskCategory: category, hasAnyCategories: state.hasAnyCategories})),
    setHasAnyCategories: (hasAnyCategory: boolean ) => set((state: State) => ({ activeTaskCategory: state.activeTaskCategory, hasAnyCategories: hasAnyCategory })) 
}))