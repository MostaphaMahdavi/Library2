using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.DataAccessCommands.Migrations
{
    public partial class init_01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookName = table.Column<string>(maxLength: 250, nullable: false),
                    ImageName = table.Column<string>(nullable: false),
                    Subject = table.Column<string>(maxLength: 250, nullable: false),
                    ShabekNo = table.Column<string>(maxLength: 100, nullable: false),
                    Content = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
