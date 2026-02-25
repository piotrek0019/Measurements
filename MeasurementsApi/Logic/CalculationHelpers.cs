using ClosedXML.Excel;
using CopilotApi.Models;
using MathNet.Numerics.Statistics;

namespace CopilotApi.Logic
{
    /// <summary>
    /// Class with methods calculation helpers 
    /// </summary>
    public static class CalculationHelpers
    {
        /// <summary>
        /// Gets basic methematical calculations for specified columne from given work sheet
        /// </summary>
        /// <param name="workSheet">The work sheet to get date from</param>
        /// <param name="calculateFromColumn">The column in work sheet</param>
        /// <param name="operationType">The type of calculations to preform</param>
        /// <param name="calculationResult">The result of the calculation to out</param>
        /// <returns>Whether the type of the calculation can be preformed by this method</returns>
        public static bool TryGetCalculation(
            IXLWorksheet workSheet, 
            string calculateFromColumn, 
            RequestSimpleCalculations.SimpleOperationTypes operationType,
            out double calculationResult)
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

                    calculationResult = numbersToCalculate.Sum();
                    return true;
                case RequestSimpleCalculations.SimpleOperationTypes.Average:
                    calculationResult = numbersToCalculate.Average();
                    return true;
                case RequestSimpleCalculations.SimpleOperationTypes.Median:
                    calculationResult = numbersToCalculate.Median();
                    return true;
                case RequestSimpleCalculations.SimpleOperationTypes.Max:
                    calculationResult = numbersToCalculate.Max();
                    return true;
                case RequestSimpleCalculations.SimpleOperationTypes.Min:
                    calculationResult = numbersToCalculate.Min();
                    return true;
                case RequestSimpleCalculations.SimpleOperationTypes.StandardDeviation:
                    calculationResult = numbersToCalculate.StandardDeviation();
                    return true;
                default:
                    calculationResult = 0;
                    return false;
            }
        }
    }
}
