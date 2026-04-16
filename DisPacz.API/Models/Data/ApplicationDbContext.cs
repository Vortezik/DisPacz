using Microsoft.EntityFrameworkCore;

namespace DisPacz.API.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Dispatch> Dispatches { get; set; }
        public DbSet<JobWorker> JobWorkers { get; set; }
        public DbSet<JobEquipment> JobEquipments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Job>()
                .HasOne(j => j.Client)
                .WithMany(c => c.Jobs)
                .HasForeignKey(j => j.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Job>()
                .HasOne(j => j.Location)
                .WithMany(l => l.Jobs)
                .HasForeignKey(j => j.LocationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Dispatch>()
                .HasOne(d => d.Job)
                .WithMany()
                .HasForeignKey(d => d.JobId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Dispatch>()
                .HasOne(d => d.Worker)
                .WithMany()
                .HasForeignKey(d => d.WorkerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<JobWorker>()
                .HasKey(jw => new { jw.JobId, jw.WorkerId });

            modelBuilder.Entity<JobWorker>()
                .HasOne(jw => jw.Job)
                .WithMany()
                .HasForeignKey(jw => jw.JobId);

            modelBuilder.Entity<JobWorker>()
                .HasOne(jw => jw.Worker)
                .WithMany(w => w.JobWorkers)
                .HasForeignKey(jw => jw.WorkerId);

            modelBuilder.Entity<JobEquipment>()
                .HasKey(je => new { je.JobId, je.EquipmentId });

            modelBuilder.Entity<JobEquipment>()
                .HasOne(je => je.Job)
                .WithMany()
                .HasForeignKey(je => je.JobId);

            modelBuilder.Entity<JobEquipment>()
                .HasOne(je => je.Equipment)
                .WithMany(e => e.JobEquipments)
                .HasForeignKey(je => je.EquipmentId);
        }
    }
}
