<script setup lang="ts">
//import HelloWorld from './components/HelloWorld.vue'
//import Operations from './components/Operations.vue'
import { ref, watch } from "vue";
import Measurements from './components/Measurements.vue'
import MenuWithOptions from './components/MenuWithOptions.vue'

/**
 * The selectedOperationType variable is a ref that holds the currently selected operation type.
 */
const selectedOperationType = ref('no selected yet');

watch(selectedOperationType, (newCount) => {
  console.log(`new count is: ${newCount}`)
})
</script>

<template>
  <body>
    <header class="container header-bar">
      <div class="Museo-700 logo">
          <a href="https://august-web.com">
            august
          </a>
      </div>
      <MenuWithOptions @response="(operation) => selectedOperationType = operation" />
    </header>
    <main class="container">
      <Measurements :operationSelected="selectedOperationType"/>
    </main>
  </body>
  
</template>
