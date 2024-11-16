using ThriveWell.API.Models;

namespace ThriveWell.Api.Data
{
    public class SymptomLogData
    {
        public static List<SymptomLog> SymptomLogs = new()
        {
            new() {Id = 1, Date = new DateOnly(2024, 11, 15), SymptomId =  1, Severity = 3, Uid = "NSkdshfjdfajdsh97834"},
            new() {Id = 2, Date = new DateOnly(2024, 11, 16), SymptomId =  2, Severity = 2, Uid = "NSkdshfjdfajdsh97834"},
            new() {Id = 3, Date = new DateOnly(2024, 11, 16), SymptomId =  1, Severity = 4, Uid = "NSkdshfjdfajdsh97834"},
            new() {Id = 4, Date = new DateOnly(2024, 11, 16), SymptomId =  4, Severity = 1, Uid = "NSkdshfjdfajdsh97834"},
            new() {Id = 5, Date = new DateOnly(2024, 11, 16), SymptomId =  3, Severity = 5, Uid = "KJHKBdskdaksjde9458v"},
        };
    }
}