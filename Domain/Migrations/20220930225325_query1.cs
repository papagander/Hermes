using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class query1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FieldTypeOperators_OperatorId",
                table: "FieldTypeOperators");

            migrationBuilder.AddUniqueConstraint(
                name: "FieldTypeOperator",
                table: "FieldTypeOperators",
                columns: new[] { "OperatorId", "FieldTypeId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "FieldTypeOperator",
                table: "FieldTypeOperators");

            migrationBuilder.CreateIndex(
                name: "IX_FieldTypeOperators_OperatorId",
                table: "FieldTypeOperators",
                column: "OperatorId");
        }
    }
}
