using ThriveWell.API.Models;

namespace ThriveWell.Api.Data
{
    public class SymptomTriggerData
    {
        public static List<SymptomTrigger> symptomTriggers = new()
        {
        // For Uid = "NSkdshfjdfajdsh97834"
        new() { Id = 1, SymptomLogId = 1, SymptomSeverity = 3, TriggerId = 1 }, // "Cold Weather"
        new() { Id = 2, SymptomLogId = 2, SymptomSeverity = 2, TriggerId = 6 }, // "Stress"
        new() { Id = 3, SymptomLogId = 3, SymptomSeverity = 4, TriggerId = 5 }, // "Infection/Illness"
        new() { Id = 4, SymptomLogId = 4, SymptomSeverity = 2, TriggerId = 14 }, // "Dehydration"
        new() { Id = 5, SymptomLogId = 5, SymptomSeverity = 3, TriggerId = 4 }, // "Overexertion"
        new() { Id = 6, SymptomLogId = 6, SymptomSeverity = 1, TriggerId = 3 }, // "Lack of Sleep"
        new() { Id = 7, SymptomLogId = 7, SymptomSeverity = 4, TriggerId = 6 }, // "Stress"
        new() { Id = 8, SymptomLogId = 8, SymptomSeverity = 2, TriggerId = 2 }, // "Hot Weather"
        new() { Id = 9, SymptomLogId = 9, SymptomSeverity = 3, TriggerId = 4 }, // "Overexertion"
        new() { Id = 10, SymptomLogId = 10, SymptomSeverity = 3, TriggerId = 14 }, // "Dehydration"
        new() { Id = 11, SymptomLogId = 11, SymptomSeverity = 1, TriggerId = 13 }, // "Nightshades"
        new() { Id = 12, SymptomLogId = 12, SymptomSeverity = 2, TriggerId = 6 }, // "Stress"
        new() { Id = 13, SymptomLogId = 13, SymptomSeverity = 4, TriggerId = 5 }, // "Infection/Illness"
        new() { Id = 14, SymptomLogId = 14, SymptomSeverity = 3, TriggerId = 8 }, // "Flu Vaccination"
        new() { Id = 15, SymptomLogId = 15, SymptomSeverity = 3, TriggerId = 7 }, // "Physical Injury"
        new() { Id = 16, SymptomLogId = 16, SymptomSeverity = 2, TriggerId = 15 }, // "Caffeine"
        new() { Id = 17, SymptomLogId = 17, SymptomSeverity = 4, TriggerId = 6 }, // "Stress"
        new() { Id = 18, SymptomLogId = 18, SymptomSeverity = 3, TriggerId = 5 }, // "Infection/Illness"
        new() { Id = 19, SymptomLogId = 19, SymptomSeverity = 2, TriggerId = 14 }, // "Dehydration"
        new() { Id = 20, SymptomLogId = 20, SymptomSeverity = 3, TriggerId = 1 }, // "Cold Weather"

        // For Uid = "KJHKBdskdaksjde9458v"
        new() { Id = 21, SymptomLogId = 21, SymptomSeverity = 3, TriggerId = 16 }, // "New Laundry Detergent"
        new() { Id = 22, SymptomLogId = 22, SymptomSeverity = 2, TriggerId = 17 }, // "New Lotion/Skincare Products"
        new() { Id = 23, SymptomLogId = 23, SymptomSeverity = 4, TriggerId = 19 }, // "Alcohol Consumption"
        new() { Id = 24, SymptomLogId = 24, SymptomSeverity = 3, TriggerId = 18 }, // "Lack of Exercise"
        new() { Id = 25, SymptomLogId = 25, SymptomSeverity = 1, TriggerId = 20 }, // "Smoking"
        new() { Id = 26, SymptomLogId = 26, SymptomSeverity = 2, TriggerId = 16 }, // "New Laundry Detergent"
        new() { Id = 27, SymptomLogId = 27, SymptomSeverity = 3, TriggerId = 19 }, // "Alcohol Consumption"
        new() { Id = 28, SymptomLogId = 28, SymptomSeverity = 4, TriggerId = 18 }, // "Lack of Exercise"
        new() { Id = 29, SymptomLogId = 29, SymptomSeverity = 2, TriggerId = 20 }, // "Smoking"
        new() { Id = 30, SymptomLogId = 30, SymptomSeverity = 3, TriggerId = 16 }  // "New Laundry Detergent"
        };
    }
}