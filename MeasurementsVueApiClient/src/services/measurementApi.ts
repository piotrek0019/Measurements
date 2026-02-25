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
