<template>
  <div id="alert-reports">
    <h3>All Alerts</h3>
    <div v-if="isLoading">
      <p>Loading alert reports...</p>
    </div>
    <div v-else>
      <ag-grid-vue :rowData="rowData" :columnDefs="colDefs" style="height: 500px"> </ag-grid-vue>
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue'
import { storeToRefs } from 'pinia'
import { AgGridVue } from 'ag-grid-vue3' // Vue Data Grid Component
import useAlertAppStore from '@/store/useAlertAppStore'
import apiClient from '@/services/api-client'
import {
  ModuleRegistry,
  ColumnAutoSizeModule,
  RowAutoHeightModule,
  RowStyleModule,
  ClientSideRowModelModule,
} from 'ag-grid-community'
import { useRouter } from 'vue-router'

ModuleRegistry.registerModules([
  ColumnAutoSizeModule,
  RowAutoHeightModule,
  RowStyleModule,
  ClientSideRowModelModule,
])

const alerts = ref([])
const rowData = ref(alerts)
const isLoading = ref(true)
const store = useAlertAppStore()
const router = useRouter()
const { alertId } = storeToRefs(store)

const fetchAlerts = async () => {
  if (store.alertId) {
    try {
      const response = await apiClient.getAlerts(store.alertId)
      const data = response.data
      alerts.value = data
    } catch (error) {
      console.log('Error fetching reports:', error)
    } finally {
      isLoading.value = false
    }
    return;
  } 

  isLoading.value = false
}

const colDefs = [
  { field: 'updatedAt' },
  {
    headerName: '',
    cellRenderer: function (params) {
      if (params.data.id) {
        return `<span style="color: hsla(160, 100%, 37%, 1); cursor: pointer;" @click="setAlert('${params.data.id}')">Set as current alert</span>`
      }
      return 'N/A'
    },
    onCellClicked: function (params) {
      params.data.id
      alertId.value = params.data.id
      console.log('Alert ID:', alertId.value)
      router.push('/')
    },
  },
]

onMounted(() => {
  fetchAlerts()
})
</script>
