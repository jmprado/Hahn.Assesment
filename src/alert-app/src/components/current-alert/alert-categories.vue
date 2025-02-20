<template>
  <div id="alert-categories">
    <h3>Weather conditions in this alert</h3>
    <div v-if="isLoading">
      <p>Loading alert categories...</p>
    </div>
    <div v-else>
      <v-select
        v-model="selectedCategory"
        label="Select to filter grid items"
        :items="categories"
        @update:modelValue="(selection) => selectionChanged(selection)"
      ></v-select>
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue'
import apiClient from '@/services/api-client'
import useAlertAppStore from '@/store/useAlertAppStore'

const store = useAlertAppStore()

const categories = ref([])
const isLoading = ref(true)
const selectedCategory = ref('All')

const fetchCategories = async () => {
  if (store.alertId !== null) {
    try {
      const response = await apiClient.getCategories(store.alertId)
      categories.value = response.data
      categories.value.unshift('All')
    } catch (error) {
      console.error('Error fetching categories:', error)
    } finally {
      isLoading.value = false
    }
  } else {
    isLoading.value = false
  }
}

const selectionChanged = (selection) => {
  store.gridFilter = selection
}

onMounted(fetchCategories)
</script>
<style scoped>
#alert-categories {
  margin-top: 20px;
}
</style>
