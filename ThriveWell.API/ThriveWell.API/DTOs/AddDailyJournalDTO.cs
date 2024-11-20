namespace ThriveWell.API.DTOs
{
    public class AddDailyJournalDTO
    {
        public string? Entry { get; set; }
        public DateOnly Date { get; set; }
        public string Uid { get; set; }
    }
}