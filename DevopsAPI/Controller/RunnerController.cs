using DevopsAPI.Models;
using DevopsAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DevopsAPI.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RunnerController : ControllerBase
    {

        private readonly IRunner _runner;
        public RunnerController(IRunner runner)
        {
            _runner = runner;
        }


        /// <summary>
        /// Get runner by type
        /// </summary>
        /// <param name="type">type of container config</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Docker(ContainerType type)
        {
            var result = await _runner.Create(type);
            return Ok(result);
        }

    }
}
