using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Filamentous.Migrations
{
    /// <inheritdoc />
    public partial class Base_Objects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductLine_Brand_BrandId",
                table: "ProductLine");

            migrationBuilder.AlterColumn<Guid>(
                name: "BrandId",
                table: "ProductLine",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BedTemperature",
                table: "ProductLine",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 22);

            migrationBuilder.AddColumn<int>(
                name: "HotEndTemperature",
                table: "ProductLine",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 21);

            migrationBuilder.AddColumn<bool>(
                name: "IsAbrasive",
                table: "ProductLine",
                type: "bit",
                nullable: false,
                defaultValue: false)
                .Annotation("Relational:ColumnOrder", 20);

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Brand",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 10)
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<string>(
                name: "SpoolUrlTemplate",
                table: "Brand",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 21)
                .OldAnnotation("Relational:ColumnOrder", 11);

            migrationBuilder.AlterColumn<string>(
                name: "ProductUrlTemplate",
                table: "Brand",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 20)
                .OldAnnotation("Relational:ColumnOrder", 10);

            migrationBuilder.CreateTable(
                name: "ImageType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageType_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ImageType_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ImageType_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UPC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilamentXyzUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductWeight = table.Column<int>(type: "int", nullable: false),
                    SpoolWeight = table.Column<int>(type: "int", nullable: false),
                    ColorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsGradient = table.Column<bool>(type: "bit", nullable: false),
                    GradientCycleLength = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    Discontinued = table.Column<bool>(type: "bit", nullable: true),
                    ConcurrencyStamp = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductLineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_ProductLine_ProductLineId",
                        column: x => x.ProductLineId,
                        principalTable: "ProductLine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Filename = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ConcurrencyStamp = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImage_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductImage_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductImage_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductImage_ImageType_ImageTypeId",
                        column: x => x.ImageTypeId,
                        principalTable: "ImageType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductImage_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Spool",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManufacturerSerial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InitialWeight = table.Column<int>(type: "int", nullable: false),
                    CurrentWeight = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spool", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spool_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Spool_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Spool_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Spool_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "D9A3F45C-81AE-4B86-B477-020000000001",
                column: "SecurityStamp",
                value: "47e36abe-3b8a-4b74-a1eb-67a9c9d3ca0c");

            migrationBuilder.InsertData(
                table: "ImageType",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreatedOn", "DeletedById", "DeletedOn", "Name", "SortOrder", "UpdatedById", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("d9a3f45c-81ae-4b86-b477-030000000001"), new Guid("d9a3f45c-81ae-4b86-b477-030000000001"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Swatch", 1, null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Swatch (Alternate)", 2, null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-030000000003"), new Guid("d9a3f45c-81ae-4b86-b477-030000000003"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Spool", 3, null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-030000000004"), new Guid("d9a3f45c-81ae-4b86-b477-030000000004"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Sample Print", 4, null, null }
                });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000001"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 60, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 215, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000002"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 60, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 215, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000003"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 60, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 215, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000004"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 60, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 215, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000005"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 60, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 215, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000006"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 60, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 215, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000007"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 60, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 215, true });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000008"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 60, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 215, true });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000009"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 60, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 215, true });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000000a"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 60, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 215, true });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000000b"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 60, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 215, true });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000000c"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 60, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 215, true });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000000d"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 60, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 215, true });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000000e"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 60, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 215, true });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000000f"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 60, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 215, true });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000010"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 60, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 220, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000011"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 60, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 220, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000012"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 60, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 215, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000013"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 60, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 215, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000014"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 60, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 215, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000015"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 60, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 215, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000016"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 60, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 215, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000017"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 50, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 200, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000018"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 70, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 220, true });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000019"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 50, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 200, true });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000001a"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 60, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 215, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000001b"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive", "Name" },
                values: new object[] { 60, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 215, false, "Matte PLA for Production" });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000001c"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 110, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 255, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000001d"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 110, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 255, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000001e"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 110, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 255, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000001f"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 110, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 255, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000020"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 110, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 260, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000021"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 110, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 260, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000022"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 90, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 240, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000023"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 90, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 240, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000024"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 90, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 240, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000025"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 90, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 240, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000026"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 50, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 220, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000027"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 50, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 220, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000028"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 50, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 210, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000029"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 105, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 260, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000002a"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 105, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 260, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000002b"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 105, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 260, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000002c"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 105, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 260, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000002d"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 115, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 270, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000002e"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 50, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 260, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000002f"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 50, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 290, true });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000030"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 50, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 290, true });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000031"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 50, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 275, true });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000032"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 50, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 275, true });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000033"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 50, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 205, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000034"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 60, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 205, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000035"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 60, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 225, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000036"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 80, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 285, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000037"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 60, new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), 220, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000038"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 60, new Guid("d9a3f45c-81ae-4b86-b477-030000000001"), 215, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000039"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 50, new Guid("d9a3f45c-81ae-4b86-b477-030000000001"), 205, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000003a"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 80, new Guid("d9a3f45c-81ae-4b86-b477-030000000001"), 250, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000003b"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 110, new Guid("d9a3f45c-81ae-4b86-b477-030000000001"), 275, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000003c"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 75, new Guid("d9a3f45c-81ae-4b86-b477-030000000001"), 215, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000003d"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 110, new Guid("d9a3f45c-81ae-4b86-b477-030000000001"), 260, false });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000003e"),
                columns: new[] { "BedTemperature", "BrandId", "HotEndTemperature", "IsAbrasive" },
                values: new object[] { 110, new Guid("d9a3f45c-81ae-4b86-b477-030000000001"), 285, true });

            migrationBuilder.InsertData(
                table: "ProductLine",
                columns: new[] { "Id", "BedTemperature", "BrandId", "ConcurrencyStamp", "CreatedById", "CreatedOn", "DeletedById", "DeletedOn", "HotEndTemperature", "IsAbrasive", "Name", "PolymerId", "UpdatedById", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("d9a3f45c-81ae-4b86-b477-05000000003f"), 90, new Guid("d9a3f45c-81ae-4b86-b477-030000000001"), new Guid("d9a3f45c-81ae-4b86-b477-05000000003f"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 265, true, "Prusament PETG-CF", new Guid("d9a3f45c-81ae-4b86-b477-040000000002"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-050000000040"), 110, new Guid("d9a3f45c-81ae-4b86-b477-030000000001"), new Guid("d9a3f45c-81ae-4b86-b477-050000000040"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 285, true, "Prusament PC Blend", new Guid("d9a3f45c-81ae-4b86-b477-040000000006"), null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageType_CreatedById",
                table: "ImageType",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ImageType_DeletedById",
                table: "ImageType",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_ImageType_UpdatedById",
                table: "ImageType",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CreatedById",
                table: "Product",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Product_DeletedById",
                table: "Product",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductLineId",
                table: "Product",
                column: "ProductLineId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_UpdatedById",
                table: "Product",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_CreatedById",
                table: "ProductImage",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_DeletedById",
                table: "ProductImage",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_ImageTypeId",
                table: "ProductImage",
                column: "ImageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_ProductId",
                table: "ProductImage",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_UpdatedById",
                table: "ProductImage",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Spool_CreatedById",
                table: "Spool",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Spool_DeletedById",
                table: "Spool",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Spool_ProductId",
                table: "Spool",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Spool_UpdatedById",
                table: "Spool",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLine_Brand_BrandId",
                table: "ProductLine",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductLine_Brand_BrandId",
                table: "ProductLine");

            migrationBuilder.DropTable(
                name: "ProductImage");

            migrationBuilder.DropTable(
                name: "Spool");

            migrationBuilder.DropTable(
                name: "ImageType");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DeleteData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000003f"));

            migrationBuilder.DeleteData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000040"));

            migrationBuilder.DropColumn(
                name: "BedTemperature",
                table: "ProductLine");

            migrationBuilder.DropColumn(
                name: "HotEndTemperature",
                table: "ProductLine");

            migrationBuilder.DropColumn(
                name: "IsAbrasive",
                table: "ProductLine");

            migrationBuilder.AlterColumn<Guid>(
                name: "BrandId",
                table: "ProductLine",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Brand",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 2)
                .OldAnnotation("Relational:ColumnOrder", 10);

            migrationBuilder.AlterColumn<string>(
                name: "SpoolUrlTemplate",
                table: "Brand",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 11)
                .OldAnnotation("Relational:ColumnOrder", 21);

            migrationBuilder.AlterColumn<string>(
                name: "ProductUrlTemplate",
                table: "Brand",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 10)
                .OldAnnotation("Relational:ColumnOrder", 20);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "D9A3F45C-81AE-4B86-B477-020000000001",
                column: "SecurityStamp",
                value: "382c8396-2609-40f8-a4fc-7753e58d0ca1");

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000001"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000002"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000003"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000004"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000005"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000006"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000007"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000008"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000009"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000000a"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000000b"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000000c"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000000d"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000000e"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000000f"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000010"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000011"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000012"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000013"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000014"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000015"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000016"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000017"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000018"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000019"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000001a"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000001b"),
                columns: new[] { "BrandId", "Name" },
                values: new object[] { null, "Matte PLA" });

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000001c"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000001d"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000001e"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000001f"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000020"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000021"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000022"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000023"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000024"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000025"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000026"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000027"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000028"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000029"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000002a"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000002b"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000002c"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000002d"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000002e"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000002f"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000030"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000031"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000032"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000033"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000034"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000035"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000036"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000037"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000038"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-050000000039"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000003a"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000003b"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000003c"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000003d"),
                column: "BrandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductLine",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-05000000003e"),
                column: "BrandId",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLine_Brand_BrandId",
                table: "ProductLine",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id");
        }
    }
}
