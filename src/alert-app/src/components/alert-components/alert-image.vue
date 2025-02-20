<template>
  <div>
    <v-card class="mx-auto scroll" :max-width="cardSize" max-height="600">
      <v-card-title>{{ imageData.place }}</v-card-title>
      <v-card-subtitle> Like count: {{ imageData.likeCount }} </v-card-subtitle>
      <v-img :src="imageData.imageMediumUrl" :width="cardSize" cover />
      <v-card-actions>
        <v-btn text="Close" @click="closeOverlay"></v-btn>
      </v-card-actions>
    </v-card>
  </div>
</template>
<script setup>
const props = defineProps(['imageData', 'place', 'likeCount', 'hideImage'])
const closeOverlay = () => {
  props.hideImage()
}

const cardSize = 400
</script>
<style scoped>
.card {
  width: 400px;
}

.scroll {
  overflow-y: auto;
}
</style>
