<template>
    <div id="alert-reports">
        <h3>Weather Report</h3>
        <div v-if="isLoading">
            <p>Loading alert reports...</p>
        </div>
        <div v-else>
            <ag-grid-vue :rowData="rowData" :columnDefs="colDefs" style="height: 500px" @rowClicked="onRowClicked"
                valueGetter={rowDataGetter}>
            </ag-grid-vue>
        </div>
    </div>
</template>
<script setup>
import { ref, onMounted } from 'vue';
import { AgGridVue } from "ag-grid-vue3"; // Vue Data Grid Component
import { gridColumns } from '@/config/report-column-definition.js';
import { MutationType } from 'pinia'
import useAlertAppStore from '@/store/index';
import apiClient from '@/services/api-client';
import {
    ModuleRegistry,
    ColumnAutoSizeModule,
    RowAutoHeightModule,
    RowStyleModule,
    PaginationModule,
    TextFilterModule,
    NumberFilterModule,
    DateFilterModule,
    CustomFilterModule,
    ExternalFilterModule,
    QuickFilterModule,
    ClientSideRowModelModule,
} from 'ag-grid-community';

ModuleRegistry.registerModules([
    ColumnAutoSizeModule,
    RowAutoHeightModule,
    RowStyleModule,
    PaginationModule,
    TextFilterModule,
    NumberFilterModule,
    DateFilterModule,
    CustomFilterModule,
    ExternalFilterModule,
    QuickFilterModule,
    ClientSideRowModelModule,
]);

const reports = ref([]);
const reportsFiltered = ref([]);
const isLoading = ref(true);
const colDefs = ref(gridColumns)
const rowData = ref(reportsFiltered);

const store = useAlertAppStore();

const fetchReports = async () => {
    if (store.alertId) {
        try {
            const response = await apiClient.getReports(store.alertId);
            const data = response.data;
            reports.value = data;
            reportsFiltered.value = data;
        } catch (error) {
            console.log('Error fetching reports:', error);
        } finally {
            isLoading.value = false;
        }
    } else {
        isLoading.value = false;
    }
};

onMounted(() => { fetchReports(); watchGridFilterSate(); });

const filterReports = (gridFilter) => {
    if(gridFilter === "All") {
        reportsFiltered.value = reports.value;
        return;
    }

    reportsFiltered.value = reports.value.filter(item => item.category === gridFilter || gridFilter === "All");
};

const watchGridFilterSate = () => {
    store.$subscribe((mutation, state) => {
        mutation.type  = MutationType.direct;
        mutation.gridFilter
        filterReports(state.gridFilter);
    })
};
</script>

<script>
export default {
    name: "AlertReports",
    components: {
        AgGridVue, // Add Vue Data Grid component
    },
};
</script>
<style scoped>
#alert-categories {
    margin-top: 20px;
}
</style>