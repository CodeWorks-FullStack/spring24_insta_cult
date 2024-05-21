<script setup>
import { computed, onMounted } from 'vue';
import Pop from '../utils/Pop.js';
import { cultsService } from '../services/CultsService.js';
import { useRoute } from 'vue-router';
import { AppState } from '../AppState.js';
import LoadingComponent from '../components/LoadingComponent.vue';
import { cultMembersService } from '../services/CultMembersService.js';

const cult = computed(() => AppState.activeCult)

const cultBackgroundImage = computed(() => `url(${cult.value?.coverImg})`)

const route = useRoute()

async function getCultById() {
  try {
    await cultsService.getCultById(route.params.cultId)
  } catch (error) {
    Pop.error(error)
  }
}

async function getCultistsByCultId() {
  try {
    await cultMembersService.getCultistsByCultId(route.params.cultId)
  } catch (error) {
    Pop.error(error)
  }
}


onMounted(() => {
  getCultById()
  getCultistsByCultId()
})
</script>


<template>
  <!-- FIXME style this up a little better -->
  <div v-if="cult" class="container-fluid">
    <section class="row cult-hero align-items-center">
      <div class="col-12 cult-name">
        <h1>{{ cult.name }}</h1>
      </div>
    </section>
    <section class="row">
      <div class="col-12 col-md-6 p-3">
        <p>{{ cult.description }}</p>
      </div>
      <div class="col-12 col-md-6 p-3">
        <h2>Cult Leader</h2>
        <p>{{ cult.leader.name }}</p>
      </div>
    </section>
  </div>

  <div v-else class="container-fluid">
    <section class="row">
      <div class="col-12 text-center">
        <LoadingComponent />
      </div>
    </section>
  </div>
</template>


<style scoped>
.cult-hero {
  min-height: 50vh;
  background-image: v-bind(cultBackgroundImage);
  background-size: cover;
  background-position: center;
}

.cult-name {
  -webkit-backdrop-filter: blur(2px);
  backdrop-filter: blur(2px);
}

h1 {
  text-shadow: 1px 1px 3px black;
  font-weight: bolder;
}
</style>