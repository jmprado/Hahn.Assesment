import { defineStore } from 'pinia'

const useCounterStore = defineStore('counter', {
  state: () => ({ alertId: null, gridFilter: 'All' }),
  getters: {
    getAlertId: (state) => state.alertId,
    getGridFilter: (state) => state.gridFilter,
  },
  actions: {
    setAlertId(id) {
      this.alertId = id;
    },
    setGridFilter(filter) {
      this.gridFilter = filter;
    },    
  },
});

export default  useCounterStore ;