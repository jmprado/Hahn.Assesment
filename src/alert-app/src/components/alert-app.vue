<template>
  <div id="app">
    <v-sheet>
      <v-container class="pa-0">
        <v-app>
          <v-app-bar title="Deutscher Wetterdienst - Weather Alerts"></v-app-bar>
          <v-main>
            <v-container>
              <div v-if="alert">
                <h2>Current Alert</h2>
                <p><strong>Alert ID:</strong> {{ alert.id }}</p>
                <p><strong>Updated At:</strong> {{ alert.updatedAt }}</p>                
                <AlertCategories :alertId="alert.id" />
                <AlertReports :alertId="alert.id" />
              </div>                            
              <div v-else>
                <p>Loading...</p>
              </div>
            </v-container>
          </v-main>
        </v-app>
      </v-container>
    </v-sheet>
  </div>
</template>

<script setup>
import AlertCategories from './alert-categories.vue'
import AlertReports from './alert-reports.vue';
</script>
<script>
import apiClient from '@/services/api-client';
import useAlertAppStore from '@/store/index';
export default {
  data() {
    return {
      alert: null,
    };
  },
  created() {
    this.fetchCurrentAlert();
  },
  methods: {
    async fetchCurrentAlert() {
      try {
        const store = useAlertAppStore();
        const response = await apiClient.getCurrentAlert();
        this.alert = response.data;
        store.setAlertId(this.alert.id);
      } catch (error) {
        console.error('Error fetching current alert:', error);
      }
    },
  },
};
</script>