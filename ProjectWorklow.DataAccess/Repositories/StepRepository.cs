
using MongoDB.Driver;
using ProjectWorkflow.DataAccess.Interfaces;
using ProjectWorkflow.DataAccess.Models;


namespace ProjectWorkflow.DataAccess.Repositories
{
    public class StepRepository : IStepRepository
    {
        private readonly IMongoCollection<Step> _step;

        public StepRepository(IMongoDatabase mongoDatabase) 
        {
            _step = mongoDatabase.GetCollection<Step>("Step");
        }

        public async Task<Step> CreateStepAsync(Step step)
        {
            try
            {
                await _step.InsertOneAsync(step);
                return step;
            }
            catch (Exception ex)
            {
                // Gérer l'exception ici
                throw new Exception("Failed to create Step", ex);
            }
        }

    }
}
