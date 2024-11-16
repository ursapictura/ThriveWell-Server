using ThriveWell.API.Models;
using ThriveWell.API.DTOs;

namespace ThriveWell.API.Interfaces
{
    public interface IThriveWellSymptomTriggerService
    {
        Task<SymptomTrigger> PostSymptomTriggerAsync(AddSymptomTriggerDTO symptomTriggerDTO);
        Task<SymptomTrigger> DeleteSymptomTriggerAsync(int id);
    }
}