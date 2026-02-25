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
        public List<string> Cells { get; set; } = new List<string>(); 
    }
}
