using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MartialApp.Migrations.BJJSchool
{
    public partial class MartialAppDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Belt",
                columns: table => new
                {
                    BeltId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Colour = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Belt", x => x.BeltId);
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    DiscountId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discount = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.DiscountId);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Start = table.Column<string>(nullable: true),
                    End = table.Column<string>(nullable: true),
                    AllDay = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaimentId = table.Column<int>(nullable: false),
                    Paid = table.Column<DateTime>(type: "datetime", nullable: false),
                    Amount = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaimentId);
                });

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
                name: "School",
                columns: table => new
                {
                    SchoolId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    NickName = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School", x => x.SchoolId);
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    TrainerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 255, nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    LastName = table.Column<string>(maxLength: 255, nullable: true),
                    LastName2 = table.Column<string>(maxLength: 255, nullable: true),
                    SchoolId = table.Column<int>(nullable: true),
                    BeltId = table.Column<int>(nullable: true),
                    Phone = table.Column<string>(maxLength: 255, nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Tarifa = table.Column<string>(maxLength: 255, nullable: true),
                    Importe = table.Column<double>(nullable: true),
                    UserGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.TrainerId);
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

            migrationBuilder.CreateTable(
                name: "TrainerPayment",
                columns: table => new
                {
                    TrainerPaymentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainerId = table.Column<int>(nullable: true),
                    PaymentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerPayment", x => x.TrainerPaymentId);
                    table.ForeignKey(
                        name: "FK_TrainerPayment_Payment",
                        column: x => x.PaymentId,
                        principalTable: "Payment",
                        principalColumn: "PaimentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainerPayment_Trainers",
                        column: x => x.TrainerId,
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

            migrationBuilder.CreateIndex(
                name: "IX_TrainerPayment_PaymentId",
                table: "TrainerPayment",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerPayment_TrainerId",
                table: "TrainerPayment",
                column: "TrainerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Belt");

            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "ScheduleTrainer");

            migrationBuilder.DropTable(
                name: "School");

            migrationBuilder.DropTable(
                name: "TrainerPayment");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Trainers");
        }
    }
}
