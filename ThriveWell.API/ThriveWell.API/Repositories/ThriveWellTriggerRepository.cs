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

        public Task<Trigger> DeleteTriggerAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Trigger>> GetAllTriggersAsync(string uid)
        {
            throw new NotImplementedException();
        }

        public Task<Trigger> GetTriggerByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Trigger> PostTriggerAsync(AddTriggerDTO triggerDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Trigger> UpdateTriggerAsync(int id, AddTriggerDTO triggerDTO)
        {
            throw new NotImplementedException();
        }
    }
}