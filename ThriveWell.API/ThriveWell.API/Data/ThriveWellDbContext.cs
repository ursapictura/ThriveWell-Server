using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
            modelBuilder.Entity<DailyJournal>().HasData(DailyJournalData.DailyJournals);
            modelBuilder.Entity<SymptomLog>().HasData(SymptomLogData.SymptomLogs);
            modelBuilder.Entity<Symptom>().HasData(SymptomData.Symptoms);
            modelBuilder.Entity<Trigger>().HasData(TriggerData.Triggers);
            modelBuilder.Entity<SymptomTrigger>().HasData(SymptomTriggerData.SymptomTriggers);

            modelBuilder.Entity<SymptomLog>()
                .HasMany(sl => sl.SymptomTrigger)
                .WithOne(st => st.SymptomLog)
                .HasForeignKey(st => st.SymptomLogId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}