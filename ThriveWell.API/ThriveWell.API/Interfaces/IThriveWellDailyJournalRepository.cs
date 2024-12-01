using ThriveWell.API.Models;
using ThriveWell.API.DTOs;

namespace ThriveWell.API.Interfaces
{
    public interface IThriveWellDailyJournalRepository
    {
        Task <List<DailyJournal>> GetAllDailyJournalsAsync(string uid);
        Task<DailyJournal> GetDailyJournalByIdAsync(int id);
        Task<List<DailyJournal>> GetDailyJournalsByMonthAndYearAsync(string uid, int year, int month);
        Task<DailyJournal> PostDailyJournalAsync(AddDailyJournalDTO dailyJournalDTO);
        Task<DailyJournal> UpdateDailyJournalAsnyc(int id, AddDailyJournalDTO dailyJournalDTO);
        Task<DailyJournal> DeleteDailyJournalAsync(int id);
    }
}