using CopilotApi.Models;

namespace DataMeasurementsApi.Helpers
{
    public static class RequestCalculationTypesExtensions
    {
        public static string SimpleOperationTypeToString(this RequestSimpleCalculations.SimpleOperationTypes simpleOperationType)
        {
            switch (simpleOperationType)
            {
                case RequestSimpleCalculations.SimpleOperationTypes.Average:
                    return "Average";
                case RequestSimpleCalculations.SimpleOperationTypes.Median:
                    return "Median";
                case RequestSimpleCalculations.SimpleOperationTypes.Sum:
                    return "Sum";
                case RequestSimpleCalculations.SimpleOperationTypes.Min:
                    return "Minimum";
                case RequestSimpleCalculations.SimpleOperationTypes.Max:
                    return "Maximum";
                case RequestSimpleCalculations.SimpleOperationTypes.StandardDeviation:
                    return "Standard Deviation";
                default:
                    return "No opertion name found";
            }
        }
    }
}