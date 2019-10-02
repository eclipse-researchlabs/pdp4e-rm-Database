using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Database.Migrations
{
    public partial class missingbranchandversion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Branch",
                table: "Vulnerability",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Vulnerability",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Branch",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Branch",
                table: "Treatment_Payload",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Treatment_Payload",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Branch",
                table: "Treatment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Treatment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Branch",
                table: "Risk_Payload",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Risk_Payload",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Branch",
                table: "Risk",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Risk",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Branch",
                table: "Relationship",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Relationship",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Branch",
                table: "Evidence",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Evidence",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Branch",
                table: "AuditTrail",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "AuditTrail",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Branch",
                table: "Asset",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Asset",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Branch",
                table: "Vulnerability");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Vulnerability");

            migrationBuilder.DropColumn(
                name: "Branch",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Branch",
                table: "Treatment_Payload");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Treatment_Payload");

            migrationBuilder.DropColumn(
                name: "Branch",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "Branch",
                table: "Risk_Payload");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Risk_Payload");

            migrationBuilder.DropColumn(
                name: "Branch",
                table: "Risk");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Risk");

            migrationBuilder.DropColumn(
                name: "Branch",
                table: "Relationship");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Relationship");

            migrationBuilder.DropColumn(
                name: "Branch",
                table: "Evidence");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Evidence");

            migrationBuilder.DropColumn(
                name: "Branch",
                table: "AuditTrail");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "AuditTrail");

            migrationBuilder.DropColumn(
                name: "Branch",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Asset");
        }
    }
}
