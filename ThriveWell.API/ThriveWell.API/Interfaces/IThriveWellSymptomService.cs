using ThriveWell.API.Models;
using ThriveWell.API.DTOs;

namespace ThriveWell.API.Interfaces
{
    public interface IThriveWellSymptomService
    {
        Task<List<Symptom>> GetAllSymptomsAsync(string uid);
        Task<Symptom> GetSymptomByIdAsync(int id);
        Task<Symptom> PostSymptomAsync(AddSymtpomDTO symptomDTO);
        Task<Symptom> UpdateSymptomAsync(int id, AddSymtpomDTO symtpomDTO);
        Task<Symptom> DeleteSymptomAsync(int id);
    }
}