namespace CopilotApi.Models
{
 
    /// <summary>
    /// Data transfer object representing a measurement, which is essentially a row in the excel sheet.
    /// </summary>
    public class MeasurementDto
    {
        /// <summary>
        /// List of cell values in the row, stored as strings.
        /// </summary>
        public List<Cell> Cells { get; set; } = new List<Cell>(); 
    }

    /// <summary>
    /// Represents a single cell in the excel sheet, containing the column name and the cell value as a string.
    /// </summary>
    public class Cell
    {
        /// <summary>
        /// Constructor to initialize the Cell with a column name and a cell value.
        /// </summary>
        /// <param name="cellColumn">The column name, the cell belongs to</param>
        /// <param name="cellValue">Cell value</param>
        public Cell(string cellColumn, string cellValue)
        {
            CellColumn = cellColumn;
            CellValue = cellValue;
        }
        /// <summary>
        /// The column name that the cell belongs to, stored as a string.
        /// </summary>
        public string CellColumn { get; private set; }

        /// <summary>
        /// The value of the cell, stored as a string. 
        /// </summary>
        public string CellValue { get; private set; }
    }

    /// <summary>
    /// Represents the result of a calculation operation performed on measurement data,
    /// including the operation type, a descriptive message, and the calculated result.
    /// </summary>
    public class OperationResultInfo
    {
        /// <summary>
        /// Operation type to preform
        /// </summary>
        public string Operation { get; private set; }

        /// <summary>
        /// Extra info
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Calculated value
        /// </summary>
        public string Calculated { get; private set; }

        /// <summary>
        /// A constructor for <see cref="OperationResultInfo"/>
        /// </summary>
        /// <param name="operation">Operation type</param>
        /// <param name="calculated">Calculated value</param>
        public OperationResultInfo(RequestSimpleCalculations operation, string calculated)
        {
            Operation = operation.SimpleOperationType.ToString();
            Message = $"You selected {operation.SimpleOperationType}";
            Calculated = calculated;
        }
    }
}
