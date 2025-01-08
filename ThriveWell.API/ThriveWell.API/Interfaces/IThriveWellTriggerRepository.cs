using ThriveWell.API.Models;
using ThriveWell.API.DTOs;

namespace ThriveWell.API.Interfaces
{
    public interface IThriveWellTriggerRepository
    {
        Task<List<Trigger>> GetAllTriggersAsync(string uid);
        Task<List<TopTriggersDTO>> GetTopFiveTriggersAsync(string uid);
        Task<Trigger> GetTriggerByIdAsync(int id);
        Task<Trigger> PostTriggerAsync(AddTriggerDTO triggerDTO);
        Task<Trigger> UpdateTriggerAsync(int id, AddTriggerDTO triggerDTO);
        Task<Trigger> DeleteTriggerAsync(int id);
    }
}