using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataToFolders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Folders_Folders_ParentFolderId",
                table: "Folders");

            migrationBuilder.AlterColumn<int>(
                name: "ParentFolderId",
                table: "Folders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Id", "Name", "ParentFolderId" },
                values: new object[,]
                {
                    { 1, "Creating Digital Images", null },
                    { 2, "Resourses", 1 },
                    { 3, "Evidence", 1 },
                    { 4, "Graphic Products", 1 },
                    { 5, "Primary Sourses", 2 },
                    { 6, "Secondary Sourses", 2 },
                    { 7, "Process", 4 },
                    { 8, "Final Product", 4 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Folders_Folders_ParentFolderId",
                table: "Folders",
                column: "ParentFolderId",
                principalTable: "Folders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Folders_Folders_ParentFolderId",
                table: "Folders");

            migrationBuilder.DeleteData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "ParentFolderId",
                table: "Folders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Folders_Folders_ParentFolderId",
                table: "Folders",
                column: "ParentFolderId",
                principalTable: "Folders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
