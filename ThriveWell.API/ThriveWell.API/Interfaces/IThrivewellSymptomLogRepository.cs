using ThriveWell.API.Models;
using ThriveWell.API.DTOs;

namespace ThriveWell.API.Interfaces
{
    public interface IThriveWellSymptomLogRepository
    {
        Task<List<SymptomLog>> GetAllSymptomLogsAsync(string uid);
        Task<SymptomLog> GetSymptomLogByIdAsync(int id);
        Task<List<SymptomLog>> GetSymptomLogsByDateAsync(string uid, int year, int month, int day);
        Task<SymptomLog> PostSymtpomLogAsync(AddSymptomLogDTO symptomLogDTO);
        Task<SymptomLog> UpdateSymptomLogAsync(int id, AddSymptomLogDTO symptomLogDTO);
        Task<SymptomLog> DeleteSymptomLogAsync(int id);
    }
}