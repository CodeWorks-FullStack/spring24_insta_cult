<script setup>
import { onMounted } from 'vue';
import Pop from '../utils/Pop.js';
import { cultsService } from '../services/CultsService.js';

async function getCults() {
  try {
    await cultsService.getCults()
  } catch (error) {
    Pop.error(error)
  }
}


onMounted(() => {
  getCults()
})

</script>


<template>
  <h1>Cults page works!</h1>
</template>


<style scoped></style>