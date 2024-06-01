using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EgitimTakip.Data.Migrations
{
    /// <inheritdoc />
    public partial class addTrainingCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingsSubjectsMap_TrainingSubjects_TrainingSubjectsId",
                table: "TrainingsSubjectsMap");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingsSubjectsMap_Trainings_TrainingId",
                table: "TrainingsSubjectsMap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingsSubjectsMap",
                table: "TrainingsSubjectsMap");

            migrationBuilder.RenameTable(
                name: "TrainingsSubjectsMap",
                newName: "TrainingsSubjectsMaps");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingsSubjectsMap_TrainingSubjectsId",
                table: "TrainingsSubjectsMaps",
                newName: "IX_TrainingsSubjectsMaps_TrainingSubjectsId");

            migrationBuilder.AddColumn<int>(
                name: "TrainingCategoryId",
                table: "TrainingSubjects",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingsSubjectsMaps",
                table: "TrainingsSubjectsMaps",
                columns: new[] { "TrainingId", "TrainingSubjectsId" });

            migrationBuilder.CreateTable(
                name: "TrainingCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingSubjects_TrainingCategoryId",
                table: "TrainingSubjects",
                column: "TrainingCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingsSubjectsMaps_TrainingSubjects_TrainingSubjectsId",
                table: "TrainingsSubjectsMaps",
                column: "TrainingSubjectsId",
                principalTable: "TrainingSubjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingsSubjectsMaps_Trainings_TrainingId",
                table: "TrainingsSubjectsMaps",
                column: "TrainingId",
                principalTable: "Trainings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingSubjects_TrainingCategories_TrainingCategoryId",
                table: "TrainingSubjects",
                column: "TrainingCategoryId",
                principalTable: "TrainingCategories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingsSubjectsMaps_TrainingSubjects_TrainingSubjectsId",
                table: "TrainingsSubjectsMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingsSubjectsMaps_Trainings_TrainingId",
                table: "TrainingsSubjectsMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingSubjects_TrainingCategories_TrainingCategoryId",
                table: "TrainingSubjects");

            migrationBuilder.DropTable(
                name: "TrainingCategories");

            migrationBuilder.DropIndex(
                name: "IX_TrainingSubjects_TrainingCategoryId",
                table: "TrainingSubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingsSubjectsMaps",
                table: "TrainingsSubjectsMaps");

            migrationBuilder.DropColumn(
                name: "TrainingCategoryId",
                table: "TrainingSubjects");

            migrationBuilder.RenameTable(
                name: "TrainingsSubjectsMaps",
                newName: "TrainingsSubjectsMap");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingsSubjectsMaps_TrainingSubjectsId",
                table: "TrainingsSubjectsMap",
                newName: "IX_TrainingsSubjectsMap_TrainingSubjectsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingsSubjectsMap",
                table: "TrainingsSubjectsMap",
                columns: new[] { "TrainingId", "TrainingSubjectsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingsSubjectsMap_TrainingSubjects_TrainingSubjectsId",
                table: "TrainingsSubjectsMap",
                column: "TrainingSubjectsId",
                principalTable: "TrainingSubjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingsSubjectsMap_Trainings_TrainingId",
                table: "TrainingsSubjectsMap",
                column: "TrainingId",
                principalTable: "Trainings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
