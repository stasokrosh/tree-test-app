using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TreeApp.DB.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TreeNode",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    RootId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreeNode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreeNode_TreeNode_ParentId",
                        column: x => x.ParentId,
                        principalTable: "TreeNode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TreeNode_TreeNode_RootId",
                        column: x => x.RootId,
                        principalTable: "TreeNode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TreeNode_ParentId_Name",
                table: "TreeNode",
                columns: new[] { "ParentId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TreeNode_RootId",
                table: "TreeNode",
                column: "RootId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TreeNode");
        }
    }
}
