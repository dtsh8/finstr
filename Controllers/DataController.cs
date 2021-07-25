using FinstarApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace FinstarApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        #region Private fields

        private readonly IApplicationRepository _appRepository;
        private readonly ILogger<DataController> _logger;

        #endregion

        #region Constructor

        public DataController(IApplicationRepository appRepository, ILogger<DataController> logger)
        {
            _appRepository = appRepository;
            _logger = logger;
        }

        #endregion

        #region Public Methods

        // GET: api/<DataController>
        [HttpGet]
        public async Task<IActionResult> Get(int? code, string value)
        {
            var filter = new DataFilter { Code = code, Value = value };
            var data = await _appRepository.GetData(filter);
            return Ok(data);
        }

        // POST api/<DataController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IEnumerable<DataObject> values)
        {
            //var values = JsonConvert.DeserializeObject<DataObject>(value);
            await _appRepository.PostData(values);
            return Ok();
        }

        #endregion

    }
}
