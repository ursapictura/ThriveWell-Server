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
            var deleteDailyJournal = await _context.DailyJournals.FirstOrDefaultAsync(dj => dj.Id == id);
            if (deleteDailyJournal == null)
            {
                return null;
            }
            _context.DailyJournals.Remove(deleteDailyJournal);
            await _context.SaveChangesAsync();
            return deleteDailyJournal;
        }

        public async Task<DailyJournal> GetDailyJournalByIdAsync(int id)
        {
            return await _context.DailyJournals.FirstOrDefaultAsync(dj => dj.Id == id);
        }

        public async Task<List<DailyJournal>> GetAllDailyJournalsAsync(string uid)
        {
            return await _context.DailyJournals.Where(dj => dj.Uid == uid).ToListAsync();
        }

        public async Task<DailyJournal> PostDailyJournalAsync(AddDailyJournalDTO dailyJournalDTO)
        {
            var newDailyJournal = new DailyJournal
            {
                Id = dailyJournalDTO.Id,
                Entry = dailyJournalDTO.Entry,
                Date = dailyJournalDTO.Date,
                Uid = dailyJournalDTO.Uid,
            };

            _context.DailyJournals.Add(newDailyJournal);
            await _context.SaveChangesAsync();
            return newDailyJournal;
        }

        public async Task<DailyJournal> UpdateDailyJournalAsnyc(int id, AddDailyJournalDTO dailyJournalDTO)
        {
            var dailyJournalToUpdate = await _context.DailyJournals.FirstOrDefaultAsync(dj => dj.Id == id);

            if (dailyJournalToUpdate == null)
            {
                return null;
            }

            dailyJournalToUpdate.Entry = dailyJournalDTO.Entry;
            dailyJournalToUpdate.Date = dailyJournalDTO.Date;
            dailyJournalToUpdate.Uid = dailyJournalDTO.Uid;

            await _context.SaveChangesAsync();
            return dailyJournalToUpdate;
        }
    }
}