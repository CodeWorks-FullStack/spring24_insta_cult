<script setup>
import { Cult } from '../models/Cult.js';

defineProps({
  cult: { type: Cult, required: true }
})
</script>


<template>
  <div class="cult-card">
    <div class="d-flex align-items-center gap-3 p-4">
      <img :src="cult.leader.picture" :alt="cult.leader.name" class="profile-picture">
      <p class="fs-2 mb-0">{{ cult.leader.name }}</p>
    </div>
    <img :src="cult.coverImg" :alt="cult.name" class="cult-img">
    <div class="p-4">
      <p class="fs-3">{{ cult.name }}</p>
      <!-- FIXME truncate text -->
      <p>{{ cult.description }}</p>
      <div class="text-end">
        <button class="btn btn-danger">See More</button>
      </div>
    </div>
  </div>
</template>


<style scoped>
.cult-card {
  background-color: #3F3B3B;
}

.profile-picture {
  height: 10vh;
  aspect-ratio: 1/1;
  border-radius: 50%;
}

.cult-img {
  width: 100%;
  height: 40vh;
  object-fit: cover;

}
</style>