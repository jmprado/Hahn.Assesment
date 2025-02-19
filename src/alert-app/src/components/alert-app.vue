<script setup lang="ts">
import AlertDetails from './alert-details.vue';

</script>

<template>
  <div id="app">
    <v-sheet>
      <v-container class="pa-0">
        <v-app>
          <v-app-bar title="Deutscher Wetterdienst - Weather Alerts"></v-app-bar>
          <v-main>
            <v-container>
              <AlertDetails />
            </v-container>
          </v-main>
        </v-app>
      </v-container>
    </v-sheet>
  </div>
</template>

