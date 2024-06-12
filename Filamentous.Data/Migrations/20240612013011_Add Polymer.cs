using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Filamentous.Migrations
{
    /// <inheritdoc />
    public partial class AddPolymer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Brand",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductUrlTemplate",
                table: "Brand",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

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
                    PolymerTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "D9A3F45C-81AE-4B86-B477-020000000001",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAIAAYagAAAAEBm+qE3vZ4hlMjyrKVdyjEtTZqnU/1XXi/Sh2ycOqU8PkBxc8e5VLe//Lw/iO9dslw==", "9daddc3b-b7cd-4079-9b41-a5f23f1b3b3f" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-030000000001"),
                column: "Url",
                value: null);

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-030000000002"),
                column: "Url",
                value: null);

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
                    { new Guid("d9a3f45c-81ae-4b86-b477-040000000010"), new Guid("d9a3f45c-81ae-4b86-b477-040000000010"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PA6-GF", null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-040000000011"), new Guid("d9a3f45c-81ae-4b86-b477-040000000011"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PA12-CF", null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-040000000012"), new Guid("d9a3f45c-81ae-4b86-b477-040000000012"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PVA", null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-040000000013"), new Guid("d9a3f45c-81ae-4b86-b477-040000000013"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PCL", null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-040000000014"), new Guid("d9a3f45c-81ae-4b86-b477-040000000014"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PPS", null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-040000000015"), new Guid("d9a3f45c-81ae-4b86-b477-040000000015"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PS", null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-040000000016"), new Guid("d9a3f45c-81ae-4b86-b477-040000000016"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PSU", null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-040000000017"), new Guid("d9a3f45c-81ae-4b86-b477-040000000017"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PPSU", null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-040000000018"), new Guid("d9a3f45c-81ae-4b86-b477-040000000018"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PPA", null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-040000000019"), new Guid("d9a3f45c-81ae-4b86-b477-040000000019"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PEEK", null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-040000000020"), new Guid("d9a3f45c-81ae-4b86-b477-040000000020"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PEKK", null, null },
                    { new Guid("d9a3f45c-81ae-4b86-b477-040000000021"), new Guid("d9a3f45c-81ae-4b86-b477-040000000021"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Other", null, null }
                });

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
                name: "Polymer");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Brand",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductUrlTemplate",
                table: "Brand",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "D9A3F45C-81AE-4B86-B477-020000000001",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "", "951c4567-cb77-49dd-9520-4de4583f9b55" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-030000000001"),
                column: "Url",
                value: "https://prusa3d.com/");

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("d9a3f45c-81ae-4b86-b477-030000000002"),
                column: "Url",
                value: "https://us.polymaker.com/");
        }
    }
}
