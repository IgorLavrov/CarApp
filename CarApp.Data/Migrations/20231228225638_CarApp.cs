using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class CarApp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VinNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeOfFuel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EngineCapacity = table.Column<int>(type: "int", nullable: false),
                    NumberOfCarDoors = table.Column<int>(type: "int", nullable: false),
                    CarWeight = table.Column<int>(type: "int", nullable: false),
                    BuiltAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegistratedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
