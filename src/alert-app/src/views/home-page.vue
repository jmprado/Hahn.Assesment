<template>
  <main>
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
  </main>
</template>
<script setup>
import AlertDetails from '@/components/current-alert/alert-details.vue'
</script>

<style scoped>
header {
  line-height: 1.5;
}

@media (min-width: 1024px) {
  header {
    display: flex;
    place-items: left;
    padding-right: calc(var(--section-gap) / 2);
  }

  .logo {
    margin: 0 2rem 0 0;
  }

  header .wrapper {
    display: flex;
    place-items: flex-start;
    flex-wrap: wrap;
  }
}
</style>
