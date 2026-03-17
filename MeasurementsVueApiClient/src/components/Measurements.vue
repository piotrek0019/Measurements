<script setup lang="ts">
import { ref, onMounted } from "vue";
import { getMeasurements, runOperation } from "@/services/measurementApi";

const raw = ref(null);
const operations = ref(null);
const showCalculation = ref(false);

/**
 * The props object defines the properties that the Measurements component expects to receive from its parent component. 
 * In this case, it expects a single prop called operationSelected, which is of type String. 
 * This prop will be used to determine which operation type to run when the user clicks on a column header in the measurements table.
 */
const props = defineProps({
  operationSelected: String
})

/**
 * Lifecycle hook that is called when the component is mounted.
 */
onMounted(async () => {
  raw.value = await getMeasurements();
  console.log("RAW DATA:", raw);
});


/**
 * Runs a specific operation on the measurements data.
 * @param operationType The type of operation to run (e.g., "Average", "Sum", etc.).
 * @param column The address of the column on which to run the operation.
 */
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
            <button @click="runOperationType(operationSelected, cellHeader.cellColumn)" class="button is-text">
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
