using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EgitimTakip.Data.Migrations
{
    /// <inheritdoc />
    public partial class addTrainingSubjectsManuelMapTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainingsSubjectsMap",
                columns: table => new
                {
                    TrainingId = table.Column<int>(type: "int", nullable: false),
                    TrainingSubjectsId = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingsSubjectsMap", x => new { x.TrainingId, x.TrainingSubjectsId });
                    table.ForeignKey(
                        name: "FK_TrainingsSubjectsMap_TrainingSubjects_TrainingSubjectsId",
                        column: x => x.TrainingSubjectsId,
                        principalTable: "TrainingSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingsSubjectsMap_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingsSubjectsMap_TrainingSubjectsId",
                table: "TrainingsSubjectsMap",
                column: "TrainingSubjectsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainingsSubjectsMap");
        }
    }
}
