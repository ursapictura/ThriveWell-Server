using ThriveWell.API.Models;

namespace ThriveWell.API.DTOs
{
    public class AddSymptomLogDTO
    {
        public DateOnly Date { get; set; }
        public int SymptomId { get; set; }
        public int Severity { get; set; }
        public string Uid { get; set; }
    }
}