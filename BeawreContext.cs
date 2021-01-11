// /********************************************************************************
//  * Copyright (c) 2020,2021 Beawre Digital SL
//  *
//  * This program and the accompanying materials are made available under the
//  * terms of the Eclipse Public License 2.0 which is available at
//  * http://www.eclipse.org/legal/epl-2.0.
//  *
//  * SPDX-License-Identifier: EPL-2.0 3
//  *
//  ********************************************************************************/

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
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public static string ConnectionString = "Server=WORKSTATION1;Database=Beawre_VFR;Trusted_Connection=True;MultipleActiveResultSets=true";

        public DatabaseContext()
            : base()
        {
            this.Database.ExecuteSqlRaw("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
            Database.SetCommandTimeout(120);
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
        public DbSet<Container> Container { get; set; }

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
    }

    public interface IDatabaseContext : IDbContext
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
        DbSet<Container> Container { get; set; }
    }
}