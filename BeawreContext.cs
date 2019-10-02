using System;
using System.Collections.Generic;
using System.Text;
using Core.Database.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.Database
{
    public class BeawreContext: DbContext, IBeawreContext
    {
        public static string ConnectionString = "Server=WORKSTATION1;Database=Beawre_PDP4E;Trusted_Connection=True;MultipleActiveResultSets=true";

        public DbSet<Asset> Assets { get; set; }
        public DbSet<Risk> Risk { get; set; }
        public DbSet<RiskPayload> RiskPayload { get; set; }
        public DbSet<Treatment> Treatment { get; set; }
        public DbSet<TreatmentPayload> TreatmentPayload { get; set; }
        public DbSet<Evidence> Evidence { get; set; }
        public DbSet<Vulnerability> Vulnerability { get; set; }
        public DbSet<Relationship> Relationship { get; set; }
        public DbSet<User> User { get; set; }

        public DbSet<AuditTrail> AuditTrial { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        public static void Initalize()
        {
            using(var db = new BeawreContext())
                db.Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuditTrail>().Property(x => x.Action).HasConversion(new EnumToStringConverter<AuditTrailAction>());
        }
    }

    public interface IBeawreContext: IDbContext
    {
        DbSet<Asset> Assets { get; set; }

        DbSet<Risk> Risk { get; set; }
        DbSet<RiskPayload> RiskPayload { get; set; }

        DbSet<Treatment> Treatment { get; set; }
        DbSet<TreatmentPayload> TreatmentPayload { get; set; }

        DbSet<Evidence> Evidence { get; set; }

        DbSet<Vulnerability> Vulnerability { get; set; }

        DbSet<Relationship> Relationship { get; set; }

        DbSet<User> User { get; set; }

        DbSet<AuditTrail> AuditTrial { get; set; }
    }
}
