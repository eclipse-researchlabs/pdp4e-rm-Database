using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Core.Database.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.Database
{
    public class BeawreContext: DbContext, IBeawreContext
    {
        public static string ConnectionString = "Server=WORKSTATION1;Database=Beawre_VFR;Trusted_Connection=True;MultipleActiveResultSets=true";

        public BeawreContext()
            : base()
        {
            this.Database.ExecuteSqlRaw("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
        }

        public DbSet<Asset> Assets { get; set; }
        public DbSet<Risk> Risk { get; set; }
        public DbSet<RiskPayload> RiskPayload { get; set; }
        public DbSet<Treatment> Treatment { get; set; }
        public DbSet<TreatmentPayload> TreatmentPayload { get; set; }
        public DbSet<Evidence> Evidence { get; set; }
        public DbSet<Vulnerability> Vulnerability { get; set; }
        public DbSet<Relationship> Relationship { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Dictionary> Dictionary { get; set; }

        public DbSet<AuditTrail> AuditTrial { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuditTrail>().Property(x => x.Action).HasConversion(new EnumToStringConverter<AuditTrailAction>());
        }

        public override int SaveChanges()
        {
            foreach (var entity in ChangeTracker.Entries().Where(x => x.State == EntityState.Added).Select(x => x.Entity as EntityBase).ToList())
            {
                entity.Id = Guid.NewGuid();
                if (entity.RootId == Guid.Empty)
                    entity.RootId = entity.Id;
                entity.CreatedDateTime = DateTime.Now;
            }

            foreach (var entity in ChangeTracker.Entries().Where(x => x.State == EntityState.Modified).ToList())
            {
                Entry(entity.Entity).Property("CreatedDateTime").IsModified = false;
            }

            return base.SaveChanges();
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
        DbSet<Dictionary> Dictionary { get; set; }

        DbSet<AuditTrail> AuditTrial { get; set; }
    }
}
