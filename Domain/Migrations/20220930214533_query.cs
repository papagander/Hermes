using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class query : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conjoiners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conjoiners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FieldTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FieldTypeOperators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FieldTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    OperatorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldTypeOperators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldTypeOperators_FieldTypes_FieldTypeId",
                        column: x => x.FieldTypeId,
                        principalTable: "FieldTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FieldTypeOperators_Operators_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "Operators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conjunctions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ConjoinerId = table.Column<int>(type: "INTEGER", nullable: false),
                    StatementId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conjunctions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conjunctions_Conjoiners_ConjoinerId",
                        column: x => x.ConjoinerId,
                        principalTable: "Conjoiners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Statements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ConjunctionId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statements_Conjunctions_ConjunctionId",
                        column: x => x.ConjunctionId,
                        principalTable: "Conjunctions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Queries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataSetId = table.Column<int>(type: "INTEGER", nullable: false),
                    StatementId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Queries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Queries_DataSets_DataSetId",
                        column: x => x.DataSetId,
                        principalTable: "DataSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Queries_Statements_StatementId",
                        column: x => x.StatementId,
                        principalTable: "Statements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataSetId = table.Column<int>(type: "INTEGER", nullable: false),
                    FieldTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    QueryId = table.Column<int>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fields_DataSets_DataSetId",
                        column: x => x.DataSetId,
                        principalTable: "DataSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fields_FieldTypes_FieldTypeId",
                        column: x => x.FieldTypeId,
                        principalTable: "FieldTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fields_Queries_QueryId",
                        column: x => x.QueryId,
                        principalTable: "Queries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Criteria",
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
                    table.PrimaryKey("PK_Criteria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Criteria_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Criteria_Operators_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "Operators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Criteria_Statements_StatementId",
                        column: x => x.StatementId,
                        principalTable: "Statements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QueryFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QueryId = table.Column<int>(type: "INTEGER", nullable: false),
                    FieldId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QueryFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QueryFields_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QueryFields_Queries_QueryId",
                        column: x => x.QueryId,
                        principalTable: "Queries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CriterionValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CriterionId = table.Column<int>(type: "INTEGER", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CriterionValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CriterionValues_Criteria_CriterionId",
                        column: x => x.CriterionId,
                        principalTable: "Criteria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conjunctions_ConjoinerId",
                table: "Conjunctions",
                column: "ConjoinerId");

            migrationBuilder.CreateIndex(
                name: "IX_Conjunctions_StatementId",
                table: "Conjunctions",
                column: "StatementId");

            migrationBuilder.CreateIndex(
                name: "IX_Criteria_FieldId",
                table: "Criteria",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Criteria_OperatorId",
                table: "Criteria",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Criteria_StatementId",
                table: "Criteria",
                column: "StatementId");

            migrationBuilder.CreateIndex(
                name: "IX_CriterionValues_CriterionId",
                table: "CriterionValues",
                column: "CriterionId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_DataSetId",
                table: "Fields",
                column: "DataSetId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_FieldTypeId",
                table: "Fields",
                column: "FieldTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_QueryId",
                table: "Fields",
                column: "QueryId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldTypeOperators_FieldTypeId",
                table: "FieldTypeOperators",
                column: "FieldTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldTypeOperators_OperatorId",
                table: "FieldTypeOperators",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Queries_DataSetId",
                table: "Queries",
                column: "DataSetId");

            migrationBuilder.CreateIndex(
                name: "IX_Queries_StatementId",
                table: "Queries",
                column: "StatementId");

            migrationBuilder.CreateIndex(
                name: "IX_QueryFields_FieldId",
                table: "QueryFields",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_QueryFields_QueryId",
                table: "QueryFields",
                column: "QueryId");

            migrationBuilder.CreateIndex(
                name: "IX_Statements_ConjunctionId",
                table: "Statements",
                column: "ConjunctionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conjunctions_Statements_StatementId",
                table: "Conjunctions",
                column: "StatementId",
                principalTable: "Statements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conjunctions_Conjoiners_ConjoinerId",
                table: "Conjunctions");

            migrationBuilder.DropForeignKey(
                name: "FK_Conjunctions_Statements_StatementId",
                table: "Conjunctions");

            migrationBuilder.DropTable(
                name: "CriterionValues");

            migrationBuilder.DropTable(
                name: "FieldTypeOperators");

            migrationBuilder.DropTable(
                name: "QueryFields");

            migrationBuilder.DropTable(
                name: "Criteria");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropTable(
                name: "Operators");

            migrationBuilder.DropTable(
                name: "FieldTypes");

            migrationBuilder.DropTable(
                name: "Queries");

            migrationBuilder.DropTable(
                name: "DataSets");

            migrationBuilder.DropTable(
                name: "Conjoiners");

            migrationBuilder.DropTable(
                name: "Statements");

            migrationBuilder.DropTable(
                name: "Conjunctions");
        }
    }
}
