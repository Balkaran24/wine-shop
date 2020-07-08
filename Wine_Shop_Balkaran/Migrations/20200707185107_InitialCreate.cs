using Microsoft.EntityFrameworkCore.Migrations;

namespace Wine_Shop_Balkaran.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RateListMasters",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateListMasters", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WineMasters",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WineMasters", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerMasters",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Age = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    RateListMasterID = table.Column<int>(nullable: true),
                    WineMasterID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerMasters", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomerMasters_RateListMasters_RateListMasterID",
                        column: x => x.RateListMasterID,
                        principalTable: "RateListMasters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerMasters_WineMasters_WineMasterID",
                        column: x => x.WineMasterID,
                        principalTable: "WineMasters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerMasters_RateListMasterID",
                table: "CustomerMasters",
                column: "RateListMasterID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerMasters_WineMasterID",
                table: "CustomerMasters",
                column: "WineMasterID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerMasters");

            migrationBuilder.DropTable(
                name: "RateListMasters");

            migrationBuilder.DropTable(
                name: "WineMasters");
        }
    }
}
