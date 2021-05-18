using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Car_delearship.Data.Migrations
{
    public partial class added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Colour",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Condition",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "FuelType",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Options",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "VehicleId",
                table: "Vehicles",
                newName: "VehicleID");

            migrationBuilder.AddColumn<string>(
                name: "BodyStyle",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Featured",
                table: "Vehicles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "InteriorID",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "MSRP",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "MakeID",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModelID",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PicturePath",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SalePrice",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "Sold",
                table: "Vehicles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "StaffID",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "VIN",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BodyStyles",
                columns: table => new
                {
                    BodyStyleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Style = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyStyles", x => x.BodyStyleID);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    ColorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.ColorID);
                });

            migrationBuilder.CreateTable(
                name: "Interiors",
                columns: table => new
                {
                    InteriorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InteriorName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interiors", x => x.InteriorID);
                });

            migrationBuilder.CreateTable(
                name: "MakeModelVehicles",
                columns: table => new
                {
                    VehicleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelID = table.Column<int>(nullable: false),
                    MakeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MakeModelVehicles", x => x.VehicleID);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    ModelID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(nullable: true),
                    MakeID = table.Column<int>(nullable: false),
                    BodyStyleID = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    StaffId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.ModelID);
                });

            migrationBuilder.CreateTable(
                name: "Transmissions",
                columns: table => new
                {
                    TransmissionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransmissionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transmissions", x => x.TransmissionID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BodyStyles");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Interiors");

            migrationBuilder.DropTable(
                name: "MakeModelVehicles");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Transmissions");

            migrationBuilder.DropColumn(
                name: "BodyStyle",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Featured",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "InteriorID",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "MSRP",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "MakeID",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "ModelID",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "PicturePath",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "SalePrice",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Sold",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "StaffID",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VIN",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "VehicleID",
                table: "Vehicles",
                newName: "VehicleId");

            migrationBuilder.AddColumn<string>(
                name: "Colour",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Condition",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FuelType",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Options",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
