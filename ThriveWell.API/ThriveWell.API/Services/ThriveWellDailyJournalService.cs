using ThriveWell.API.Interfaces;
using ThriveWell.API.Models;
using ThriveWell.API.DTOs;

namespace ThriveWell.API.Sevices
{
    public class ThriveWellDailyJournalService : IThriveWellDailyJournalService
    {
        private readonly IThriveWellDailyJournalRepository _dailyJournalServiceRepo;

        public ThriveWellDailyJournalService(IThriveWellDailyJournalRepository dailyJournalServiceRepo)
        {
            _dailyJournalServiceRepo = dailyJournalServiceRepo;
        }

        public Task<List<DailyJournal>> GetAllDailyJournalsAsync(string uid)
        {
            throw new NotImplementedException();
        }

        public async Task<DailyJournal> GetDailyJournalByIdAsync(int id)
        {
            return await _dailyJournalServiceRepo.GetDailyJournalByIdAsync(id);
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