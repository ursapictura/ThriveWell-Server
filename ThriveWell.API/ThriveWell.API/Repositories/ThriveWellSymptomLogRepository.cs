using Microsoft.EntityFrameworkCore;
using ThriveWell.API.DTOs;
using ThriveWell.API.Interfaces;
using ThriveWell.API.Models;
using ThriveWell.API.Data;

namespace ThriveWell.API.Respositories
{
    public class ThriveWellSymptomLogRepository : IThriveWellSymptomLogRepository
    {

        private readonly ThriveWellDbContext _context;

        public ThriveWellSymptomLogRepository(ThriveWellDbContext context)
        {
            _context = context;
        }

        public async Task<List<SymptomLog>> GetAllSymptomLogsAsync(string uid)
        {
            return await _context.SymptomLogs
                .Where(sl => sl.Uid == uid)
                .Include(sl => sl.Symptom)
                .Include(sl => sl.SymptomTrigger)
                .ThenInclude(st => st.Trigger)
                .OrderByDescending(sl => sl.Date)
                .ToListAsync();
        }

        public async Task<SymptomLog> GetSymptomLogByIdAsync(int id)
        {
            var symptomLogs = await _context.SymptomLogs
               .Include(sl => sl.Symptom)
               .Include(sl => sl.SymptomTrigger)
               .ThenInclude(st => st.Trigger)
               .SingleOrDefaultAsync(sl => sl.Id == id);

            if (symptomLogs == null)
            {
                return null;
            }

            return symptomLogs;
        }

        public async Task<List<SymptomLog>> GetSymptomLogsByDateAsync(string uid, int year, int month, int day)
        {
            return await _context.SymptomLogs
                 .Where(sl => sl.Uid == uid && sl.Date.Year == year && sl.Date.Month == month && sl.Date.Day == day)
                 .Include(sl => sl.Symptom)
                 .Include(sl => sl.SymptomTrigger)
                 .ThenInclude(st => st.Trigger)
                 .ToListAsync();
        }

        public async Task<SymptomLog> PostSymtpomLogAsync(AddSymptomLogDTO symptomLogDTO)
        {
            if (symptomLogDTO.Severity < 1 || symptomLogDTO.Severity > 5)
            {
                return null;
            }

            SymptomLog symptomLog = new()
            {
                Date = symptomLogDTO.Date,
                SymptomId = symptomLogDTO.SymptomId,
                Severity = symptomLogDTO.Severity,
                Uid = symptomLogDTO.Uid,
            };

            _context.SymptomLogs.Add(symptomLog);
            await _context.SaveChangesAsync();
            return symptomLog;
        }

        public async Task<SymptomLog> UpdateSymptomLogAsync(int id, AddSymptomLogDTO symptomLogDTO)
        {
            SymptomLog updatedSymptomLog = await _context.SymptomLogs.SingleOrDefaultAsync(sl => sl.Id == id);

            if (updatedSymptomLog == null)
            {
                return null;
            }

            if (symptomLogDTO.Severity < 1 || symptomLogDTO.Severity > 5)
            {
                return null;
            }

            updatedSymptomLog.Date = symptomLogDTO.Date;
            updatedSymptomLog.SymptomId = symptomLogDTO.SymptomId;
            updatedSymptomLog.Severity = symptomLogDTO.Severity;
            updatedSymptomLog.Uid = symptomLogDTO.Uid;

            await _context.SaveChangesAsync();
            return updatedSymptomLog;

        }

        public async Task<SymptomLog> DeleteSymptomLogAsync(int id)
        {
            SymptomLog symptomLog = await _context.SymptomLogs.SingleOrDefaultAsync(sl => sl.Id == id);

            if (symptomLog == null)
            {
                return null;
            }

            _context.SymptomLogs.Remove(symptomLog);
            await _context.SaveChangesAsync();
            return symptomLog;
        }
    }
}