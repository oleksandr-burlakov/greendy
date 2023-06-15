import { ref, computed } from 'vue'
import { defineStore } from 'pinia'
import { useLocalStorage } from '@vueuse/core'

export const useAuthorizationStore = defineStore('authorization', {
  state: () => {
    return {
      token: useLocalStorage('token', null)
    }
  },
  persist: true,
  actions: {
    setToken(token) {
      this.token = token
    }
  }
})
