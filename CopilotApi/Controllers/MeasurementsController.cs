using CopilotApi.Logic;
using CopilotApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CopilotApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeasurementsController : ControllerBase
    {
        private readonly MeasurementExcelReader _reader;

        public MeasurementsController(MeasurementExcelReader reader)
        {
            _reader = reader;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MeasurementDto>> Get()
        {
            var data = _reader.Read().ToList();
            return Ok(data);
        }
    }

}
