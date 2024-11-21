using ThriveWell.API.Models;
using ThriveWell.API.DTOs;

namespace ThriveWell.API.Interfaces
{
    public interface IThriveWellSymptomRepository
    {
        Task<List<Symptom>> GetAllSymptomsAsync(string uid);
        Task<Symptom> GetSymptomByIdAsync(int id);
        Task<Symptom> PostSymptomAsync(AddSymptomDTO symptomDTO);
        Task<Symptom> UpdateSymptomAsync(int id, AddSymptomDTO symtpomDTO);
        Task<Symptom> DeleteSymptomAsync(int id);
    }
}