using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Filamentous.Migrations
{
    /// <inheritdoc />
    public partial class Brand : Migration
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
                    Url = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ProductUrlTemplate = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "D9A3F45C-81AE-4B86-B477-010000000001", "D9A3F45C-81AE-4B86-B477-010000000001", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "PasswordHash" },
                values: new object[] { "D9A3F45C-81AE-4B86-B477-020000000001", 0, "D9A3F45C-81AE-4B86-B477-020000000001", "scott@blomfield.us", true, false, null, "SCOTT@BLOMFIELD.US", "SCOTT@BLOMFIELD.US", "", null, false, "951c4567-cb77-49dd-9520-4de4583f9b55", false, "scott@blomfield.us", "AQAAAAIAAYagAAAAEBm+qE3vZ4hlMjyrKVdyjEtTZqnU/1XXi/Sh2ycOqU8PkBxc8e5VLe//Lw/iO9dslw==" });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreatedOn", "DeletedById", "DeletedOn", "Name", "ProductUrlTemplate", "SpoolUrlTemplate", "UpdatedById", "UpdatedOn", "Url" },
                values: new object[,]
                {
                    { new Guid("d9a3f45c-81ae-4b86-b477-030000000001"), new Guid("d9a3f45c-81ae-4b86-b477-030000000001"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Prusament", null, null, null, null, "https://prusa3d.com/" },
                    { new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), new Guid("d9a3f45c-81ae-4b86-b477-030000000002"), "d9a3f45c-81ae-4b86-b477-020000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Prusament", null, null, null, null, "https://us.polymaker.com/" }
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brand");

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
