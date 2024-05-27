using Microsoft.AspNetCore.Mvc;
using ProjectWorkflow.DataAccess.Models;
using ProjectWorkflow.Logic.Interfaces;
using ProjectWorkflow.Logic.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectWorkflow.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StepController : ControllerBase
    {
        private readonly IStepService _stepService;
        public StepController(IStepService stepService)
        {
            _stepService = stepService;
        }
        //// GET: api/<StepController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<StepController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<StepController>
        [HttpPost]
        public async Task<IActionResult> PostStepAsync([FromBody] Step step)
        {
            try
            {
                var stp = await _stepService.CreateStepAsync(step);
                if (stp == null)
                {
                    return NotFound();
                }
                return Ok(stp);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Erreur interne du serveur: {ex.Message}");
            }
        }

        //// PUT api/<StepController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<StepController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
