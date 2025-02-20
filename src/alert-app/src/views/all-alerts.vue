<template>
  <main>
    <BaseView title="Deutscher Wetterdienst - All Weather Alerts">
      <AlertList />
    </BaseView>
  </main>
</template>
<script setup>
import AlertList from '../components/all-alerts/all-alerts.vue'
import BaseView from '../views/base-view.vue'
</script>
