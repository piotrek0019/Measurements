using DataMeasurementsApi.Helpers;

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
        public SimpleOperationTypes SimpleOperationType { get; set; }

        /// <summary>
        /// The name or address of the column in the excel sheet on which to perform the calculation.
        /// </summary>
        public string ColumnAddress { get; set; }
    }

    /// <summary>
    /// Data transfer object that represents a simple operation type,
    /// including both its enum value and its corresponding user friendly string representation.
    /// </summary>
    public class SimpleOperationTypeDto
    {
        /// <summary>
        /// A operation type
        /// </summary>
        public RequestSimpleCalculations.SimpleOperationTypes SimpleOperationType { get; private set; }

        /// <summary>
        /// User friendly operation string representation
        /// </summary>
        public string SimpleOperationTypeString { get; private set; }

        /// <summary>
        /// A constructor for <see cref="SimpleOperationTypeDto"/>
        /// </summary>
        /// <param name="simpleOperationType">Operation type</param>
        public SimpleOperationTypeDto(RequestSimpleCalculations.SimpleOperationTypes simpleOperationType)
        {
            SimpleOperationType = simpleOperationType;
            SimpleOperationTypeString = simpleOperationType.SimpleOperationTypeToString();
        }
    }
}
