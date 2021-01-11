﻿// /********************************************************************************
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
using Core.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.Database.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Database.Tables.Asset", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("Branch")
                    .HasColumnType("nvarchar(max)");

                b.Property<Guid>("CreateByUserId")
                    .HasColumnType("uniqueidentifier");

                b.Property<DateTime>("CreatedDateTime")
                    .HasColumnType("datetime2");

                b.Property<string>("Description")
                    .HasColumnType("nvarchar(max)");

                b.Property<bool>("IsDeleted")
                    .HasColumnType("bit");

                b.Property<bool>("IsGroup")
                    .HasColumnType("bit");

                b.Property<string>("Name")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Payload")
                    .HasColumnType("nvarchar(max)");

                b.Property<Guid>("RootId")
                    .HasColumnType("uniqueidentifier");

                b.Property<int>("Version")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.ToTable("Asset");
            });

            modelBuilder.Entity("Core.Database.Tables.AuditTrail", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("Action")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Branch")
                    .HasColumnType("nvarchar(max)");

                b.Property<Guid>("CreateByUserId")
                    .HasColumnType("uniqueidentifier");

                b.Property<DateTime>("CreatedDateTime")
                    .HasColumnType("datetime2");

                b.Property<bool>("IsDeleted")
                    .HasColumnType("bit");

                b.Property<Guid>("ObjectId")
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("Payload")
                    .HasColumnType("nvarchar(max)");

                b.Property<Guid>("RootId")
                    .HasColumnType("uniqueidentifier");

                b.Property<int>("Version")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.ToTable("AuditTrail");
            });

            modelBuilder.Entity("Core.Database.Tables.Container", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("Branch")
                    .HasColumnType("nvarchar(max)");

                b.Property<Guid>("CreateByUserId")
                    .HasColumnType("uniqueidentifier");

                b.Property<DateTime>("CreatedDateTime")
                    .HasColumnType("datetime2");

                b.Property<bool>("IsDeleted")
                    .HasColumnType("bit");

                b.Property<string>("Name")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Payload")
                    .HasColumnType("nvarchar(max)");

                b.Property<Guid>("RootId")
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("Type")
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("Version")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.ToTable("Container");
            });

            modelBuilder.Entity("Core.Database.Tables.Dictionary", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("Branch")
                    .HasColumnType("nvarchar(max)");

                b.Property<Guid>("CreateByUserId")
                    .HasColumnType("uniqueidentifier");

                b.Property<DateTime>("CreatedDateTime")
                    .HasColumnType("datetime2");

                b.Property<bool>("IsDeleted")
                    .HasColumnType("bit");

                b.Property<string>("Payload")
                    .HasColumnType("nvarchar(max)");

                b.Property<Guid>("RootId")
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("Symbol")
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("Type")
                    .HasColumnType("int");

                b.Property<string>("Value")
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("Version")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.ToTable("Dictionary");
            });

            modelBuilder.Entity("Core.Database.Tables.Evidence", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("Branch")
                    .HasColumnType("nvarchar(max)");

                b.Property<Guid>("CreateByUserId")
                    .HasColumnType("uniqueidentifier");

                b.Property<DateTime>("CreatedDateTime")
                    .HasColumnType("datetime2");

                b.Property<bool>("IsDeleted")
                    .HasColumnType("bit");

                b.Property<string>("Name")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Payload")
                    .HasColumnType("nvarchar(max)");

                b.Property<Guid>("RootId")
                    .HasColumnType("uniqueidentifier");

                b.Property<int>("Version")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.ToTable("Evidence");
            });

            modelBuilder.Entity("Core.Database.Tables.Relationship", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("Branch")
                    .HasColumnType("nvarchar(max)");

                b.Property<Guid>("CreateByUserId")
                    .HasColumnType("uniqueidentifier");

                b.Property<DateTime>("CreatedDateTime")
                    .HasColumnType("datetime2");

                b.Property<Guid>("FromId")
                    .HasColumnType("uniqueidentifier");

                b.Property<int>("FromType")
                    .HasColumnType("int");

                b.Property<bool>("IsDeleted")
                    .HasColumnType("bit");

                b.Property<string>("Payload")
                    .HasColumnType("nvarchar(max)");

                b.Property<Guid>("RootId")
                    .HasColumnType("uniqueidentifier");

                b.Property<Guid>("ToId")
                    .HasColumnType("uniqueidentifier");

                b.Property<int>("ToType")
                    .HasColumnType("int");

                b.Property<int>("Version")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.ToTable("Relationship");
            });

            modelBuilder.Entity("Core.Database.Tables.Risk", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("Branch")
                    .HasColumnType("nvarchar(max)");

                b.Property<Guid>("CreateByUserId")
                    .HasColumnType("uniqueidentifier");

                b.Property<DateTime>("CreatedDateTime")
                    .HasColumnType("datetime2");

                b.Property<string>("Description")
                    .HasColumnType("nvarchar(max)");

                b.Property<bool>("IsDeleted")
                    .HasColumnType("bit");

                b.Property<string>("Name")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Payload")
                    .HasColumnType("nvarchar(max)");

                b.Property<Guid>("RootId")
                    .HasColumnType("uniqueidentifier");

                b.Property<int>("Version")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.ToTable("Risk");
            });

            modelBuilder.Entity("Core.Database.Tables.RiskPayload", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("Branch")
                    .HasColumnType("nvarchar(max)");

                b.Property<Guid>("CreateByUserId")
                    .HasColumnType("uniqueidentifier");

                b.Property<DateTime>("CreatedDateTime")
                    .HasColumnType("datetime2");

                b.Property<bool>("IsDeleted")
                    .HasColumnType("bit");

                b.Property<string>("Payload")
                    .HasColumnType("nvarchar(max)");

                b.Property<Guid>("RootId")
                    .HasColumnType("uniqueidentifier");

                b.Property<int>("Version")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.ToTable("Risk_Payload");
            });

            modelBuilder.Entity("Core.Database.Tables.Treatment", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("Branch")
                    .HasColumnType("nvarchar(max)");

                b.Property<Guid>("CreateByUserId")
                    .HasColumnType("uniqueidentifier");

                b.Property<DateTime>("CreatedDateTime")
                    .HasColumnType("datetime2");

                b.Property<string>("Description")
                    .HasColumnType("nvarchar(max)");

                b.Property<bool>("IsDeleted")
                    .HasColumnType("bit");

                b.Property<string>("Name")
                    .HasColumnType("nvarchar(max)");

                b.Property<Guid>("RootId")
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("Type")
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("Version")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.ToTable("Treatment");
            });

            modelBuilder.Entity("Core.Database.Tables.TreatmentPayload", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("Branch")
                    .HasColumnType("nvarchar(max)");

                b.Property<Guid>("CreateByUserId")
                    .HasColumnType("uniqueidentifier");

                b.Property<DateTime>("CreatedDateTime")
                    .HasColumnType("datetime2");

                b.Property<bool>("IsDeleted")
                    .HasColumnType("bit");

                b.Property<string>("Payload")
                    .HasColumnType("nvarchar(max)");

                b.Property<Guid>("RootId")
                    .HasColumnType("uniqueidentifier");

                b.Property<int>("Version")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.ToTable("Treatment_Payload");
            });

            modelBuilder.Entity("Core.Database.Tables.User", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("AccountId")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Branch")
                    .HasColumnType("nvarchar(max)");

                b.Property<Guid>("CreateByUserId")
                    .HasColumnType("uniqueidentifier");

                b.Property<DateTime>("CreatedDateTime")
                    .HasColumnType("datetime2");

                b.Property<string>("Email")
                    .HasColumnType("nvarchar(max)");

                b.Property<bool>("IsDeleted")
                    .HasColumnType("bit");

                b.Property<string>("Password")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Payload")
                    .HasColumnType("nvarchar(max)");

                b.Property<Guid>("RootId")
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("Username")
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("Version")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.ToTable("User");
            });

            modelBuilder.Entity("Core.Database.Tables.Vulnerability", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("Branch")
                    .HasColumnType("nvarchar(max)");

                b.Property<Guid>("CreateByUserId")
                    .HasColumnType("uniqueidentifier");

                b.Property<DateTime>("CreatedDateTime")
                    .HasColumnType("datetime2");

                b.Property<string>("Description")
                    .HasColumnType("nvarchar(max)");

                b.Property<bool>("IsDeleted")
                    .HasColumnType("bit");

                b.Property<string>("Name")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Payload")
                    .HasColumnType("nvarchar(max)");

                b.Property<Guid>("RootId")
                    .HasColumnType("uniqueidentifier");

                b.Property<int>("Version")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.ToTable("Vulnerability");
            });
#pragma warning restore 612, 618
        }
    }
}