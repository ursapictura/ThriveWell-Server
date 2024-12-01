using ThriveWell.API.Interfaces;
using ThriveWell.API.Models;
using ThriveWell.API.DTOs;
using Microsoft.EntityFrameworkCore;
using ThriveWell.Api.Data;

namespace ThriveWell.API.Sevices
{
    public class ThriveWellDailyJournalService : IThriveWellDailyJournalService
    {
        private readonly IThriveWellDailyJournalRepository _dailyJournalServiceRepo;
        private readonly IThriveWellSymptomLogRepository _symptomLogServiceRepo;

        public ThriveWellDailyJournalService(IThriveWellDailyJournalRepository dailyJournalServiceRepo, IThriveWellSymptomLogRepository symptomLogServiceRepo)
        {
            _dailyJournalServiceRepo = dailyJournalServiceRepo;
            _symptomLogServiceRepo = symptomLogServiceRepo;
        }

        public async Task<List<DailyJournalDTO>> GetAllDailyJournalsAsync(string uid)
        {
            // return await _dailyJournalServiceRepo.GetAllDailyJournalsAsync(uid);

            List<DailyJournal>? dailyJournals = await _dailyJournalServiceRepo.GetAllDailyJournalsAsync(uid);
            
            if (dailyJournals == null)
            {
                return null;
            };

            List<SymptomLog>? symptomLogs = await _symptomLogServiceRepo.GetAllSymptomLogsAsync(uid);

            if (symptomLogs  == null)
            {
                return dailyJournals.Select(dj => new DailyJournalDTO
                {
                    Id = dj.Id,
                    Entry = dj.Entry,
                    Date = dj.Date,
                    Uid = dj.Uid,
                    SeverityAverage = 0,
                })
                .ToList();
            }

            var journalsWithSeverity = dailyJournals
                .GroupJoin(symptomLogs,
                    dj => new { dj.Uid, dj.Date },
                    sl => new { sl.Uid, sl.Date },
                    (dj, symptomLogs) => new { dj, symptomLogs }) // Left join with SymptomLogs
                .SelectMany(
                    x => x.symptomLogs.DefaultIfEmpty(),
                    (x, sl) => new { x.dj, sl }) // Flatten the grouped results
                .GroupBy(
                    x => new { x.dj.Id, x.dj.Entry, x.dj.Date, x.dj.Uid },
                    x => x.sl) // Group by journal information
                .Select(g => new DailyJournalDTO
                {
                    Id = g.Key.Id,
                    Entry = g.Key.Entry,
                    Date = g.Key.Date,
                    Uid = g.Key.Uid,
                    SeverityAverage = g.Average(x => x?.Severity ?? 0) // Calculate average severity
                })
                .ToList();

            return journalsWithSeverity;

        }

        public async Task<DailyJournalDTO> GetDailyJournalByIdAsync(int id)
        {
            // return await _dailyJournalServiceRepo.GetDailyJournalByIdAsync(id);
            DailyJournal dailyJournal = await _dailyJournalServiceRepo.GetDailyJournalByIdAsync(id);

            if (dailyJournal == null)
            {
                return null;
            }

            var journalDTO = new DailyJournalDTO
            {
                Id = dailyJournal.Id,
                Entry = dailyJournal.Entry,
                Date = new DateOnly(dailyJournal.Date.Year, dailyJournal.Date.Month, dailyJournal.Date.Day),
                Uid = dailyJournal.Uid,
                SeverityAverage = 0,
            };

            List<SymptomLog>? symptomLogs = await _symptomLogServiceRepo.GetAllSymptomLogsAsync(dailyJournal.Uid);

            if (symptomLogs != null && symptomLogs.Any())
            {
                var matchingLogs = symptomLogs.Where(s => s.Date == dailyJournal.Date).ToList();

                if (matchingLogs.Any())
                {
                    var severityAverage = matchingLogs.Average(sl => sl.Severity);
                    journalDTO.SeverityAverage = severityAverage; // Add average severity for SymptomLogs sharing same Uid and Date
                }
                else
                {
                    journalDTO.SeverityAverage = 0; // No matching logs for the date, so set it to 0
                }
            }


            return journalDTO;

        }

        public async Task<DailyJournal> PostDailyJournalAsync(AddDailyJournalDTO dailyJournalDTO)
        {
            return await _dailyJournalServiceRepo.PostDailyJournalAsync(dailyJournalDTO);
        }

        public async Task<DailyJournal> UpdateDailyJournalAsnyc(int id, AddDailyJournalDTO dailyJournalDTO)
        {
            return await _dailyJournalServiceRepo.UpdateDailyJournalAsnyc(id, dailyJournalDTO);
        }

        public async Task<DailyJournal> DeleteDailyJournalAsync(int id)
        {
            return await _dailyJournalServiceRepo.DeleteDailyJournalAsync(id);
        }
    }
}