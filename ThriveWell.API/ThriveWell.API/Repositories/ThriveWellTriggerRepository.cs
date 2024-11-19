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