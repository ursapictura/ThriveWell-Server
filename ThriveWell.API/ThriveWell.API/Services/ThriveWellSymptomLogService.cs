using ThriveWell.API.Interfaces;
using ThriveWell.API.Models;
using ThriveWell.API.DTOs;

namespace ThriveWell.API.Sevices
{
    public class ThriveWellSymptomLogService : IThriveWellSymptomLogService
    {
        private readonly IThriveWellSymptomLogRepository _symptomLogRepo;

        public ThriveWellSymptomLogService(IThriveWellSymptomLogRepository symptomLogRepo)
        {
            _symptomLogRepo = symptomLogRepo;
        }

        public async Task<List<SymptomLog>> GetAllSymptomLogsAsync(string uid)
        {
            return await _symptomLogRepo.GetAllSymptomLogsAsync(uid);
        }

        public async Task<SymptomLog> GetSymptomLogByIdAsync(int id)
        {
            return await _symptomLogRepo.GetSymptomLogByIdAsync(id);
        }
        public async Task<List<SymptomLog>> GetSymptomLogsByDateAsync(string uid, int year, int month, int day)
        {
            return await _symptomLogRepo.GetSymptomLogsByDateAsync(uid, year, month, day);
        }

        public async Task<SymptomLog> PostSymtpomLogAsync(AddSymptomLogDTO symptomLogDTO)
        {
            return await _symptomLogRepo.PostSymtpomLogAsync(symptomLogDTO);
        }

        public async Task<SymptomLog> UpdateSymptomLogAsync(int id, AddSymptomLogDTO symptomLogDTO)
        {
            return await _symptomLogRepo.UpdateSymptomLogAsync(id, symptomLogDTO);
        }

        public async Task<SymptomLog> DeleteSymptomLogAsync(int id)
        {
            return await _symptomLogRepo.DeleteSymptomLogAsync(id);
        }
    }
}