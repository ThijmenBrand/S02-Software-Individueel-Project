﻿// <auto-generated />
using System;
using DataAccessLayer.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataLayer.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220429115936_update-to-task")]
    partial class updatetotask
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DataAccessLayer.Models.Asset", b =>
                {
                    b.Property<int>("FileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FileId"), 1L, 1);

                    b.Property<string>("FileContentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("FileData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("FileId");

                    b.HasIndex("ProjectId");

                    b.ToTable("asset");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Link", b =>
                {
                    b.Property<int>("LinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LinkId"), 1L, 1);

                    b.Property<string>("LinkName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("LinkId");

                    b.HasIndex("ProjectId");

                    b.ToTable("link");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"), 1L, 1);

                    b.Property<DateTime>("ProjectDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProjectDescription")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ProjectOwnerId")
                        .HasColumnType("int");

                    b.HasKey("ProjectId");

                    b.ToTable("project");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Sprint", b =>
                {
                    b.Property<int>("SprintId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SprintId"), 1L, 1);

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SprintEnd")
                        .HasColumnType("datetime2");

                    b.Property<string>("SprintName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("SprintStart")
                        .HasColumnType("datetime2");

                    b.HasKey("SprintId");

                    b.ToTable("sprint");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Tasks", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskId"), 1L, 1);

                    b.Property<int>("SprintId")
                        .HasColumnType("int");

                    b.Property<string>("TaskDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TaskEndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TaskImportance")
                        .HasColumnType("int");

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("TaskStartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("TaskTag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaskId");

                    b.ToTable("task");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Time", b =>
                {
                    b.Property<int>("TimeRecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TimeRecordId"), 1L, 1);

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.Property<string>("TimeRecordName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TimeRecordTiming")
                        .HasColumnType("float");

                    b.HasKey("TimeRecordId");

                    b.HasIndex("TaskId")
                        .IsUnique();

                    b.ToTable("time");
                });

            modelBuilder.Entity("DataAccessLayer.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("user");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Asset", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Link", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Time", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Tasks", "Task")
                        .WithOne("TaskTime")
                        .HasForeignKey("DataAccessLayer.Models.Time", "TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Task");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Tasks", b =>
                {
                    b.Navigation("TaskTime");
                });
#pragma warning restore 612, 618
        }
    }
}
