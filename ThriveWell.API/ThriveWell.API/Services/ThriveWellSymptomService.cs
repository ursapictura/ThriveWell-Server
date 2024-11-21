using ThriveWell.API.Interfaces;
using ThriveWell.API.Models;
using ThriveWell.API.DTOs;

namespace ThriveWell.API.Sevices
{
    public class ThriveWellSymptomService : IThriveWellSymptomService
    {
        private readonly IThriveWellSymptomRepository _symptomRepo;

        public ThriveWellSymptomService(IThriveWellSymptomRepository symptomRepo)
        {
            _symptomRepo = symptomRepo;
        }

        public async Task<Symptom> DeleteSymptomAsync(int id)
        {
            return await _symptomRepo.DeleteSymptomAsync(id);
        }

        public async Task<List<Symptom>> GetAllSymptomsAsync(string uid)
        {
            return await _symptomRepo.GetAllSymptomsAsync(uid);
        }

        public async Task<Symptom> GetSymptomByIdAsync(int id)
        {
            return await _symptomRepo.GetSymptomByIdAsync(id);
        }

        public async Task<Symptom> PostSymptomAsync(AddSymtpomDTO symptomDTO)
        {
            return await _symptomRepo.PostSymptomAsync(symptomDTO);
        }

        public async Task<Symptom> UpdateSymptomAsync(int id, AddSymtpomDTO symtpomDTO)
        {
            return await _symptomRepo.UpdateSymptomAsync(id, symtpomDTO);
        }
    }
}