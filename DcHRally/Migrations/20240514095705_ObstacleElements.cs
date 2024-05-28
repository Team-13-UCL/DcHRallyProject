using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RallyBaneTest.Migrations
{
    /// <inheritdoc />
    public partial class ObstacleElements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ObstacleElements",
                columns: table => new
                {
                    ObstacleElementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObstacleElements", x => x.ObstacleElementId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ObstacleElements");
        }
    }
}
