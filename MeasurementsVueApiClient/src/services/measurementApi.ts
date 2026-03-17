import axios from "axios";

export const api = axios.create({
  baseURL: "https://localhost:7231/api",
});

/**
 * Fetches all measurements data from the API. 
 * @returns A promise that resolves to the measurements data.
 */
export async function getMeasurements() {
  const { data } = await api.get("/measurements/allData");
  return data;
}

/**
 * Fetches the available operation types from the API.
 * @returns A promise that resolves to an array of operation types.
 */
export async function getOperationTypes() {
  const { data } = await api.get("/measurements/operationTypes");
  return data;
}
/**
 * Runs a specific operation on the measurements data.
 * @param operationType The type of operation to run (e.g., "Average", "Sum", etc.).
 * @param columnAddress The address of the column on which to run the operation.
 * @returns A promise that resolves to the result of the operation.
 */
export async function runOperation(operationType : string, columnAddress : string) {
  const { data } = await api.post("/measurements/operations", {
    operationType,
    columnAddress
  });

  return data;
}

