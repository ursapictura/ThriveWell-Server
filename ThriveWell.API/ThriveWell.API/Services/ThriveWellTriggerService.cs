using ThriveWell.API.Interfaces;
using ThriveWell.API.Models;
using ThriveWell.API.DTOs;

namespace ThriveWell.API.Sevices
{
    public class ThriveWellTriggerService : IThriveWellTriggerService
    {
        private readonly IThriveWellTriggerRepository _triggerRepo;

        public ThriveWellTriggerService(IThriveWellTriggerRepository triggerRepo)
        {
            _triggerRepo = triggerRepo;
        }

        public async Task<List<Trigger>> GetAllTriggersAsync(string uid)
        {
            return await _triggerRepo.GetAllTriggersAsync(uid);
        }

        public async Task<Trigger> GetTriggerByIdAsync(int id)
        {
            return await _triggerRepo.GetTriggerByIdAsync(id);
        }

        public async Task<Trigger> PostTriggerAsync(AddTriggerDTO triggerDTO)
        {
            return await _triggerRepo.PostTriggerAsync(triggerDTO);
        }

        public async Task<Trigger> UpdateTriggerAsync(int id, AddTriggerDTO triggerDTO)
        {
            return await _triggerRepo.UpdateTriggerAsync(id, triggerDTO);
        }

        public async Task<Trigger> DeleteTriggerAsync(int id)
        {
            return await _triggerRepo.DeleteTriggerAsync(id);
        }
    }
}