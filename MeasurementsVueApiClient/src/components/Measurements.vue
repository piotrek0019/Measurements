<script setup lang="ts">
import { ref, onMounted } from "vue";
import { getMeasurements, runOperation } from "@/services/measurementApi";

const raw = ref(null);
const operations = ref(null);
const showCalculation = ref(false);

onMounted(async () => {
  raw.value = await getMeasurements();
  console.log("RAW DATA:", raw);
});

/* onMounted(async () => {
  operations.value = await runOperation("Average", "F"); 
  console.log("OPERATIONS DATA:", operations);
}); */

async function runOperationType(operationType: string, column: string) {
  operations.value = await runOperation(operationType, column); 
  showCalculation.value = true;
  console.log("OPERATIONS DATA:", operations.value);
};
</script>

<template>
  <div class="notification" v-if="showCalculation">
    <button class="delete" @click="showCalculation = false"></button>
    <p>{{ operations?.message }}</p>
      Calculated value: "{{ operations?.calculated }}"
  </div>
  <div class="table-container">
    <table class="table is-hoverable" v-if="raw">
      <tr v-for="(row, rowIndex) in raw" :key="rowIndex">
        <th v-for="cellHeader in row.cells" 
            v-if="rowIndex === 0" 
            :key="cellHeader.cellColumn">
            <button @click="runOperationType('Average', cellHeader.cellColumn)" class="button is-text">
              {{ cellHeader.cellValue }}
            </button>
        </th>
        <td v-else v-for="cell in row.cells" :key="cell.cellColumn">
          {{ cell.cellValue }}
        </td>
      </tr>
    </table>
  </div>
</template>
