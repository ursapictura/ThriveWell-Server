using ThriveWell.API.Models;

namespace ThriveWell.API.DTOs
{
    public class TopTriggersDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Total { get; set; }
        public double Percentage { get; set; }
        public double SeverityAverage { get; set; }
    }
}
