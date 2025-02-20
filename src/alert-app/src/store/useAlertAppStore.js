import { defineStore } from 'pinia'
import apiClient from '../services/api-client' // Adjust the path as necessary

export const useAlertAppStore = () => {
  const innerStore = defineStore('myStore', {
    state: () => ({ alertId: undefined, gridFilter: 'All' }),
    actions: {
      async fetchAlertId() {
        const response = await apiClient.getCurrentAlert()
        this.alertId = response.data.id
      },
    },
  })

  const store = innerStore()

  if (!store.alertId) {
    store.fetchAlertId()
  }

  return store
}

export default useAlertAppStore
