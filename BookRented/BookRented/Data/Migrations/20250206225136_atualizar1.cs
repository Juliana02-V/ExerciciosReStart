using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookRented.Migrations
{
    /// <inheritdoc />
    public partial class atualizar1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Edithors_EditorId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Edithors");

            migrationBuilder.CreateTable(
                name: "Editor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editor", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Editor_EditorId",
                table: "Books",
                column: "EditorId",
                principalTable: "Editor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Editor_EditorId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Editor");

            migrationBuilder.CreateTable(
                name: "Edithors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edithors", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Edithors_EditorId",
                table: "Books",
                column: "EditorId",
                principalTable: "Edithors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
