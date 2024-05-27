

using ProjectWorkflow.DataAccess.Interfaces;
using ProjectWorkflow.DataAccess.Models;
using ProjectWorkflow.Logic.Interfaces;

namespace ProjectWorkflow.Logic.Services
{
    public class WorkflowService : IWorkflowService
    {
        private readonly IWorkFlowRepository _workflowRepository;

        public WorkflowService(IWorkFlowRepository workflowRepository) 
        {
            _workflowRepository = workflowRepository;
        }

        public async Task<Workflow> GetWorkflowByIdAsync(string id)
        {
            return await _workflowRepository.GetByIdAsync(id);
        }

        public async Task<Workflow> CreateWorkFlowAsync(Workflow workflow)
        {
            return await _workflowRepository.CreateAsync(workflow);
        }
    }
}
