﻿// <auto-generated />
using System;
using App;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App.Migrations
{
    [DbContext(typeof(UniversityContext))]
    [Migration("20220909140753_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.6");

            modelBuilder.Entity("App.ChartGroup", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("GroupId");

                    b.ToTable("ChartGroups");
                });

            modelBuilder.Entity("App.ConfirmedRoom", b =>
                {
                    b.Property<int>("TeacherId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoomId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TeacherId", "RoomId");

                    b.HasIndex("RoomId");

                    b.ToTable("ConfirmedRooms");
                });

            modelBuilder.Entity("App.ConfirmedTime", b =>
                {
                    b.Property<int>("TeacherId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TimeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TeacherId", "TimeId");

                    b.HasIndex("TimeId");

                    b.ToTable("ConfirmedTimes");
                });

            modelBuilder.Entity("App.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GroupId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsLab")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TeacherId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CourseId");

                    b.HasIndex("GroupId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("App.CourseGroup", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ChartGroupGroupId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("GroupId");

                    b.HasIndex("ChartGroupGroupId");

                    b.ToTable("CourseGroups");
                });

            modelBuilder.Entity("App.ProposedRoom", b =>
                {
                    b.Property<int>("TeacherId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoomId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TeacherId", "RoomId");

                    b.HasIndex("RoomId");

                    b.ToTable("ProposedRooms");
                });

            modelBuilder.Entity("App.ProposedTime", b =>
                {
                    b.Property<int>("TeacherId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TimeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TeacherId", "TimeId");

                    b.HasIndex("TimeId");

                    b.ToTable("ProposedTimes");
                });

            modelBuilder.Entity("App.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("RoomId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("App.RoomOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CourseId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("RoomId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("RoomId");

                    b.ToTable("RoomOptions");

                    b.HasDiscriminator<string>("Discriminator").HasValue("RoomOption");
                });

            modelBuilder.Entity("App.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("App.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TeacherId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("App.Time", b =>
                {
                    b.Property<int>("TimeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Day")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Duration")
                        .HasColumnType("REAL");

                    b.Property<double>("Start")
                        .HasColumnType("REAL");

                    b.HasKey("TimeId");

                    b.ToTable("Times");
                });

            modelBuilder.Entity("App.RoomCapacity", b =>
                {
                    b.HasBaseType("App.RoomOption");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("RoomCapacity");
                });

            modelBuilder.Entity("App.RoomHasProjector", b =>
                {
                    b.HasBaseType("App.RoomOption");

                    b.Property<bool>("Projector")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("RoomHasProjector");
                });

            modelBuilder.Entity("App.ConfirmedRoom", b =>
                {
                    b.HasOne("App.Room", "Room")
                        .WithMany("ConfirmedRooms")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Teacher", "Teacher")
                        .WithMany("ConfirmedRooms")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("App.ConfirmedTime", b =>
                {
                    b.HasOne("App.Teacher", "Teacher")
                        .WithMany("ConfirmedTimes")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Time", "Time")
                        .WithMany("ConfirmedTimes")
                        .HasForeignKey("TimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");

                    b.Navigation("Time");
                });

            modelBuilder.Entity("App.Course", b =>
                {
                    b.HasOne("App.CourseGroup", "Group")
                        .WithMany("Events")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("App.CourseGroup", b =>
                {
                    b.HasOne("App.ChartGroup", null)
                        .WithMany("CourseGroups")
                        .HasForeignKey("ChartGroupGroupId");
                });

            modelBuilder.Entity("App.ProposedRoom", b =>
                {
                    b.HasOne("App.Room", "Room")
                        .WithMany("ProposedRooms")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Teacher", "Teacher")
                        .WithMany("ProposedRooms")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("App.ProposedTime", b =>
                {
                    b.HasOne("App.Teacher", "Teacher")
                        .WithMany("ProposedTimes")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Time", "Time")
                        .WithMany("ProposedTimes")
                        .HasForeignKey("TimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");

                    b.Navigation("Time");
                });

            modelBuilder.Entity("App.RoomOption", b =>
                {
                    b.HasOne("App.Course", null)
                        .WithMany("RequiredOptions")
                        .HasForeignKey("CourseId");

                    b.HasOne("App.Room", null)
                        .WithMany("Options")
                        .HasForeignKey("RoomId");
                });

            modelBuilder.Entity("App.ChartGroup", b =>
                {
                    b.Navigation("CourseGroups");
                });

            modelBuilder.Entity("App.Course", b =>
                {
                    b.Navigation("RequiredOptions");
                });

            modelBuilder.Entity("App.CourseGroup", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("App.Room", b =>
                {
                    b.Navigation("ConfirmedRooms");

                    b.Navigation("Options");

                    b.Navigation("ProposedRooms");
                });

            modelBuilder.Entity("App.Teacher", b =>
                {
                    b.Navigation("ConfirmedRooms");

                    b.Navigation("ConfirmedTimes");

                    b.Navigation("ProposedRooms");

                    b.Navigation("ProposedTimes");
                });

            modelBuilder.Entity("App.Time", b =>
                {
                    b.Navigation("ConfirmedTimes");

                    b.Navigation("ProposedTimes");
                });
#pragma warning restore 612, 618
        }
    }
}
