<template>
    <div v-if="alertData">
        <h2>Current Alert</h2>
        <p><strong>Alert ID:</strong> {{ alertData.id }}</p>
        <p><strong>Updated At:</strong> {{ alertData.updatedAt }}</p>
        <p><router-link to="/all-alerts">See previous alerts.</router-link></p>
        <AlertCategories />
        <AlertReports />
    </div>
    <div v-else>
        <p>Loading...</p>
    </div>
</template>

<script setup>
import { ref, watchEffect } from 'vue';
import { storeToRefs } from 'pinia';
import useAlertAppStore from '@/store/useAlertAppStore';
import AlertCategories from './alert-categories.vue';
import AlertReports from './alert-reports.vue';
import apiClient from '@/services/api-client';

const store = useAlertAppStore();
const alertData = ref(null);
const { alertId } = storeToRefs(store);

const fetchAlert = async (id) => {
    if (id) {
        try {
            const response = await apiClient.getAlertById(id);
            alertData.value = response.data;
        } catch (error) {
            console.error('Error fetching current alert:', error);
        }
    }
}

watchEffect((
    [alertId],
    () => {
        fetchAlert(alertId.value);
    }
));
</script>