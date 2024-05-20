<script setup>
import { onMounted } from 'vue';
import Pop from '../utils/Pop.js';
import { cultsService } from '../services/CultsService.js';
import { useRoute } from 'vue-router';

const route = useRoute()

async function getCultById() {
  try {
    await cultsService.getCultById(route.params.cultId)
  } catch (error) {
    Pop.error(error)
  }
}


onMounted(() => {
  getCultById()
})
</script>


<template>
  <h1>Cult Details Page</h1>
</template>


<style scoped></style>