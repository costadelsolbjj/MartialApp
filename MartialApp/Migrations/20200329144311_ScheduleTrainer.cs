using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MartialApp.Migrations
{
    public partial class ScheduleTrainer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    SheduleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SheduleStart = table.Column<DateTime>(type: "datetime", nullable: false),
                    SheduleEnd = table.Column<DateTime>(type: "datetime", nullable: false),
                    LessonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.SheduleId);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleTrainer",
                columns: table => new
                {
                    ScheduleTrainerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainerId = table.Column<int>(nullable: true),
                    ScheduleId = table.Column<int>(nullable: true),
                    TrainersTrainerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleTrainer", x => x.ScheduleTrainerId);
                    table.ForeignKey(
                        name: "FK_ScheduleTrainer_Schedule",
                        column: x => x.ScheduleId,
                        principalTable: "Schedule",
                        principalColumn: "SheduleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduleTrainer_Trainers_TrainersTrainerId",
                        column: x => x.TrainersTrainerId,
                        principalTable: "Trainers",
                        principalColumn: "TrainerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleTrainer_ScheduleId",
                table: "ScheduleTrainer",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleTrainer_TrainersTrainerId",
                table: "ScheduleTrainer",
                column: "TrainersTrainerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduleTrainer");

            migrationBuilder.DropTable(
                name: "Schedule");
        }
    }
}
