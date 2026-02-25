namespace CopilotApi.Models
{
    /// <summary>
    /// Data transfer object representing a request for simple calculations on the data in the excel sheet.
    /// </summary>
    public class RequestSimpleCalculations
    {
        /// <summary>
        /// Enumeration of supported simple operation types that can be performed on the data.
        /// </summary>
        public enum SimpleOperationTypes
        {
            Average,
            Median,
            Sum,
            Min,
            Max,
            StandardDeviation
        }

        /// <summary>
        /// The type of operation to perform on the data, 
        /// specified as one of the values from the <see cref="SimpleOperationTypes"/> enumeration.
        /// </summary>
        public SimpleOperationTypes OperationType { get; set; }

        /// <summary>
        /// The name or address of the column in the excel sheet on which to perform the calculation.
        /// </summary>
        public string ColumnAddress { get; set; }
    }
}
