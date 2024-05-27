using MongoDB.Driver;
using ProjectWorkflow.DataAccess.Interfaces;
using ProjectWorkflow.DataAccess.Models;

namespace ProjectWorkflow.DataAccess.Repositories
{
    public class WorkFlowRepository : IWorkFlowRepository
    {
        private readonly IMongoCollection<Workflow> _workflow;

        public WorkFlowRepository(IMongoDatabase mongoDatabase)
        {
            _workflow = mongoDatabase.GetCollection<Workflow>("Workflow");
        }

        public async Task<Workflow> CreateAsync(Workflow workflow)
        {
            await _workflow.InsertOneAsync(workflow);
            return workflow;
        }

        public async Task<Workflow> GetByIdAsync(string id)
        {
            try
            {
                var filter = await _workflow.Find(x => x.Id == id).FirstOrDefaultAsync();
                return filter;
            }
            catch (Exception ex)
            {
                throw new Exception($"Échec de la récupération du workflow avec l'ID: {id}", ex);
            }
        }
    }
}
