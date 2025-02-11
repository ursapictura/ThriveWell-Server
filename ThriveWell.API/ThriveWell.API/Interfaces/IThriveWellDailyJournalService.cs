using ThriveWell.API.Models;
using ThriveWell.API.DTOs;

namespace ThriveWell.API.Interfaces
{
    public interface IThriveWellDailyJournalService
    {
        Task<List<DailyJournalDTO>> GetAllDailyJournalsAsync(string uid);
        Task<DailyJournalDTO> GetDailyJournalByIdAsync(int id);
        Task<List<DailyJournalDTO>> GetDailyJournalsByMonthAndYearAsync(string uid, int year, int month);
        Task<DailyJournal> PostDailyJournalAsync(AddDailyJournalDTO dailyJournalDTO);
        Task<DailyJournal> UpdateDailyJournalAsnyc(int id, AddDailyJournalDTO dailyJournalDTO);
        Task<DailyJournal> DeleteDailyJournalAsync(int id);
    }
}