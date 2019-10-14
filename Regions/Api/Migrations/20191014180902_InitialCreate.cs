using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Promomash.Regions.WebApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Type = table.Column<byte>(nullable: false),
                    ParentId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Region_Region_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Name", "ParentId", "Type" },
                values: new object[] { 1L, "Китай", null, (byte)1 });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Name", "ParentId", "Type" },
                values: new object[] { 2L, "Россия", null, (byte)1 });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Name", "ParentId", "Type" },
                values: new object[] { 3L, "Соединенные штаты Америки", null, (byte)1 });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Name", "ParentId", "Type" },
                values: new object[,]
                {
                    { 4L, "Аньхой", 1L, (byte)2 },
                    { 5L, "Фуцзянь", 1L, (byte)2 },
                    { 6L, "Московская область", 2L, (byte)2 },
                    { 7L, "Тульская область", 2L, (byte)2 },
                    { 8L, "Республика Калмыкия", 2L, (byte)2 },
                    { 9L, "Рязанская область", 2L, (byte)2 },
                    { 10L, "Аляска", 3L, (byte)2 },
                    { 11L, "Калифорния", 3L, (byte)2 },
                    { 12L, "Флорида", 3L, (byte)2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Region_ParentId",
                table: "Region",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Region");
        }
    }
}
