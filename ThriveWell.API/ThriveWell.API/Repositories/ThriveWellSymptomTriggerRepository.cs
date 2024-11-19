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

        public async Task<SymptomTrigger> PostSymptomTriggerAsync(AddSymptomTriggerDTO symptomTriggerDTO)
        {
            SymptomTrigger newSymptomTrigger = new()
            {
                SymptomLogId = symptomTriggerDTO.SymptomLogId,
                SymptomSeverity = symptomTriggerDTO.SymptomSeverity,
                TriggerId = symptomTriggerDTO.TriggerId,
            };

            _context.SymptomTriggers.Add(newSymptomTrigger);
            await _context.SaveChangesAsync(); 
            return newSymptomTrigger;
        }

        public async Task<SymptomTrigger> DeleteSymptomTriggerAsync(int id)
        {
            SymptomTrigger symptomTrigger = await _context.SymptomTriggers.SingleOrDefaultAsync(st => st.Id == id);

            if (symptomTrigger == null)
            {
                return null;
            };

            _context.SymptomTriggers.Remove(symptomTrigger);
            await _context.SaveChanges();
            return symptomTrigger;
        }
    }
}