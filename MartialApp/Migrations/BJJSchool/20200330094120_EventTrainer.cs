using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MartialApp.Migrations.BJJSchool
{
    public partial class EventTrainer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduleTrainer");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.CreateTable(
                name: "EventTrainer",
                columns: table => new
                {
                    EventTrainerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainerId = table.Column<int>(nullable: true),
                    EventId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTrainer", x => x.EventTrainerId);
                    table.ForeignKey(
                        name: "FK_EventTrainer_Event",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventTrainer_Trainer",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "TrainerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventTrainer_EventId",
                table: "EventTrainer",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTrainer_TrainerId",
                table: "EventTrainer",
                column: "TrainerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventTrainer");

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    SheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    SheduleEnd = table.Column<DateTime>(type: "datetime", nullable: false),
                    SheduleStart = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.SheduleId);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleTrainer",
                columns: table => new
                {
                    ScheduleTrainerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduleId = table.Column<int>(type: "int", nullable: true),
                    TrainerId = table.Column<int>(type: "int", nullable: true),
                    TrainersTrainerId = table.Column<int>(type: "int", nullable: true)
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
    }
}
