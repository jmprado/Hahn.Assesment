<script setup>
import AlertList from '../components/all-alerts/all-alerts.vue';
</script>
<template>
  <v-sheet>
    <v-container class="pa-0">
      <v-app>
        <v-app-bar title="Deutscher Wetterdienst - All Weather Alerts"></v-app-bar>
        <v-main>
          <v-container>
            <AlertList />
          </v-container>
        </v-main>
      </v-app>
    </v-container>
  </v-sheet>
</template>
