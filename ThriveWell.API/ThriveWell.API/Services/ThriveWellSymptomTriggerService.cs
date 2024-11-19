using ThriveWell.API.Interfaces;
using ThriveWell.API.Models;
using ThriveWell.API.DTOs;

namespace ThriveWell.API.Sevices
{
    public class ThriveWellSymptomTriggerService : IThriveWellSymptomTriggerService
    {
        private readonly IThriveWellSymptomTriggerRepository _symptomTriggerRepo;

        public ThriveWellSymptomTriggerService(IThriveWellSymptomTriggerRepository symptomTriggerRepo)
        {
            _symptomTriggerRepo = symptomTriggerRepo;
        }

        public async Task<SymptomTrigger> PostSymptomTriggerAsync(AddSymptomTriggerDTO symptomTriggerDTO)
        {
            return await _symptomTriggerRepo.PostSymptomTriggerAsync(symptomTriggerDTO);
        }

        public async Task<SymptomTrigger> DeleteSymptomTriggerAsync(int id)
        {
            return await _symptomTriggerRepo.DeleteSymptomTriggerAsync(id);
        }
    }
}