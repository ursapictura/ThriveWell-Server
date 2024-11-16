using Microsoft.EntityFrameworkCore;
using ThriveWell.API.DTOs;
using ThriveWell.API.Interfaces;
using ThriveWell.API.Models;
using ThriveWell.API.Data;

namespace ThriveWell.API.Repositories
{
    public class ThriveWellDailyJournalRespository : IThriveWellDailyJournalRepository
    {
        private readonly ThriveWellDbContext _context;

        public ThriveWellDailyJournalRespository(ThriveWellDbContext context)
        {
            _context = context;
        }
        public async Task<DailyJournal> DeleteDailyJournalAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<DailyJournal> GetDailyJournalByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DailyJournal>> GetAllDailyJournalsAsync(string uid)
        {
            throw new NotImplementedException();
        }

        public async Task<DailyJournal> PostDailyJournalAsync(AddDailyJournalDTO dailyJournalDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<DailyJournal> UpdateDailyJournalAsnyc(int id, AddDailyJournalDTO dailyJournalDTO)
        {
            throw new NotImplementedException();
        }
    }
}