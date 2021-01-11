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
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Database.Migrations
{
    public partial class Initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Asset",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Branch = table.Column<string>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    RootId = table.Column<Guid>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    CreateByUserId = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsGroup = table.Column<bool>(nullable: false),
                    Payload = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Asset", x => x.Id); });

            migrationBuilder.CreateTable(
                name: "AuditTrail",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Branch = table.Column<string>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    RootId = table.Column<Guid>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    CreateByUserId = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Action = table.Column<string>(nullable: false),
                    ObjectId = table.Column<Guid>(nullable: false),
                    Payload = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AuditTrail", x => x.Id); });

            migrationBuilder.CreateTable(
                name: "Container",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Branch = table.Column<string>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    RootId = table.Column<Guid>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    CreateByUserId = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Payload = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Container", x => x.Id); });

            migrationBuilder.CreateTable(
                name: "Dictionary",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Branch = table.Column<string>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    RootId = table.Column<Guid>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    CreateByUserId = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Symbol = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    Payload = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Dictionary", x => x.Id); });

            migrationBuilder.CreateTable(
                name: "Evidence",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Branch = table.Column<string>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    RootId = table.Column<Guid>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    CreateByUserId = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Payload = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Evidence", x => x.Id); });

            migrationBuilder.CreateTable(
                name: "Relationship",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Branch = table.Column<string>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    RootId = table.Column<Guid>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    CreateByUserId = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    FromType = table.Column<int>(nullable: false),
                    FromId = table.Column<Guid>(nullable: false),
                    ToType = table.Column<int>(nullable: false),
                    ToId = table.Column<Guid>(nullable: false),
                    Payload = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Relationship", x => x.Id); });

            migrationBuilder.CreateTable(
                name: "Risk",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Branch = table.Column<string>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    RootId = table.Column<Guid>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    CreateByUserId = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Payload = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Risk", x => x.Id); });

            migrationBuilder.CreateTable(
                name: "Risk_Payload",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Branch = table.Column<string>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    RootId = table.Column<Guid>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    CreateByUserId = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Payload = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Risk_Payload", x => x.Id); });

            migrationBuilder.CreateTable(
                name: "Treatment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Branch = table.Column<string>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    RootId = table.Column<Guid>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    CreateByUserId = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Treatment", x => x.Id); });

            migrationBuilder.CreateTable(
                name: "Treatment_Payload",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Branch = table.Column<string>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    RootId = table.Column<Guid>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    CreateByUserId = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Payload = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Treatment_Payload", x => x.Id); });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Branch = table.Column<string>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    RootId = table.Column<Guid>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    CreateByUserId = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    AccountId = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Payload = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_User", x => x.Id); });

            migrationBuilder.CreateTable(
                name: "Vulnerability",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Branch = table.Column<string>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    RootId = table.Column<Guid>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    CreateByUserId = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Payload = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Vulnerability", x => x.Id); });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asset");

            migrationBuilder.DropTable(
                name: "AuditTrail");

            migrationBuilder.DropTable(
                name: "Container");

            migrationBuilder.DropTable(
                name: "Dictionary");

            migrationBuilder.DropTable(
                name: "Evidence");

            migrationBuilder.DropTable(
                name: "Relationship");

            migrationBuilder.DropTable(
                name: "Risk");

            migrationBuilder.DropTable(
                name: "Risk_Payload");

            migrationBuilder.DropTable(
                name: "Treatment");

            migrationBuilder.DropTable(
                name: "Treatment_Payload");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Vulnerability");
        }
    }
}