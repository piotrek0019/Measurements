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
        public string CellColumn { get; set; }

        /// <summary>
        /// The value of the cell, stored as a string. 
        /// </summary>
        public string CellValue { get; set; }
    }
}
