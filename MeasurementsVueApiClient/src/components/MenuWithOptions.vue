<script setup lang="ts">

import { ref, onMounted, watch } from "vue";
import { getOperationTypes } from "@/services/measurementApi";
    
const operationTypes = ref(null);
const isActive = ref(false);
const selectedOperationType = ref(null);

const emit = defineEmits(['response']);
watch(selectedOperationType, (newValue) => {
  emit('response', newValue);
});


onMounted(async () => {
  operationTypes.value = await getOperationTypes();
  console.log("OPERATION TYPES:", operationTypes.value);
});

watch(selectedOperationType, (newCount) => {
  console.log(`new count is: ${newCount}`)
})

</script>


<template>
  <div class="dropdown" :class="{ 'is-active': isActive}">
    <div class="dropdown-trigger">
      <button @click="isActive = !isActive" class="button">
        <span v-if="selectedOperationType == null">Dropdown button</span>
        <span v-else>Selected: {{ selectedOperationType }}</span>
        <span class="icon is-small">
          <i class="fas fa-angle-down"></i>
        </span>
      </button>
    </div>
    <div class="dropdown-menu" id="dropdown-menu" role="menu">
      <div class="dropdown-content">
        <a 
          v-for="type in operationTypes" 
          :key="type" 
          @click="selectedOperationType = type, isActive = false" 
          href="#" 
          class="dropdown-item" :class="{ 'is-active': selectedOperationType === type }">
            {{ type }}
        </a>
      </div>
    </div>
  </div>
</template>
