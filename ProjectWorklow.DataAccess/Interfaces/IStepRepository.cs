

using ProjectWorkflow.DataAccess.Models;

namespace ProjectWorkflow.DataAccess.Interfaces
{
    public interface IStepRepository
    {
        Task<Step> CreateStepAsync(Step step);
    }
}
