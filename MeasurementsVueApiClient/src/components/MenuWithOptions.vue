<script setup lang="ts">

import { ref, onMounted, watch } from "vue";
import { getOperationTypes } from "@/services/measurementApi";
    
/**
 * This component is a dropdown menu that allows the user to select an operation type.
 */
const operationTypes = ref(null);

/**
 * The isActive variable is a boolean that indicates whether the dropdown menu is currently open or closed.
 */
const isActive = ref(false);

/**
 * The selectedOperationType variable is a ref that holds the currently selected operation type from the dropdown menu.
 */
const selectedOperationType = ref(null);

/**
 * The emit function is used to emit a custom event called 'response' whenever the selected operation type changes. 
 * The new value of the selected operation type is passed as an argument to the event.
 */
const emit = defineEmits(['response']);
watch(selectedOperationType, (newValue) => {
  emit('response', newValue);
});

/**
 * Fetches the operation types from the API when the component is mounted.
 */
onMounted(async () => {
  operationTypes.value = await getOperationTypes();
  console.log("OPERATION TYPES:", operationTypes.value);
});

</script>


<template>
  <div class="dropdown" :class="{ 'is-active': isActive}">
    <div class="dropdown-trigger">
      <button @click="isActive = !isActive" class="button">
        <span v-if="selectedOperationType == null">Dropdown button</span>
        <span v-else>Selected: {{ selectedOperationType.simpleOperationTypeString }}</span>
        <span class="icon is-small">
          <i class="fas fa-angle-down"></i>
        </span>
      </button>
    </div>
    <div class="dropdown-menu" id="dropdown-menu" role="menu">
      <div class="dropdown-content">
        <a 
          v-for="type in operationTypes" 
          :key="type.simpleOperationType" 
          @click="selectedOperationType = type, isActive = false" 
          href="#" 
          class="dropdown-item" :class="{ 'is-active': selectedOperationType === type }">
            {{ type.simpleOperationTypeString }}
        </a>
      </div>
    </div>
  </div>
</template>
