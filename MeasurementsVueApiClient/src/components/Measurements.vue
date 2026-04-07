<script setup lang="ts">
import { ref, onMounted, watch } from "vue";
import { getMeasurements, runOperation } from "@/services/measurementApi";

const raw = ref(null);
const operations = ref(null);
const showCalculation = ref(false);
const selectedHeader = ref(0);
const selectedColumn = ref("");

interface OperationType {
  simpleOperationType: string;
  simpleOperationTypeString: string;
}

/**
 * The props object defines the properties that the Measurements component expects to receive from its parent component. 
 * In this case, it expects a single prop called operationSelected, which is of type String. 
 * This prop will be used to determine which operation type to run when the user clicks on a column header in the measurements table.
 */
const props = defineProps<{
  operationSelected: OperationType
}>()

/**
 * Lifecycle hook that is called when the component is mounted.
 */
onMounted(async () => {
  raw.value = await getMeasurements();
  console.log("RAW DATA:", raw);
});

watch(props, (newValue) => {
  runOperationType(props.operationSelected, selectedColumn.value);  
  console.log("Watch operationSelected:", newValue);
});


/**
 * Runs a specific operation on the measurements data.
 * @param operationType The type of operation to run (e.g., "Average", "Sum", etc.).
 * @param column The address of the column on which to run the operation.
 */
async function runOperationType(operationType: OperationType, column: string) {
  operations.value = await runOperation(operationType.simpleOperationType, column); 
  showCalculation.value = true;
  console.log("OPERATIONS DATA:", operations.value);
};

function selectHeader(header: number) {
  selectedHeader.value = header;
}
</script>

<template>
  <div class="notification" v-if="showCalculation">
    <button class="delete" @click="showCalculation = false"></button>
    <p>{{ operationSelected.simpleOperationTypeString }}</p>
      Calculated value: "{{ operations?.calculated }}"
  </div>
  <div class="table-container">
    <table class="table is-hoverable" v-if="raw">
      <tr v-for="(row, rowIndex) in raw" :key="rowIndex">
        <th v-if="Number(rowIndex) == selectedHeader">Header selection: No</th>
        <td v-else>
          <button @click="selectHeader(Number(rowIndex))" class="button is-text">
              {{ rowIndex }}
            </button>
        </td>
        <th v-for="cellHeader in row.cells" 
            v-if="Number(rowIndex) == selectedHeader"
            :key="cellHeader.cellColumn">
            <button @click="runOperationType(operationSelected, cellHeader.cellColumn); 
            selectedColumn = cellHeader.cellColumn;" 
            class="button is-text">
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
