using ClosedXML.Excel;
using CopilotApi.Models;
using MathNet.Numerics.Statistics;

namespace CopilotApi.Logic
{
    public static class CalculationHelpers
    {
        public static double GetCalculation(IXLWorksheet workSheet, string calculateFromColumn, RequestSimpleCalculations.SimpleOperationTypes operationType)
        {
            var numbersToCalculate =
                workSheet
                .Column(calculateFromColumn)
                .CellsUsed()
                .Skip(1) // Skip header
                .Select(c => c.GetDouble());

            switch (operationType)
            {
                case RequestSimpleCalculations.SimpleOperationTypes.Sum:
                    return numbersToCalculate.Sum();
                case RequestSimpleCalculations.SimpleOperationTypes.Average:
                    return numbersToCalculate.Average();
                case RequestSimpleCalculations.SimpleOperationTypes.Median:
                    return numbersToCalculate.Median();
                case RequestSimpleCalculations.SimpleOperationTypes.Max:
                    return numbersToCalculate.Max();
                case RequestSimpleCalculations.SimpleOperationTypes.Min:
                    return numbersToCalculate.Min();
                case RequestSimpleCalculations.SimpleOperationTypes.StandardDeviation:
                    return numbersToCalculate.StandardDeviation();
                default:
                    throw new ArgumentException($"No calculation for operation type: {operationType}");
            }
        }
    }
}
