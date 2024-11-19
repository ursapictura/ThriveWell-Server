using Microsoft.EntityFrameworkCore;
using ThriveWell.API.DTOs;
using ThriveWell.API.Interfaces;
using ThriveWell.API.Models;
using ThriveWell.API.Data;

namespace ThriveWell.API.Repositories
{
    public class ThriveWellSymptomTriggerRepository : IThriveWellSymptomTriggerRepository
    {

        private readonly ThriveWellDbContext _context;

        public ThriveWellSymptomTriggerRepository(ThriveWellDbContext context)
        {
            _context = context;
        }

        public Task<SymptomTrigger> PostSymptomTriggerAsync(AddSymptomTriggerDTO symptomTriggerDTO)
        {
            throw new NotImplementedException();
        }

        public Task<SymptomTrigger> DeleteSymptomTriggerAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}