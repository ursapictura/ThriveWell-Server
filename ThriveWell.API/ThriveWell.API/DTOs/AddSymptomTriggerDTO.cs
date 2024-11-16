namespace ThriveWell.API.DTOs
{
	public class AddSymptomTriggerDTO
	{
		public int Id { get; set; }
		public int SymptomLogId { get; set; }
		public int SymptomSeverity { get; set; }
		public int TriggerId { get; set; }
	}
}