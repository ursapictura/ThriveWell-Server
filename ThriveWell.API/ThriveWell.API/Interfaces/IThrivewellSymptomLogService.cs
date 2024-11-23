using ThriveWell.API.Models;
using ThriveWell.API.DTOs;

namespace ThriveWell.API.Interfaces
{
    public interface IThriveWellSymptomLogService
    {
        Task<List<SymptomLog>> GetAllSymptomLogsAsync(string uid);
        Task<SymptomLog> GetSymptomLogByIdAsync(int id);
        Task<SymptomLog> PostSymtpomLogAsync(AddSymptomLogDTO symptomLogDTO);
        Task<SymptomLog> UpdateSymptomLogAsync(int id, AddSymptomLogDTO symptomLogDTO);
        Task<SymptomLog> DeleteSymptomLogAsync(int id);
    }
}