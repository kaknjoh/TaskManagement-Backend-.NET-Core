﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskManagment.AppData;

namespace TaskManagment.Migrations
{
    [DbContext(typeof(TaskManagementDbContext))]
    [Migration("20210409140824_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TaskManagment.Models.AssignedUser", b =>
                {
                    b.Property<int>("AssignedUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AssignedUserId");

                    b.ToTable("AssignedUsers");
                });

            modelBuilder.Entity("TaskManagment.Models.AssignedUserTaskUnit", b =>
                {
                    b.Property<int>("AssignedUserId")
                        .HasColumnType("int");

                    b.Property<int>("TaskUnitId")
                        .HasColumnType("int");

                    b.HasKey("AssignedUserId", "TaskUnitId");

                    b.HasIndex("TaskUnitId");

                    b.ToTable("AssignedUserTaskUnits");
                });

            modelBuilder.Entity("TaskManagment.Models.TaskUnit", b =>
                {
                    b.Property<int>("TaskUnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TaskUnitId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("TaskManagment.Models.AssignedUserTaskUnit", b =>
                {
                    b.HasOne("TaskManagment.Models.AssignedUser", "AssignedUser")
                        .WithMany("AssignedUserTaskUnits")
                        .HasForeignKey("AssignedUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskManagment.Models.TaskUnit", "TaskUnit")
                        .WithMany("AssignedUserTaskUnits")
                        .HasForeignKey("TaskUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssignedUser");

                    b.Navigation("TaskUnit");
                });

            modelBuilder.Entity("TaskManagment.Models.AssignedUser", b =>
                {
                    b.Navigation("AssignedUserTaskUnits");
                });

            modelBuilder.Entity("TaskManagment.Models.TaskUnit", b =>
                {
                    b.Navigation("AssignedUserTaskUnits");
                });
#pragma warning restore 612, 618
        }
    }
}
