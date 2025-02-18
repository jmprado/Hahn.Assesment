<template>
    <div class="category-item">
        {{ category }}
    </div>
</template>
<script setup>
  
</script>
<script>
  export default {
    props: ['category']
  }  
</script>
<style scoped>
.category-item {
    padding: 0.5rem;
    border: 1px solid #ccc;
    border-radius: 4px;
}
</style>