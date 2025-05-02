using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library_Manager.Migrations
{
    /// <inheritdoc />
    public partial class FixCopiesAvailableType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE \"Books\" ALTER COLUMN \"CopiesAvailable\" TYPE integer USING \"CopiesAvailable\"::integer;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CopiesAvailable",
                table: "Books",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}
