using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class k : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conjoiner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conjoiner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FieldSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExecutionString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Field",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FieldSetId = table.Column<int>(type: "int", nullable: false),
                    DbType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false)
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
                name: "OperatorFieldType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperatorId = table.Column<int>(type: "int", nullable: false),
                    DbType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatorFieldType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperatorFieldType_Operator_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "Operator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parameter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperatorId = table.Column<int>(type: "int", nullable: false),
                    DbType = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parameter_Operator_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "Operator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conjunction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConjoinerId = table.Column<int>(type: "int", nullable: false),
                    StatementId = table.Column<int>(type: "int", nullable: false)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentConjunctionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statement_Conjunction_ParentConjunctionId",
                        column: x => x.ParentConjunctionId,
                        principalTable: "Conjunction",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Operation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FieldId = table.Column<int>(type: "int", nullable: false),
                    OperatorId = table.Column<int>(type: "int", nullable: false),
                    StatementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operation_Field_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Field",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Operation_Operator_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "Operator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Operation_Statement_StatementId",
                        column: x => x.StatementId,
                        principalTable: "Statement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Query",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FieldSetId = table.Column<int>(type: "int", nullable: false),
                    StatementId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false)
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
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OperationParameter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperationId = table.Column<int>(type: "int", nullable: false),
                    ParameterId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationParameter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperationParameter_Operation_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OperationParameter_Parameter_ParameterId",
                        column: x => x.ParameterId,
                        principalTable: "Parameter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FieldQuery",
                columns: table => new
                {
                    FieldsId = table.Column<int>(type: "int", nullable: false),
                    QueriesId = table.Column<int>(type: "int", nullable: false)
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
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conjoiner_Id",
                table: "Conjoiner",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Conjunction_ConjoinerId",
                table: "Conjunction",
                column: "ConjoinerId");

            migrationBuilder.CreateIndex(
                name: "IX_Conjunction_Id",
                table: "Conjunction",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Conjunction_StatementId",
                table: "Conjunction",
                column: "StatementId");

            migrationBuilder.CreateIndex(
                name: "IX_Field_FieldSetId",
                table: "Field",
                column: "FieldSetId");

            migrationBuilder.CreateIndex(
                name: "IX_Field_Id",
                table: "Field",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_FieldQuery_QueriesId",
                table: "FieldQuery",
                column: "QueriesId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldSet_Id",
                table: "FieldSet",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_FieldId",
                table: "Operation",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_Id",
                table: "Operation",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_OperatorId",
                table: "Operation",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_StatementId",
                table: "Operation",
                column: "StatementId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationParameter_Id",
                table: "OperationParameter",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OperationParameter_OperationId",
                table: "OperationParameter",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationParameter_ParameterId",
                table: "OperationParameter",
                column: "ParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_Operator_Id",
                table: "Operator",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OperatorFieldType_Id",
                table: "OperatorFieldType",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OperatorFieldType_OperatorId",
                table: "OperatorFieldType",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Parameter_Id",
                table: "Parameter",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Parameter_OperatorId",
                table: "Parameter",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Query_FieldSetId",
                table: "Query",
                column: "FieldSetId");

            migrationBuilder.CreateIndex(
                name: "IX_Query_Id",
                table: "Query",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Query_StatementId",
                table: "Query",
                column: "StatementId");

            migrationBuilder.CreateIndex(
                name: "IX_Statement_ParentConjunctionId",
                table: "Statement",
                column: "ParentConjunctionId");

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
                name: "FieldQuery");

            migrationBuilder.DropTable(
                name: "OperationParameter");

            migrationBuilder.DropTable(
                name: "OperatorFieldType");

            migrationBuilder.DropTable(
                name: "Query");

            migrationBuilder.DropTable(
                name: "Operation");

            migrationBuilder.DropTable(
                name: "Parameter");

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
