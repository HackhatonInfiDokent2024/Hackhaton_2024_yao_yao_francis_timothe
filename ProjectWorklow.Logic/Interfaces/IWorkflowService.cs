

using ProjectWorkflow.DataAccess.Models;

namespace ProjectWorkflow.Logic.Interfaces
{
    public interface IWorkflowService
    {
        Task<Workflow> GetWorkflowByIdAsync(string id);
        Task<Workflow> CreateWorkFlowAsync(Workflow workflow);
    }
}
