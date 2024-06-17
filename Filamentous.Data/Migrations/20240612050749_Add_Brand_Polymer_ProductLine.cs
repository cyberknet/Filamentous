using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Filamentous.Migrations
{
    /// <inheritdoc />
    public partial class Add_Brand_Polymer_ProductLine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductUrlTemplate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpoolUrlTemplate = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Brand", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brand_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Brand_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Brand_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Polymer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Polymer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Polymer_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Polymer_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Polymer_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductLine",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PolymerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductLine_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductLine_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductLine_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductLine_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductLine_Polymer_PolymerId",
                        column: x => x.PolymerId,
                        principalTable: "Polymer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "D9A3F45C-81AE-4B86-B477-010000000001", "D9A3F45C-81AE-4B86-B477-020000000001", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "D9A3F45C-81AE-4B86-B477-020000000001", 0, "D9A3F45C-81AE-4B86-B477-020000000001", "scott@blomfield.us", true, false, null, "SCOTT@BLOMFIELD.US", "SCOTT@BLOMFIELD.US", "AQAAAAIAAYagAAAAEBm+qE3vZ4hlMjyrKVdyjEtTZqnU/1XXi/Sh2ycOqU8PkBxc8e5VLe//Lw/iO9dslw==", null, false, "382c8396-2609-40f8-a4fc-7753e58d0ca1", false, "scott@blomfield.us" });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreatedOn", "DeletedById", "DeletedOn", "Name", "ProductUrlTemplate", "SpoolUrlTemplate", "UpdatedById", "UpdatedOn", "Url" },
                values: new object[,]
                {
                    { new Guid("d9a3f45c-81ae-4b86-b477-030000000001"), new Guid("d9a3f45c-81ae-4b86-b477-030000000001"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Prusament", null, null, null, null, "https://prusa3d.com/" },
                    { new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Polymaker", null, null, null, null, "https://us.polymaker.com/" }
                });

            migrationBuilder.InsertData(
                table: "Polymer",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreatedOn", "DeletedById", "DeletedOn", "Name", "UpdatedById", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("d9a3f45c-81ae-4b86-b477-040000000001"), new Guid("d9a3f45c-81ae-4b86-b477-040000000001"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PLA", null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-040000000002"), new Guid("d9a3f45c-81ae-4b86-b477-040000000002"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PETG", null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-040000000003"), new Guid("d9a3f45c-81ae-4b86-b477-040000000003"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "ASA", null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-040000000004"), new Guid("d9a3f45c-81ae-4b86-b477-040000000004"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "ABS", null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-040000000005"), new Guid("d9a3f45c-81ae-4b86-b477-040000000005"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "TPU", null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-040000000006"), new Guid("d9a3f45c-81ae-4b86-b477-040000000006"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PC", null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-040000000007"), new Guid("d9a3f45c-81ae-4b86-b477-040000000007"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PVB", null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-040000000008"), new Guid("d9a3f45c-81ae-4b86-b477-040000000008"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "CoPA", null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-040000000009"), new Guid("d9a3f45c-81ae-4b86-b477-040000000009"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PA6-CF", null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-04000000000a"), new Guid("d9a3f45c-81ae-4b86-b477-04000000000a"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PA6-GF", null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-04000000000b"), new Guid("d9a3f45c-81ae-4b86-b477-04000000000b"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PA12-CF", null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-04000000000c"), new Guid("d9a3f45c-81ae-4b86-b477-04000000000c"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PVA", null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-04000000000d"), new Guid("d9a3f45c-81ae-4b86-b477-04000000000d"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PCL", null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-04000000000e"), new Guid("d9a3f45c-81ae-4b86-b477-04000000000e"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PPS", null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-04000000000f"), new Guid("d9a3f45c-81ae-4b86-b477-04000000000f"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PS", null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-040000000010"), new Guid("d9a3f45c-81ae-4b86-b477-040000000010"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PSU", null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-040000000011"), new Guid("d9a3f45c-81ae-4b86-b477-040000000011"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PPSU", null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-040000000012"), new Guid("d9a3f45c-81ae-4b86-b477-040000000012"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PPA", null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-040000000013"), new Guid("d9a3f45c-81ae-4b86-b477-040000000013"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PEEK", null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-040000000014"), new Guid("d9a3f45c-81ae-4b86-b477-040000000014"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PEKK", null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-040000000015"), new Guid("d9a3f45c-81ae-4b86-b477-040000000015"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Other", null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-040000000016"), new Guid("d9a3f45c-81ae-4b86-b477-040000000016"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PA11-CF", null, null }
                });

            migrationBuilder.InsertData(
                table: "ProductLine",
                columns: new[] { "Id", "BrandId", "ConcurrencyStamp", "CreatedById", "CreatedOn", "DeletedById", "DeletedOn", "Name", "PolymerId", "UpdatedById", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("d9a3f45c-81ae-4b86-b477-050000000001"), null, new Guid("d9a3f45c-81ae-4b86-b477-050000000001"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyLite PLA", new Guid("d9a3f45c-81ae-4b86-b477-040000000001"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-050000000002"), null, new Guid("d9a3f45c-81ae-4b86-b477-050000000002"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyLite Silk PLA", new Guid("d9a3f45c-81ae-4b86-b477-040000000001"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-050000000003"), null, new Guid("d9a3f45c-81ae-4b86-b477-050000000003"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyLite Dual Silk PLA", new Guid("d9a3f45c-81ae-4b86-b477-040000000001"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-050000000004"), null, new Guid("d9a3f45c-81ae-4b86-b477-050000000004"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyLite Galaxy PLA", new Guid("d9a3f45c-81ae-4b86-b477-040000000001"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-050000000005"), null, new Guid("d9a3f45c-81ae-4b86-b477-050000000005"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyLite Starlight PLA", new Guid("d9a3f45c-81ae-4b86-b477-040000000001"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-050000000006"), null, new Guid("d9a3f45c-81ae-4b86-b477-050000000006"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyLite Luminous PLA", new Guid("d9a3f45c-81ae-4b86-b477-040000000001"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-050000000007"), null, new Guid("d9a3f45c-81ae-4b86-b477-050000000007"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyLite Glow PLA", new Guid("d9a3f45c-81ae-4b86-b477-040000000001"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-050000000008"), null, new Guid("d9a3f45c-81ae-4b86-b477-050000000008"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyLite Temperature Color Changing PLA", new Guid("d9a3f45c-81ae-4b86-b477-040000000001"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-050000000009"), null, new Guid("d9a3f45c-81ae-4b86-b477-050000000009"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyLite UV Color Changing PLA", new Guid("d9a3f45c-81ae-4b86-b477-040000000001"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-05000000000a"), null, new Guid("d9a3f45c-81ae-4b86-b477-05000000000a"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyTerra Matte PLA", new Guid("d9a3f45c-81ae-4b86-b477-040000000001"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-05000000000b"), null, new Guid("d9a3f45c-81ae-4b86-b477-05000000000b"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyTerra Dual Matte PLA", new Guid("d9a3f45c-81ae-4b86-b477-040000000001"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-05000000000c"), null, new Guid("d9a3f45c-81ae-4b86-b477-05000000000c"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyTerra Gradient Matte PLA", new Guid("d9a3f45c-81ae-4b86-b477-040000000001"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-05000000000d"), null, new Guid("d9a3f45c-81ae-4b86-b477-05000000000d"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyTerra Dual Gradient Matte PLA", new Guid("d9a3f45c-81ae-4b86-b477-040000000001"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-05000000000e"), null, new Guid("d9a3f45c-81ae-4b86-b477-05000000000e"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyTerra Marble PLA", new Guid("d9a3f45c-81ae-4b86-b477-040000000001"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-05000000000f"), null, new Guid("d9a3f45c-81ae-4b86-b477-05000000000f"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyTerra Satin PLA", new Guid("d9a3f45c-81ae-4b86-b477-040000000001"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-050000000010"), null, new Guid("d9a3f45c-81ae-4b86-b477-050000000010"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolySonic PLA", new Guid("d9a3f45c-81ae-4b86-b477-040000000001"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-050000000011"), null, new Guid("d9a3f45c-81ae-4b86-b477-050000000011"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolySonic PLA Pro", new Guid("d9a3f45c-81ae-4b86-b477-040000000001"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-050000000012"), null, new Guid("d9a3f45c-81ae-4b86-b477-050000000012"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyLite PLA Pro", new Guid("d9a3f45c-81ae-4b86-b477-040000000001"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-050000000013"), null, new Guid("d9a3f45c-81ae-4b86-b477-050000000013"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyLite Metallic PLA Pro", new Guid("d9a3f45c-81ae-4b86-b477-040000000001"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-050000000014"), null, new Guid("d9a3f45c-81ae-4b86-b477-050000000014"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyMax PLA", new Guid("d9a3f45c-81ae-4b86-b477-040000000001"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-050000000015"), null, new Guid("d9a3f45c-81ae-4b86-b477-050000000015"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Seasonal Packs PLA", new Guid("d9a3f45c-81ae-4b86-b477-040000000001"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-050000000016"), null, new Guid("d9a3f45c-81ae-4b86-b477-050000000016"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyLite CosPLA", new Guid("d9a3f45c-81ae-4b86-b477-040000000001"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-050000000017"), null, new Guid("d9a3f45c-81ae-4b86-b477-050000000017"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Light Weight PLA", new Guid("d9a3f45c-81ae-4b86-b477-040000000001"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-050000000018"), null, new Guid("d9a3f45c-81ae-4b86-b477-050000000018"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Carbon Fiber PLA", new Guid("d9a3f45c-81ae-4b86-b477-040000000001"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-050000000019"), null, new Guid("d9a3f45c-81ae-4b86-b477-050000000019"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyWood PLA", new Guid("d9a3f45c-81ae-4b86-b477-040000000001"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-05000000001a"), null, new Guid("d9a3f45c-81ae-4b86-b477-05000000001a"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Draft PLA", new Guid("d9a3f45c-81ae-4b86-b477-040000000001"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-05000000001b"), null, new Guid("d9a3f45c-81ae-4b86-b477-05000000001b"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Matte PLA", new Guid("d9a3f45c-81ae-4b86-b477-040000000001"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-05000000001c"), null, new Guid("d9a3f45c-81ae-4b86-b477-05000000001c"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyLite ABS", new Guid("d9a3f45c-81ae-4b86-b477-040000000004"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-05000000001d"), null, new Guid("d9a3f45c-81ae-4b86-b477-05000000001d"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyLite Metallic ABS", new Guid("d9a3f45c-81ae-4b86-b477-040000000004"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-05000000001e"), null, new Guid("d9a3f45c-81ae-4b86-b477-05000000001e"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyLite Galaxy ABS", new Guid("d9a3f45c-81ae-4b86-b477-040000000004"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-05000000001f"), null, new Guid("d9a3f45c-81ae-4b86-b477-05000000001f"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyLite Neon ABS", new Guid("d9a3f45c-81ae-4b86-b477-040000000004"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-050000000020"), null, new Guid("d9a3f45c-81ae-4b86-b477-050000000020"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyLite ASA", new Guid("d9a3f45c-81ae-4b86-b477-040000000003"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-050000000021"), null, new Guid("d9a3f45c-81ae-4b86-b477-050000000021"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyLite Galaxy ASA", new Guid("d9a3f45c-81ae-4b86-b477-040000000003"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-050000000022"), null, new Guid("d9a3f45c-81ae-4b86-b477-050000000022"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyLite PETG", new Guid("d9a3f45c-81ae-4b86-b477-040000000002"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-050000000023"), null, new Guid("d9a3f45c-81ae-4b86-b477-050000000023"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyLite Translucent PETG", new Guid("d9a3f45c-81ae-4b86-b477-040000000002"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-050000000024"), null, new Guid("d9a3f45c-81ae-4b86-b477-050000000024"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyMax PETG", new Guid("d9a3f45c-81ae-4b86-b477-040000000002"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-050000000025"), null, new Guid("d9a3f45c-81ae-4b86-b477-050000000025"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyMax PETG-ESD", new Guid("d9a3f45c-81ae-4b86-b477-040000000002"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-050000000026"), null, new Guid("d9a3f45c-81ae-4b86-b477-050000000026"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyMax TPU90", new Guid("d9a3f45c-81ae-4b86-b477-040000000005"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-050000000027"), null, new Guid("d9a3f45c-81ae-4b86-b477-050000000027"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyMax TPU95", new Guid("d9a3f45c-81ae-4b86-b477-040000000005"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-050000000028"), null, new Guid("d9a3f45c-81ae-4b86-b477-050000000028"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyMax TPU95-HF", new Guid("d9a3f45c-81ae-4b86-b477-040000000005"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-050000000029"), null, new Guid("d9a3f45c-81ae-4b86-b477-050000000029"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyLite PC", new Guid("d9a3f45c-81ae-4b86-b477-040000000006"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-05000000002a"), null, new Guid("d9a3f45c-81ae-4b86-b477-05000000002a"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyMax PC", new Guid("d9a3f45c-81ae-4b86-b477-040000000006"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-05000000002b"), null, new Guid("d9a3f45c-81ae-4b86-b477-05000000002b"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyMaxPC-FR", new Guid("d9a3f45c-81ae-4b86-b477-040000000006"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-05000000002c"), null, new Guid("d9a3f45c-81ae-4b86-b477-05000000002c"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyMax PC-ABS", new Guid("d9a3f45c-81ae-4b86-b477-040000000006"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-05000000002d"), null, new Guid("d9a3f45c-81ae-4b86-b477-05000000002d"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyMax PC-PBT", new Guid("d9a3f45c-81ae-4b86-b477-040000000006"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-05000000002e"), null, new Guid("d9a3f45c-81ae-4b86-b477-05000000002e"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyMide CoPA", new Guid("d9a3f45c-81ae-4b86-b477-040000000008"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-05000000002f"), null, new Guid("d9a3f45c-81ae-4b86-b477-05000000002f"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyMide PA-6GF", new Guid("d9a3f45c-81ae-4b86-b477-04000000000a"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-050000000030"), null, new Guid("d9a3f45c-81ae-4b86-b477-050000000030"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyMide PA6-CF", new Guid("d9a3f45c-81ae-4b86-b477-040000000009"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-050000000031"), null, new Guid("d9a3f45c-81ae-4b86-b477-050000000031"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyMide PA612-CF", new Guid("d9a3f45c-81ae-4b86-b477-040000000009"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-050000000032"), null, new Guid("d9a3f45c-81ae-4b86-b477-050000000032"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyMide PA12-CF", new Guid("d9a3f45c-81ae-4b86-b477-04000000000b"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-050000000033"), null, new Guid("d9a3f45c-81ae-4b86-b477-050000000033"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolySmooth", new Guid("d9a3f45c-81ae-4b86-b477-040000000007"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-050000000034"), null, new Guid("d9a3f45c-81ae-4b86-b477-050000000034"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyCast", new Guid("d9a3f45c-81ae-4b86-b477-04000000000d"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-050000000035"), null, new Guid("d9a3f45c-81ae-4b86-b477-050000000035"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolySupport for PLA", new Guid("d9a3f45c-81ae-4b86-b477-040000000015"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-050000000036"), null, new Guid("d9a3f45c-81ae-4b86-b477-050000000036"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolySupport for PA12", new Guid("d9a3f45c-81ae-4b86-b477-040000000015"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-050000000037"), null, new Guid("d9a3f45c-81ae-4b86-b477-050000000037"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PolyDissolve", new Guid("d9a3f45c-81ae-4b86-b477-04000000000c"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-050000000038"), null, new Guid("d9a3f45c-81ae-4b86-b477-050000000038"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Prusament PLA", new Guid("d9a3f45c-81ae-4b86-b477-040000000001"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-050000000039"), null, new Guid("d9a3f45c-81ae-4b86-b477-050000000039"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Prusament rPLA", new Guid("d9a3f45c-81ae-4b86-b477-040000000001"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-05000000003a"), null, new Guid("d9a3f45c-81ae-4b86-b477-05000000003a"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Prusament PETG", new Guid("d9a3f45c-81ae-4b86-b477-040000000002"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-05000000003b"), null, new Guid("d9a3f45c-81ae-4b86-b477-05000000003b"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Prusament PC Blend", new Guid("d9a3f45c-81ae-4b86-b477-040000000006"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-05000000003c"), null, new Guid("d9a3f45c-81ae-4b86-b477-05000000003c"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Prusament PVB", new Guid("d9a3f45c-81ae-4b86-b477-040000000007"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-05000000003d"), null, new Guid("d9a3f45c-81ae-4b86-b477-05000000003d"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Prusament ASA", new Guid("d9a3f45c-81ae-4b86-b477-040000000003"), null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-05000000003e"), null, new Guid("d9a3f45c-81ae-4b86-b477-05000000003e"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Prusament PA11 Carbon Fiber", new Guid("d9a3f45c-81ae-4b86-b477-040000000016"), null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brand_CreatedById",
                table: "Brand",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Brand_DeletedById",
                table: "Brand",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Brand_UpdatedById",
                table: "Brand",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Polymer_CreatedById",
                table: "Polymer",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Polymer_DeletedById",
                table: "Polymer",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Polymer_UpdatedById",
                table: "Polymer",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLine_BrandId",
                table: "ProductLine",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLine_CreatedById",
                table: "ProductLine",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLine_DeletedById",
                table: "ProductLine",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLine_PolymerId",
                table: "ProductLine",
                column: "PolymerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLine_UpdatedById",
                table: "ProductLine",
                column: "UpdatedById");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductLine");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Polymer");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D9A3F45C-81AE-4B86-B477-010000000001");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "D9A3F45C-81AE-4B86-B477-020000000001");
        }
    }
}
