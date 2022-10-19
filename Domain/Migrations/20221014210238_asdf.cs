using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class asdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conjoiner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conjoiner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FieldSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExecutionString = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Field",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FieldSetId = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Field", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Field_FieldSet_FieldSetId",
                        column: x => x.FieldSetId,
                        principalTable: "FieldSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperatorFieldTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OperatorId = table.Column<int>(type: "INTEGER", nullable: false),
                    DbType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatorFieldTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperatorFieldTypes_Operator_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "Operator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OperatorId = table.Column<int>(type: "INTEGER", nullable: false),
                    DbType = table.Column<int>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parameters_Operator_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "Operator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conjunction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ConjoinerId = table.Column<int>(type: "INTEGER", nullable: false),
                    StatementId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conjunction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conjunction_Conjoiner_ConjoinerId",
                        column: x => x.ConjoinerId,
                        principalTable: "Conjoiner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Statement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ConjunctionId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statement_Conjunction_ConjunctionId",
                        column: x => x.ConjunctionId,
                        principalTable: "Conjunction",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Criterion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FieldId = table.Column<int>(type: "INTEGER", nullable: false),
                    OperatorId = table.Column<int>(type: "INTEGER", nullable: false),
                    StatementId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Criterion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Criterion_Field_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Field",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Criterion_Operator_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "Operator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Criterion_Statement_StatementId",
                        column: x => x.StatementId,
                        principalTable: "Statement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Query",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataSetId = table.Column<int>(type: "INTEGER", nullable: false),
                    StatementId = table.Column<int>(type: "INTEGER", nullable: false),
                    FieldSetId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Query", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Query_FieldSet_FieldSetId",
                        column: x => x.FieldSetId,
                        principalTable: "FieldSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Query_Statement_StatementId",
                        column: x => x.StatementId,
                        principalTable: "Statement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CriterionParamater",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CriterionId = table.Column<int>(type: "INTEGER", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CriterionValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CriterionValue_Criterion_CriterionId",
                        column: x => x.CriterionId,
                        principalTable: "Criterion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FieldQuery",
                columns: table => new
                {
                    FieldsId = table.Column<int>(type: "INTEGER", nullable: false),
                    QueriesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldQuery", x => new { x.FieldsId, x.QueriesId });
                    table.ForeignKey(
                        name: "FK_FieldQuery_Field_FieldsId",
                        column: x => x.FieldsId,
                        principalTable: "Field",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FieldQuery_Query_QueriesId",
                        column: x => x.QueriesId,
                        principalTable: "Query",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conjunction_ConjoinerId",
                table: "Conjunction",
                column: "ConjoinerId");

            migrationBuilder.CreateIndex(
                name: "IX_Conjunction_StatementId",
                table: "Conjunction",
                column: "StatementId");

            migrationBuilder.CreateIndex(
                name: "IX_Criterion_FieldId",
                table: "Criterion",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Criterion_OperatorId",
                table: "Criterion",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Criterion_StatementId",
                table: "Criterion",
                column: "StatementId");

            migrationBuilder.CreateIndex(
                name: "IX_CriterionValue_CriterionId",
                table: "CriterionParamater",
                column: "CriterionId");

            migrationBuilder.CreateIndex(
                name: "IX_Field_FieldSetId",
                table: "Field",
                column: "FieldSetId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldQuery_QueriesId",
                table: "FieldQuery",
                column: "QueriesId");

            migrationBuilder.CreateIndex(
                name: "IX_OperatorFieldTypes_OperatorId",
                table: "OperatorFieldTypes",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Parameters_OperatorId",
                table: "Parameters",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Query_FieldSetId",
                table: "Query",
                column: "FieldSetId");

            migrationBuilder.CreateIndex(
                name: "IX_Query_StatementId",
                table: "Query",
                column: "StatementId");

            migrationBuilder.CreateIndex(
                name: "IX_Statement_ConjunctionId",
                table: "Statement",
                column: "ConjunctionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conjunction_Statement_StatementId",
                table: "Conjunction",
                column: "StatementId",
                principalTable: "Statement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conjunction_Conjoiner_ConjoinerId",
                table: "Conjunction");

            migrationBuilder.DropForeignKey(
                name: "FK_Conjunction_Statement_StatementId",
                table: "Conjunction");

            migrationBuilder.DropTable(
                name: "CriterionParamater");

            migrationBuilder.DropTable(
                name: "FieldQuery");

            migrationBuilder.DropTable(
                name: "OperatorFieldTypes");

            migrationBuilder.DropTable(
                name: "Parameters");

            migrationBuilder.DropTable(
                name: "Criterion");

            migrationBuilder.DropTable(
                name: "Query");

            migrationBuilder.DropTable(
                name: "Field");

            migrationBuilder.DropTable(
                name: "Operator");

            migrationBuilder.DropTable(
                name: "FieldSet");

            migrationBuilder.DropTable(
                name: "Conjoiner");

            migrationBuilder.DropTable(
                name: "Statement");

            migrationBuilder.DropTable(
                name: "Conjunction");
        }
    }
}
