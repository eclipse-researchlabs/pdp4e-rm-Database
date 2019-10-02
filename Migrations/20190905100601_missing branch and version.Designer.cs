﻿// <auto-generated />
using System;
using Core.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.Database.Migrations
{
    [DbContext(typeof(BeawreContext))]
    [Migration("20190905100601_missing branch and version")]
    partial class missingbranchandversion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Database.Tables.Asset", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Branch");

                    b.Property<Guid>("CreateByUserId");

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsGroup");

                    b.Property<string>("Name");

                    b.Property<string>("Payload");

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.ToTable("Asset");
                });

            modelBuilder.Entity("Core.Database.Tables.AuditTrail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action")
                        .IsRequired();

                    b.Property<string>("Branch");

                    b.Property<Guid>("CreateByUserId");

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<bool>("IsDeleted");

                    b.Property<Guid>("ObjectId");

                    b.Property<string>("Payload");

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.ToTable("AuditTrail");
                });

            modelBuilder.Entity("Core.Database.Tables.Evidence", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Branch");

                    b.Property<Guid>("CreateByUserId");

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<string>("Payload");

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.ToTable("Evidence");
                });

            modelBuilder.Entity("Core.Database.Tables.Relationship", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Branch");

                    b.Property<Guid>("CreateByUserId");

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<Guid>("FromId");

                    b.Property<int>("FromType");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Payload");

                    b.Property<Guid>("ToId");

                    b.Property<int>("ToType");

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.ToTable("Relationship");
                });

            modelBuilder.Entity("Core.Database.Tables.Risk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Branch");

                    b.Property<Guid>("CreateByUserId");

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<string>("Payload");

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.ToTable("Risk");
                });

            modelBuilder.Entity("Core.Database.Tables.RiskPayload", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Branch");

                    b.Property<Guid>("CreateByUserId");

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Payload");

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.ToTable("Risk_Payload");
                });

            modelBuilder.Entity("Core.Database.Tables.Treatment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Branch");

                    b.Property<Guid>("CreateByUserId");

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Type");

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.ToTable("Treatment");
                });

            modelBuilder.Entity("Core.Database.Tables.TreatmentPayload", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Branch");

                    b.Property<Guid>("CreateByUserId");

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Payload");

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.ToTable("Treatment_Payload");
                });

            modelBuilder.Entity("Core.Database.Tables.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountId");

                    b.Property<string>("Branch");

                    b.Property<Guid>("CreateByUserId");

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<string>("Email");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Core.Database.Tables.Vulnerability", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Branch");

                    b.Property<Guid>("CreateByUserId");

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.ToTable("Vulnerability");
                });
#pragma warning restore 612, 618
        }
    }
}
