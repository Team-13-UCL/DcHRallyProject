using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DcHRally.Migrations
{
    /// <inheritdoc />
    public partial class FixedTrackImplementationWithCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            IF OBJECT_ID(N'[dbo].[Tracks]', N'U') IS NOT NULL
            BEGIN
                IF EXISTS (SELECT 1 FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Tracks_Category_CategoryId]'))
                BEGIN
                    ALTER TABLE [Tracks] DROP CONSTRAINT [FK_Tracks_Category_CategoryId];
                END
            END
        ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            IF OBJECT_ID(N'[dbo].[Tracks]', N'U') IS NOT NULL
            BEGIN
                IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Tracks_Category_CategoryId]'))
                BEGIN
                    ALTER TABLE [Tracks] ADD CONSTRAINT [FK_Tracks_Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]);
                END
            END
        ");
        }
    }
}
