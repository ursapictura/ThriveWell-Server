namespace ThriveWell.API.Models
{
    public class DailyJournal
    {
        public int Id { get; set; }
        public string? Entry { get; set; }
        public DateOnly Date { get; set; }
        public int? SeverityAverage { get; set; }
        public string Uid { get; set; }
    }
}