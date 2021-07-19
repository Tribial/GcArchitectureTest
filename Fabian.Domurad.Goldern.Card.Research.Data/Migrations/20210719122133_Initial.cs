using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fabian.Domurad.Golden.Card.Research.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    RemovedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localization", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    RemovedAt = table.Column<DateTime>(nullable: true),
                    Username = table.Column<string>(maxLength: 128, nullable: false),
                    Firstname = table.Column<string>(maxLength: 128, nullable: false),
                    Lastname = table.Column<string>(maxLength: 128, nullable: false),
                    Email = table.Column<string>(maxLength: 128, nullable: false),
                    PasswordHash = table.Column<string>(maxLength: 256, nullable: false),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Floor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    RemovedAt = table.Column<DateTime>(nullable: true),
                    Number = table.Column<int>(nullable: false),
                    LocalizationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Floor_Localization_LocalizationId",
                        column: x => x.LocalizationId,
                        principalTable: "Localization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Desk",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    RemovedAt = table.Column<DateTime>(nullable: true),
                    DeskNumber = table.Column<int>(nullable: false),
                    RoomNumber = table.Column<int>(nullable: false),
                    IsLifted = table.Column<bool>(nullable: false),
                    IsUnavailable = table.Column<bool>(nullable: false),
                    Location = table.Column<int>(nullable: false),
                    Tribe = table.Column<string>(maxLength: 128, nullable: false),
                    OwnerId = table.Column<Guid>(nullable: true),
                    FloorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desk", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Desk_Floor_FloorId",
                        column: x => x.FloorId,
                        principalTable: "Floor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Desk_User_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DeskBooking",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    RemovedAt = table.Column<DateTime>(nullable: true),
                    BookDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    DeskId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeskBooking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeskBooking_Desk_DeskId",
                        column: x => x.DeskId,
                        principalTable: "Desk",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeskBooking_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Desk_FloorId",
                table: "Desk",
                column: "FloorId");

            migrationBuilder.CreateIndex(
                name: "IX_Desk_OwnerId",
                table: "Desk",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_DeskBooking_BookDate",
                table: "DeskBooking",
                column: "BookDate");

            migrationBuilder.CreateIndex(
                name: "IX_DeskBooking_DeskId",
                table: "DeskBooking",
                column: "DeskId");

            migrationBuilder.CreateIndex(
                name: "IX_DeskBooking_UserId",
                table: "DeskBooking",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Floor_LocalizationId",
                table: "Floor",
                column: "LocalizationId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Username",
                table: "User",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeskBooking");

            migrationBuilder.DropTable(
                name: "Desk");

            migrationBuilder.DropTable(
                name: "Floor");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Localization");
        }
    }
}
