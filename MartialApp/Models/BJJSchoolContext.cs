using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MartialApp.Models
{
    public partial class BJJSchoolContext : DbContext
    {
        public BJJSchoolContext()
        {
        }

        public BJJSchoolContext(DbContextOptions<BJJSchoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Belt> Belt { get; set; }
        public virtual DbSet<Discount> Discount { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<School> School { get; set; }
        public virtual DbSet<TrainerPayment> TrainerPayment { get; set; }
        public virtual DbSet<Trainers> Trainers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-NIE6JI9\\SQLEXPRESS;Database=BJJSchool;Trusted_Connection=True;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Belt>(entity =>
            {
                entity.Property(e => e.Colour)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.Property(e => e.Discount1)
                    .IsRequired()
                    .HasColumnName("Discount")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.PaimentId);

                entity.Property(e => e.PaimentId).ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.Paid).HasColumnType("datetime");
            });

            modelBuilder.Entity<School>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NickName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TrainerPayment>(entity =>
            {
                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.TrainerPayment)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK_TrainerPayment_Payment");

                entity.HasOne(d => d.Trainer)
                    .WithMany(p => p.TrainerPayment)
                    .HasForeignKey(d => d.TrainerId)
                    .HasConstraintName("FK_TrainerPayment_Trainers");
            });

            modelBuilder.Entity<Trainers>(entity =>
            {
                entity.HasKey(e => e.TrainerId)
                    .HasName("PK_Users");

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.Created).HasColumnType("datetime");


                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.Property(e => e.LastName2).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Phone).HasMaxLength(255);

                entity.Property(e => e.Tarifa).HasMaxLength(255);

                entity.Property(e => e.UserName).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
