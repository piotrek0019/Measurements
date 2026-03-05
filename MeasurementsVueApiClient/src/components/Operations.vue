<script setup lang="ts">
import { ref, onMounted } from "vue";
import { runOperation } from "@/services/measurementApi";

const result = ref(null);

onMounted(async() => {
  result.value = await runOperation("Average", "F");
});

</script>

<template>
  <div>
    {{ result }}
  </div>
</template>
