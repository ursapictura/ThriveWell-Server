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

        public Task<Trigger> PostTriggerAsync(AddTriggerDTO triggerDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Trigger> UpdateTriggerAsync(int id, AddTriggerDTO triggerDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Trigger> DeleteTriggerAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}