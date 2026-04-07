using CopilotApi.Logic;
using CopilotApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CopilotApi.Controllers
{
    /// <summary>
    /// Controller responsible for handling measurement data from the excel sheet. It provides endpoints to retrieve all data, 
    /// get data from a specific column, and perform simple calculations on the data based on user requests.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class MeasurementsController : ControllerBase
    {
        /// <summary>
        /// Instance of MeasurementExcelReader used to read data from the excel sheet and perform calculations. 
        /// This is injected via dependency injection.
        /// </summary>
        private readonly MeasurementExcelReader _reader;

        /// <summary>
        /// Constructor for MeasurementsController which takes a MeasurementExcelReader as a parameter. 
        /// </summary>
        /// <param name="reader">The object used to read data from the excel and preform calculations</param>
        public MeasurementsController(MeasurementExcelReader reader)
        {
            _reader = reader;
        }

        /// <summary>
        /// Endpoint to retrieve all data from the excel sheet. 
        /// It returns an enumerable of MeasurementDto, where each dto represents a row in the sheet.
        /// </summary>
        /// <returns>All data from workSheet</returns>
        [HttpGet("allData")]
        public ActionResult<IEnumerable<MeasurementDto>> Get()
        {
            var data = _reader.ReadWholeWorkSheet().ToList();
            return Ok(data);
        }

        /// <summary>
        /// Endpoint to retrieve all supported simple operation types for calculations.
        /// Returns an array of <see cref="RequestSimpleCalculations.SimpleOperationTypes"/> values.
        /// </summary>
        /// <returns>An array of supported operation types.</returns>
        [HttpGet("operationTypes")]
        public ActionResult<IEnumerable<SimpleOperationTypeDto>> GetSimpleOperationTypes()
        {
            var operationTypes = Enum.GetValues(typeof(RequestSimpleCalculations.SimpleOperationTypes));

            var simpleOperationTypesToList = new List<SimpleOperationTypeDto>();
            foreach(var operationType in operationTypes)
            {
                if(operationType is RequestSimpleCalculations.SimpleOperationTypes simpleOperationType)
                {
                    simpleOperationTypesToList.Add(new SimpleOperationTypeDto(simpleOperationType));
                }
            }
                
            return Ok(simpleOperationTypesToList);
        }

        /// <summary>
        /// Endpoint to retrieve data from a specific column in the excel sheet. The column name is provided as a query parameter.
        /// </summary>
        /// <param name="columnAddress"></param>
        /// <returns>The all data from selected column</returns>
        [HttpGet("columnAddress")]
        public ActionResult<IEnumerable<MeasurementDto>> GetDataFromColumn([FromQuery] string columnAddress)
        {
            var data = _reader.ReadDataFromColumn(columnAddress).ToList();
            return Ok(data);
        }

        /// <summary>
        /// Endpoint to perform simple calculations on the data based on user requests. 
        /// The request body should contain the operation type and the column name to perform the calculation on.
        /// </summary>
        /// <param name="operation">The type of colculation to preform</param>
        /// <returns>The type and result of selected calculation</returns>
        [HttpPost("operations")]
        public ActionResult<OperationResultInfo>  Calculate(RequestSimpleCalculations operation)
        {
            var result = _reader.GetCalculation(operation.ColumnAddress, operation.SimpleOperationType);
            var resultInfo = new OperationResultInfo(operation, result);
            return Ok(resultInfo);
        }
    }
}
