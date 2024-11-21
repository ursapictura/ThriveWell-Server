using Microsoft.EntityFrameworkCore;
using ThriveWell.API.DTOs;
using ThriveWell.API.Interfaces;
using ThriveWell.API.Models;
using ThriveWell.API.Data;

namespace ThriveWell.API.Respositories
{
    public class ThriveWellSymptomLogRespository : IThriveWellSymptomLogRepository
    {

        private readonly ThriveWellDbContext _context;

        public ThriveWellSymptomLogRespository(ThriveWellDbContext context)
        {
            _context = context;
        }

        public async Task<SymptomLog> DeleteSymptomLogAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<SymptomLog> GetSymptomByIdLogAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SymptomLog>> GetAllSymptomLogsAsync(string uid)
        {
            throw new NotImplementedException();
        }

        public async Task<SymptomLog> PostSymtpomLogAsync(AddSymptomLogDTO symptomLogDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<SymptomLog> UpdateSymptomLogAsync(int id, AddSymptomLogDTO symptomLogDTO)
        {
            throw new NotImplementedException();
        }
    }
}