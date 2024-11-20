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

        public async Task<List<Symptom>> GetAllSymptomsAsync(string uid)
        {
            return await _context.Symptoms.OrderBy(s => s.Name).Where(s => s.Uid == uid).ToListAsync();
        }

        public async Task<Symptom> GetSymptomByIdAsync(int id)
        {
            return await _context.Symptoms.SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Symptom> PostSymptomAsync(AddSymptomDTO symptomDTO)
        {
            Symptom newSymptom = new()
            {
                Name = symptomDTO.Name,
                Uid = symptomDTO.Uid,
            };

            _context.Symptoms.Add(newSymptom);
            await _context.SaveChangesAsync();
            return newSymptom;
        }

        public async Task<Symptom> UpdateSymptomAsync(int id, AddSymptomDTO symptomDTO)
        {
            Symptom updatedSymptom = await _context.Symptoms.SingleOrDefaultAsync(s => s.Id == id);

            if (updatedSymptom == null)
            {
                return null;
            }

            updatedSymptom.Name = symptomDTO.Name;
            updatedSymptom.Uid = symptomDTO.Uid;

            await _context.SaveChangesAsync();
            return updatedSymptom;
        }

        public async Task<Symptom> DeleteSymptomAsync(int id)
        {
            Symptom symptom = await _context.Symptoms.FirstOrDefaultAsync(s => s.Id == id);

            if (symptom == null)
            {
                return null;
            }

            _context.Symptoms.Remove(symptom);
            await _context.SaveChangesAsync();
            return symptom;
        }
    }
}