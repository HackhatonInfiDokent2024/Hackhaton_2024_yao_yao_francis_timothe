

using ProjectWorkflow.DataAccess.Interfaces;
using ProjectWorkflow.DataAccess.Models;
using System.Runtime.Intrinsics.Arm;

namespace ProjectWorkflow.Logic.Services
{
    public class StepService
    {
        private readonly IStepRepository _stepRepository;
        public StepService(IStepRepository stepRepository)
        {
            _stepRepository = stepRepository;
        }

        public async Task<Step> CreateStepAsync(Step step)
        {
            Step newStep = new Step
            {
                Id = step.Id,
                Name = step.Name,
                Description = step.Description,
                RequiredFields = step.RequiredFields.Select(field => new Field
                {
                    Id = field.Id,
                    Name = field.Name,
                    Type = field.Type
                }).ToList(),
                Participant = new Participants
                {
                    EmailRequester = step.Participant.EmailRequester,
                    EmailValidator = step.Participant.EmailValidator,
                    EmailDT = step.Participant.EmailDT
                },
                PossibleActions = step.PossibleActions.Select(action => new DataAccess.Models.Action
                {
                    Id = action.Id,
                    Name = action.Name,
                    Description = action.Description
                }).ToList()
            };

            return await _stepRepository.CreateStepAsync(newStep);
        }

    }
}
