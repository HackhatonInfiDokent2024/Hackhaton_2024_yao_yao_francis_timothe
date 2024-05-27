

using ProjectWorkflow.DataAccess.Models;

namespace ProjectWorkflow.Logic.Interfaces
{
    public interface IStepService
    {
        Task<Step> CreateStepAsync(Step step);
    }
}
