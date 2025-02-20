<template>
    <div id="alert-reports">
        <h3>Weather Report</h3>
        <div v-if="isLoading">
            <p>Loading alert reports...</p>
        </div>
        <div v-else>
            <ag-grid-vue :rowData="rowData" :columnDefs="colDefs" style="height: 500px">
            </ag-grid-vue>
            <v-overlay :model-value="toggleImage" class="overlay-center" @click="hideImage">
                <alert-image :imageData="cellData" :place="rowData.place" :like-count="rowData.likeCount" :imageClose="hideImage" />
            </v-overlay>
        </div>
    </div>
</template>

<script setup>
import { ref, onMounted } from 'vue';
import { AgGridVue } from "ag-grid-vue3"; // Vue Data Grid Component
import { MutationType } from 'pinia';
import alertImage from './alert-image.vue';
import useAlertAppStore from '@/store/useAlertAppStore';
import apiClient from '@/services/api-client';

import {
    ModuleRegistry,
    ColumnAutoSizeModule,
    RowAutoHeightModule,
    RowStyleModule,
    ClientSideRowModelModule,
} from 'ag-grid-community';

ModuleRegistry.registerModules([
    ColumnAutoSizeModule,
    RowAutoHeightModule,
    RowStyleModule,
    ClientSideRowModelModule,
]);

const reports = ref([]);
const reportsFiltered = ref([]);
const isLoading = ref(true);
const rowData = ref(reportsFiltered);
const toggleImage = ref(false);
const cellData = ref(null);

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
    if (gridFilter === "All") {
        reportsFiltered.value = reports.value;
        return;
    }
    reportsFiltered.value = reports.value.filter(item => item.category === gridFilter || gridFilter === "All");
};

const watchGridFilterSate = () => {
    store.$subscribe((mutation, state) => {
        mutation.type = MutationType.direct;
        mutation.gridFilter;
        filterReports(state.gridFilter);
    })
};

const showImage = (data) => {
    toggleImage.value = true;
    cellData.value = data;    
};

const hideImage = () => {
    toggleImage.value = false;
}

const colDefs = [
    { field: 'reportDate' },
    {
        field: 'place',
        cellRenderer: function (params) {
            return `<a href="https://maps.google.com/?q=${params.data.lat},${params.data.lon}" target="_blank">${params.value}</a>`;
        },
    },
    { field: 'category', cellDataType: 'text' },
    {
        headerName: 'Image',
        field: 'imageUrl',
        cellStyle: function () {
            return { color: '#416AD3' };
        },
        cellRenderer: function (params) {
            if (params.data.imageUrl) {
                return `<span style="color: hsla(160, 100%, 37%, 1); cursor: pointer;" @click="showImage('${params.data.imageUrl}')">View</span>`;
            }
            return 'N/A';
        },
        onCellClicked: function (params) {
            if (params.data.imageUrl)
                showImage(params.data);
        },
    },
];
</script>

<style scoped>
#alert-categories {
    margin-top: 20px;
}

.overlay-center {
    display: flex;
    justify-content: center;
    align-items: center;
}

.image-container {
    display: flex;
    justify-content: center;
    align-items: center;
    background: white;
    padding: 20px;
    border-radius: 10px;
}
</style>