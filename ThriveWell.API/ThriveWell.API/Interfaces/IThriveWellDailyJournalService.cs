using ThriveWell.API.Models;
using ThriveWell.API.DTOs;

namespace ThriveWell.API.Interfaces
{
    public interface IThriveWellDailyJournalService
    {
        Task<List<DailyJournal>> GetAllDailyJournalsAsync(string uid);
        Task<DailyJournal> GetDailyJournalByIdAsync(int id);
        Task<DailyJournal> PostDailyJournalAsync(AddDailyJournalDTO dailyJournalDTO);
        Task<DailyJournal> UpdateDailyJournalAsnyc(int id, AddDailyJournalDTO dailyJournalDTO);
        Task<DailyJournal> DeleteDailyJournalAsync(int id);
    }
}