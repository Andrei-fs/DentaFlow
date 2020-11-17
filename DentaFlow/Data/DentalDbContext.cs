using DentaFlow.Models;
using Microsoft.EntityFrameworkCore;

namespace DentaFlow.Data{
    public class DentalDbContext : DbContext
    {
            public DentalDbContext(DbContextOptions<DentalDbContext> opt) :base(opt)
            {
                
            }

            public DbSet<Doctor> Doctors { get; set; }
            
            public DbSet<Pacient> Pacients {get; set;}
            public DbSet<Appointment> Appointments {get; set;}
            public DbSet<DoctorPacient> DoctorsPacients { get; set; }

        /// <summary>
        /// https://dev.to/_patrickgod/many-to-many-relationship-with-entity-framework-core-4059
        /// </summary>
        /// <param name="modelBuilder"></param>

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
            base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<DoctorPacient>()
            .HasKey(dp => new { dp.DoctorId, dp.PacientId });  
            
        modelBuilder.Entity<DoctorPacient>()
            .HasOne(dp => dp.Doctor)
            .WithMany(d => d.DoctorsPacients)
            .HasForeignKey(dp => dp.DoctorId);  

        modelBuilder.Entity<DoctorPacient>()
            .HasOne(dp => dp.Pacient)
            .WithMany(p => p.DoctorsPacients)
            .HasForeignKey(dp => dp.PacientId);
}










            
    //         protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
           
    //     modelBuilder.Entity<Appointment>()
    //          .HasOne<Pacient>()
    //         .WithMany()
    //         .HasForeignKey(p => p.PacientId);

    // }
    //        protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
           
    //     modelBuilder.Entity<Appointment>()
    //     modelBuilder.Entity<Appointment>()
    //          .HasOne<Doctor>()
    //         .WithMany()
    //         .HasForeignKey(d => d.DoctorId);

       }
}