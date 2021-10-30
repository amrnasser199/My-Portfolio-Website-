using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Book_Store.Migrations
{
    public partial class Initialcr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "portfolio_Item",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    ProjectName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolio_Item", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "owner",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    FullName = table.Column<string>(nullable: true),
                    Profile = table.Column<string>(nullable: true),
                    AvatarImage = table.Column<string>(nullable: true),
                    AddressId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_owner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_owner_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "owner",
                columns: new[] { "Id", "AddressId", "AvatarImage", "FullName", "Profile" },
                values: new object[] { new Guid("dcf7cddb-4964-4172-a026-b56704e69bbb"), null, "amrbdla.jpg", "Amr Nasser", ".Net Developer/DB Adminstrator" });

            migrationBuilder.CreateIndex(
                name: "IX_owner_AddressId",
                table: "owner",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "owner");

            migrationBuilder.DropTable(
                name: "portfolio_Item");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
