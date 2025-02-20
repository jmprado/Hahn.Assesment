<template>
  <main>
    <v-sheet>
      <v-container class="pa-0">
        <v-app>
          <v-app-bar>
            <v-app-bar-title class="text-no-wrap">{{ title }}</v-app-bar-title>
          </v-app-bar>
          <v-main>
            <v-container>
              <slot></slot>
            </v-container>
          </v-main>
        </v-app>
      </v-container>
    </v-sheet>
  </main>
</template>
<script setup>
defineProps({
  title: {
    type: String,
    required: true,
  },
})
</script>

