<script setup lang="ts">
import { ref, onMounted } from "vue";
import { getMeasurements } from "@/services/measurementApi";

const raw = ref(null);

onMounted(async () => {
  raw.value = await getMeasurements();
  console.log("RAW DATA:", raw);
});
</script>

<template>
  <div class="table-container">
    <table class="table" v-if="raw">
      <tr v-for="(row, rowIndex) in raw" :key="rowIndex">
        <th v-for="cell in row.cells" v-if="rowIndex === 0" >
          {{ cell }}
        </th>
        <td v-else v-for="(cell, cellIndex) in row.cells" :key="cellIndex">
          {{ cell }}
        </td>
      </tr>
    </table>
  </div>
</template>
