import axios from "axios";

export const api = axios.create({
  baseURL: "https://localhost:7231/api",
});

// Define the shape of your measurement model
/*export interface Measurement {
  id: number;
  name: string;
  value: number;
  // add more fields if your API returns them
}*/

export async function getMeasurements() {
  const { data } = await api.get("/measurements/allData");
  return data;
}

/* export interface OperationRequest {
  operationType: "Average" | "Sum" | "Min" | "Max"; // adjust to your API
  columnAddress: string;
} */


export async function runOperation(operationType : string, columnAddress : string) {
  const { data } = await api.post("/measurements/operations", {
    operationType,
    columnAddress
  });

  return data;
}

