import { defineStore } from 'pinia'

const useAlertAppStore = defineStore('counter', {
  state: () => ({ alertId: null, gridFilter: 'All', alertImage: null }),
  getters: {
    getAlertId: (state) => state.alertId,
    getGridFilter: (state) => state.gridFilter,
    getAlertImage: (state) => state.alertImage,
  },
  actions: {
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
});

export default useAlertAppStore;
