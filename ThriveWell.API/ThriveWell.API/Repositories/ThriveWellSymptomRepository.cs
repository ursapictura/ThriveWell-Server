using Microsoft.EntityFrameworkCore;
using ThriveWell.API.DTOs;
using ThriveWell.API.Interfaces;
using ThriveWell.API.Models;
using ThriveWell.API.Data;

namespace ThriveWell.API.Repositories
{
    public class ThriveWellSymptomRepository : IThriveWellSymptomRepository
    {

        private readonly ThriveWellDbContext _context;

        public ThriveWellSymptomRepository(ThriveWellDbContext context)
        {
            _context = context;
        }

        public async Task<Symptom> DeleteSymptomAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Symptom>> GetAllSymptomsAsync(string uid)
        {
            throw new NotImplementedException();
        }

        public async Task<Symptom> GetSymptomByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Symptom> PostSymptomAsync(AddSymtpomDTO symptomDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<Symptom> UpdateSymptomAsync(int id, AddSymtpomDTO symtpomDTO)
        {
            throw new NotImplementedException();
        }
    }
}