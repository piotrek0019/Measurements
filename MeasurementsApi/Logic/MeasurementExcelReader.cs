namespace CopilotApi.Logic
{
    using ClosedXML.Excel;
    using CopilotApi.Models;
    using System.Collections.Generic;


    // Curently using and testing ClosedXML, but can be easily switched to another library if needed. 
    //public class MeasurementExcelReader : IExcelReader<MeasurementDto>

    /// <summary>
    /// This class is responsible for reading the excel file and returning the data 
    /// in a format that can be easily used by the rest of the application.
    /// </summary>
    public class MeasurementExcelReader
    {
        /// <summary>
        /// Backing field for <see cref="WorkSheet"/>. Lazily loaded when <see cref="WorkSheet"/> is accessed for the first time."/>
        /// </summary>
        private IXLWorksheet workSheet;

        /// <summary>
        /// Lazily loads the worksheet from the excel file. 
        /// The read file is currently "Data_Collection_18057426.xlsx".
        /// </summary>
        public IXLWorksheet WorkSheet 
        {
            get
            {
                if (workSheet == null)
                {
                    var workBook = new XLWorkbook("DataSets/Data_Collection_18057426.xlsx");
                    workSheet = workBook.Worksheet(1);
                }
                return workSheet;
            }
        }

        /// <summary>
        /// Reads the entire worksheet and returns an enumerable of <see cref="MeasurementDto"/> 
        /// where each dto represents a row in the worksheet.
        /// </summary>
        /// <returns>All data from the worksheet</returns>
        public IEnumerable<MeasurementDto> ReadWholeWorkSheet()
        {
            foreach (var row in WorkSheet.RowsUsed())
            {
                var rowToReturn = new List<string>();
                foreach (var cell in row.Cells())
                {
                    rowToReturn.Add(cell.GetFormattedString());
                }

                var measurementDto = new MeasurementDto();
                measurementDto.Cells.AddRange(rowToReturn);
                yield return measurementDto;
            }
        }

        /// <summary>
        /// Reads the data from a specific column in the worksheet 
        /// and returns an enumerable of strings representing the values in that column.
        /// </summary>
        /// <param name="columnAddress">Column address</param>
        /// <returns>The collection of data retrived from specified column</returns>
        /// <exception cref="Exception"></exception>
        public IEnumerable<string> ReadDataFromColumn(string columnAddress)
        {
            var column = WorkSheet.Column(columnAddress);

            var values = column.CellsUsed()
                .Skip(1) //Skip header
                .Select(c => c.GetFormattedString());

            return values;
        }

        /// <summary>
        /// Performs a calculation on a specific column in the worksheet based on the provided operation type
        /// </summary>
        /// <param name="columnAddress">The address of the column to get data/set of numbers from</param>
        /// <param name="operationType">The type of colculation to preform</param>
        /// <returns>Calculated result</returns>
        public string GetCalculation(string columnAddress, RequestSimpleCalculations.SimpleOperationTypes operationType)
        {
            if (CalculationHelpers.TryGetCalculation(WorkSheet, columnAddress, operationType, out var calculatedResult))
            {
                return calculatedResult.ToString();
            }
            return $"Could not calculate {operationType}";
        }
    }
}
