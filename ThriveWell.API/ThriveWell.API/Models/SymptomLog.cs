namespace ThriveWell.API.Models
{
    public class SymptomLog
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public int SymptomId { get; set; }
        public Symptom Symptom { get; set; }
        public int Severity { get; set; }
        public List<SymptomTrigger> SymptomTrigger { get; set; } = [];
        public string Uid { get; set; }
    }
}