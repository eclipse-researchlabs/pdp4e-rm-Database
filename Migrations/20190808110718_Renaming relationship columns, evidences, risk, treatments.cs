using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Database.Migrations
{
    public partial class Renamingrelationshipcolumnsevidencesrisktreatments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Object1Type",
                table: "Relationship");

            migrationBuilder.DropColumn(
                name: "Object2Type",
                table: "Relationship");

            migrationBuilder.RenameColumn(
                name: "Object2Id",
                table: "Relationship",
                newName: "ToId");

            migrationBuilder.RenameColumn(
                name: "Object1Id",
                table: "Relationship",
                newName: "FromId");

            migrationBuilder.AddColumn<int>(
                name: "FromType",
                table: "Relationship",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ToType",
                table: "Relationship",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Evidence",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    CreateByUserId = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Payload = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evidence", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Risk_Payload",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    CreateByUserId = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Payload = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Risk_Payload", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Treatment_Payload",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    CreateByUserId = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Payload = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatment_Payload", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evidence");

            migrationBuilder.DropTable(
                name: "Risk_Payload");

            migrationBuilder.DropTable(
                name: "Treatment_Payload");

            migrationBuilder.DropColumn(
                name: "FromType",
                table: "Relationship");

            migrationBuilder.DropColumn(
                name: "ToType",
                table: "Relationship");

            migrationBuilder.RenameColumn(
                name: "ToId",
                table: "Relationship",
                newName: "Object2Id");

            migrationBuilder.RenameColumn(
                name: "FromId",
                table: "Relationship",
                newName: "Object1Id");

            migrationBuilder.AddColumn<int>(
                name: "Object1Type",
                table: "Relationship",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Object2Type",
                table: "Relationship",
                nullable: false,
                defaultValue: 0);
        }
    }
}
