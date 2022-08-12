using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RRMemberRegister.Server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fornamn = table.Column<string>(nullable: false),
                    Efternamn = table.Column<string>(nullable: false),
                    Adress = table.Column<string>(nullable: false),
                    Postnummer = table.Column<string>(nullable: false),
                    Postort = table.Column<string>(nullable: false),
                    Skapatdatum = table.Column<DateTime>(nullable: false),
                    Senastuppdateraddatum = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "Adress", "Efternamn", "Fornamn", "Postnummer", "Postort", "Senastuppdateraddatum", "Skapatdatum" },
                values: new object[,]
                {
                    { 1, "Adress 1", "Efternamn 1", "Fornamn 1", "111111", "Postort 1", new DateTime(2020, 9, 22, 23, 20, 11, 556, DateTimeKind.Local).AddTicks(377), new DateTime(2020, 9, 22, 23, 20, 11, 556, DateTimeKind.Local).AddTicks(377) },
                    { 2, "Adress 2", "Efternamn 2", "Fornamn 2", "222222", "Postort 2", new DateTime(2020, 9, 22, 23, 20, 11, 556, DateTimeKind.Local).AddTicks(377), new DateTime(2020, 9, 22, 23, 20, 11, 556, DateTimeKind.Local).AddTicks(377) },
                    { 3, "Adress 3", "Efternamn 3", "Fornamn 3", "33333", "Postort 3", new DateTime(2020, 9, 22, 23, 20, 11, 556, DateTimeKind.Local).AddTicks(377), new DateTime(2020, 9, 22, 23, 20, 11, 556, DateTimeKind.Local).AddTicks(377) },
                    { 4, "Adress 4", "Efternamn 4", "Fornamn 4", "44444", "Postort 4", new DateTime(2020, 9, 22, 23, 20, 11, 556, DateTimeKind.Local).AddTicks(377), new DateTime(2020, 9, 22, 23, 20, 11, 556, DateTimeKind.Local).AddTicks(377) },
                    { 5, "Adress 5", "Efternamn 5", "Fornamn 5", "55555", "Postort 5", new DateTime(2020, 9, 22, 23, 20, 11, 556, DateTimeKind.Local).AddTicks(377), new DateTime(2020, 9, 22, 23, 20, 11, 556, DateTimeKind.Local).AddTicks(377) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
