namespace ThriveWell.API.Models
{
    public class SymtpomTrigger
    {
        public int Id { get; set; }
        public int SymptomLogId { get; set; }
        public int SymptomSeverity { get; set; }
        public int TriggerId { get; set; }
    }
}