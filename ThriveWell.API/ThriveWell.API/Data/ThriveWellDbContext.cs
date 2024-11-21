using Microsoft.EntityFrameworkCore;
using ThriveWell.Api.Data;
using ThriveWell.API.Models;

namespace ThriveWell.API.Data
{
    public class ThriveWellDbContext : DbContext
    {
        public DbSet<DailyJournal> DailyJournals { get; set; }
        public DbSet<SymptomLog> SymptomLogs { get; set;}
        public DbSet<Symptom> Symptoms { get; set; }
        public DbSet<Trigger> Triggers { get; set; }
        public DbSet<SymptomTrigger> SymptomTriggers { get; set;}

        public ThriveWellDbContext(DbContextOptions<ThriveWellDbContext> context) : base(context) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}