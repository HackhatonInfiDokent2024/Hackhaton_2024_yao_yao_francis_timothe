using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.IO;
using ProjectWorkflow.DataAccess.Models;
using Newtonsoft.Json;
using ProjectWorkflow.Logic.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectWorkflow.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkFlowController : ControllerBase
    {
        private readonly IWorkflowService _workflowService;
        public WorkFlowController(IWorkflowService workflowService)
        {
             _workflowService = workflowService;
        }

        //// GET: api/<WorkFlowController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<WorkFlowController>/5
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkflowById(string id)
        {
            try
            {
                var workflow = await _workflowService.GetWorkflowByIdAsync(id);
                if (workflow == null)
                {
                    return NotFound();
                }
                return Ok(workflow);
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, $"Erreur interne du serveur: {ex.Message}");
            }
        }

        // POST api/<WorkFlowController>
        [HttpPost("upload")]
        public async Task<IActionResult> UploadWorkflow(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Aucun fichier téléchargé.");

            using var stream = new StreamReader(file.OpenReadStream());
            var content = await stream.ReadToEndAsync();
            var workflow = Newtonsoft.Json.JsonConvert.DeserializeObject<Workflow>(content);

            if (workflow == null)
                return BadRequest("Format JSON invalide.");

            //await _workflowService.CreateWorkFlowAsync(workflow);

            return Ok(new { Message = "Workflow téléchargé avec succès" });
        }



        ////PUT api/<WorkFlowController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        ////DELETE api/<WorkFlowController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
