using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RemoteTestingApp.Infrastructure.Migrations
{
    public partial class Addednewtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "UploadedDocuments");

            migrationBuilder.AddColumn<byte[]>(
                name: "NyscCertificate",
                table: "UploadedDocuments",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfessionalCertificate",
                table: "UploadedDocuments",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "UniversityCertificate",
                table: "UploadedDocuments",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "WaecCertificate",
                table: "UploadedDocuments",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DocumentUnquieID",
                table: "CompanyDocuments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NyscCertificate",
                table: "UploadedDocuments");

            migrationBuilder.DropColumn(
                name: "ProfessionalCertificate",
                table: "UploadedDocuments");

            migrationBuilder.DropColumn(
                name: "UniversityCertificate",
                table: "UploadedDocuments");

            migrationBuilder.DropColumn(
                name: "WaecCertificate",
                table: "UploadedDocuments");

            migrationBuilder.DropColumn(
                name: "DocumentUnquieID",
                table: "CompanyDocuments");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "UploadedDocuments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
