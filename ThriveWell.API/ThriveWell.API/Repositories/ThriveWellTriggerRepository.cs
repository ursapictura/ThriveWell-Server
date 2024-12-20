using Microsoft.EntityFrameworkCore;
using ThriveWell.API.DTOs;
using ThriveWell.API.Interfaces;
using ThriveWell.API.Models;
using ThriveWell.API.Data;

namespace ThriveWell.API.Repositories
{
    public class ThriveWellTriggerRepository : IThriveWellTriggerRepository
    {

        private readonly ThriveWellDbContext _context;

        public ThriveWellTriggerRepository(ThriveWellDbContext context)
        {
            _context = context;
        }

        public async Task<List<Trigger>> GetAllTriggersAsync(string uid)
        {
            return await _context.Triggers.OrderBy(t => t.Name).Where(t => t.Uid == uid).ToListAsync();
        }

        public async Task<List<TopTriggersDTO>> GetTopFiveTriggersAsync(string uid)
        {
            // calculate date for thirty days before today
            var endDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-30));

            // Get all user SymptomTriggers from last thiry days, include Trigger entity in object
            var triggers = await _context.SymptomTriggers.Where(st => st.Trigger.Uid == uid && st.SymptomLog.Date >= endDate).Include(st => st.Trigger).ToListAsync();

            Console.WriteLine(triggers);

            if (triggers != null && triggers.Any())
            {
                // Calculate the total number of triggers
                var totalTriggersCount = triggers.Count;

                // Group by trigger, count occurrences, and calculate the percentage and SymptomSeverity average across the trigger's associated SymptomTriggers
                var topFiveTriggers = triggers
                    .GroupBy(st => st.Trigger)
                    .Select(group => new TopTriggersDTO
                    {
                        Id = group.Key.Id,
                        Name = group.Key.Name,
                        Total = group.Count(),
                        Percentage = totalTriggersCount > 0
                            ? (double)group.Count() / totalTriggersCount * 100 // Calculate percentage of times each trigger appears in symptom triggers ovver the last thirty days
                            : 0,
                        SeverityAverage = group.Average(st => st.SymptomSeverity)  // Calculate the average symptom severity for each trigger
                    })
                    .OrderByDescending(g => g.Total)
                    .Take(5)
                    .ToList();

                return topFiveTriggers;
            }

            return null;
        }

        public async Task<Trigger> GetTriggerByIdAsync(int id)
        {
            Trigger trigger = await _context.Triggers.SingleOrDefaultAsync(t => t.Id == id);

            if (trigger == null)
            {
                return null;
            }

            return trigger;
        }

        public async Task<Trigger> PostTriggerAsync(AddTriggerDTO triggerDTO)
        {
            Trigger newTrigger = new Trigger()
            {
                Name = triggerDTO.Name,
                Uid = triggerDTO.Uid,
            };

            _context.Triggers.Add(newTrigger);
            await _context.SaveChangesAsync();
            return newTrigger;
        }

        public async Task<Trigger> UpdateTriggerAsync(int id, AddTriggerDTO triggerDTO)
        {
            Trigger updatedTrigger = await _context.Triggers.SingleOrDefaultAsync(t => t.Id == id);

            if (updatedTrigger == null)
            {
                return null;
            };

            updatedTrigger.Name = triggerDTO.Name;
            updatedTrigger.Uid = triggerDTO.Uid;

            await _context.SaveChangesAsync();
            return updatedTrigger;
        }

        public async Task<Trigger> DeleteTriggerAsync(int id)
        {
            Trigger trigger = await _context.Triggers.SingleOrDefaultAsync(t => t.Id == id);

            if (trigger == null)
            {
                return null;
            };

            _context.Triggers.Remove(trigger);
            await _context.SaveChangesAsync();
            return trigger;
        }
    }
}