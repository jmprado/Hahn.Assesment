import { defineStore } from 'pinia'
import apiClient from '../services/api-client' // Adjust the path as necessary

export const useAlertAppStore = () => {
  const innerStore = defineStore('myStore', {
    state: () => ({ alertId: undefined, gridFilter: 'All', alertImage: null }),
    getters: {
      getAlertId: (state) => state.alertId,
      getGridFilter: (state) => state.gridFilter,
      getAlertImage: (state) => state.alertImage,
    },
    setters: {
      setAlertId(id) {
        this.alertId = id
      },
      setGridFilter(filter) {
        this.gridFilter = filter
      },
      setAlertImage(image) {
        this.alertImage = image
      },
    },
    actions: {
      async fetchAlertId() {
        const response = await apiClient.getCurrentAlert();
        this.alertId = response.data.id;
      },
    },
  })

  const store = innerStore();

  if (!store.alertId) {
    store.fetchAlertId();
  }

  return store;
}

export default useAlertAppStore;
