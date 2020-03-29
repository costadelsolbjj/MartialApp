﻿// <auto-generated />
using System;
using MartialApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MartialApp.Migrations
{
    [DbContext(typeof(BJJSchoolContext))]
    [Migration("20200329144311_ScheduleTrainer")]
    partial class ScheduleTrainer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MartialApp.Models.Belt", b =>
                {
                    b.Property<int>("BeltId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Colour")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("BeltId");

                    b.ToTable("Belt");
                });

            modelBuilder.Entity("MartialApp.Models.Discount", b =>
                {
                    b.Property<int>("DiscountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discount1")
                        .IsRequired()
                        .HasColumnName("Discount")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("DiscountId");

                    b.ToTable("Discount");
                });

            modelBuilder.Entity("MartialApp.Models.Payment", b =>
                {
                    b.Property<int>("PaimentId")
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("money");

                    b.Property<DateTime>("Paid")
                        .HasColumnType("datetime");

                    b.HasKey("PaimentId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("MartialApp.Models.Schedule", b =>
                {
                    b.Property<int>("SheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LessonId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SheduleEnd")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("SheduleStart")
                        .HasColumnType("datetime");

                    b.HasKey("SheduleId")
                        .HasName("PK_Schedule");

                    b.ToTable("Schedule");
                });

            modelBuilder.Entity("MartialApp.Models.ScheduleTrainer", b =>
                {
                    b.Property<int>("ScheduleTrainerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ScheduleId")
                        .HasColumnType("int");

                    b.Property<int?>("TrainerId")
                        .HasColumnType("int");

                    b.Property<int?>("TrainersTrainerId")
                        .HasColumnType("int");

                    b.HasKey("ScheduleTrainerId");

                    b.HasIndex("ScheduleId");

                    b.HasIndex("TrainersTrainerId");

                    b.ToTable("ScheduleTrainer");
                });

            modelBuilder.Entity("MartialApp.Models.School", b =>
                {
                    b.Property<int>("SchoolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("NickName")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("SchoolId");

                    b.ToTable("School");
                });

            modelBuilder.Entity("MartialApp.Models.TrainerPayment", b =>
                {
                    b.Property<int>("TrainerPaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PaymentId")
                        .HasColumnType("int");

                    b.Property<int?>("TrainerId")
                        .HasColumnType("int");

                    b.HasKey("TrainerPaymentId");

                    b.HasIndex("PaymentId");

                    b.HasIndex("TrainerId");

                    b.ToTable("TrainerPayment");
                });

            modelBuilder.Entity("MartialApp.Models.Trainers", b =>
                {
                    b.Property<int>("TrainerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BeltId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime");

                    b.Property<double?>("Importe")
                        .HasColumnType("float");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("LastName2")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<int?>("SchoolId")
                        .HasColumnType("int");

                    b.Property<string>("Tarifa")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<Guid>("UserGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("TrainerId")
                        .HasName("PK_Users");

                    b.ToTable("Trainers");
                });

            modelBuilder.Entity("MartialApp.Models.ScheduleTrainer", b =>
                {
                    b.HasOne("MartialApp.Models.Schedule", "Schedule")
                        .WithMany("ScheduleTrainer")
                        .HasForeignKey("ScheduleId")
                        .HasConstraintName("FK_ScheduleTrainer_Schedule");

                    b.HasOne("MartialApp.Models.Trainers", "Trainers")
                        .WithMany()
                        .HasForeignKey("TrainersTrainerId");
                });

            modelBuilder.Entity("MartialApp.Models.TrainerPayment", b =>
                {
                    b.HasOne("MartialApp.Models.Payment", "Payment")
                        .WithMany("TrainerPayment")
                        .HasForeignKey("PaymentId")
                        .HasConstraintName("FK_TrainerPayment_Payment");

                    b.HasOne("MartialApp.Models.Trainers", "Trainer")
                        .WithMany("TrainerPayment")
                        .HasForeignKey("TrainerId")
                        .HasConstraintName("FK_TrainerPayment_Trainers");
                });
#pragma warning restore 612, 618
        }
    }
}
