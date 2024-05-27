

using ProjectWorkflow.DataAccess.Models;

namespace ProjectWorkflow.DataAccess.Interfaces
{
    public interface IWorkFlowRepository
    {
        Task<Workflow> CreateAsync(Workflow workflow);
        Task<Workflow> GetByIdAsync(string id);
    }
}
