﻿// <auto-generated />
using System;
using Backend.Repository.MySQLRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Backend.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20201107194204_m4")]
    partial class m4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Backend.Model.UserModel.Address", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("LocationID")
                        .HasColumnType("bigint");

                    b.Property<string>("Street")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("LocationID");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Backend.Model.UserModel.DailyWorkingHours", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<long>("TimeIntervalId")
                        .HasColumnType("bigint");

                    b.Property<long?>("TimeTableId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TimeIntervalId");

                    b.HasIndex("TimeTableId");

                    b.ToTable("DailyWorkingHours");
                });

            modelBuilder.Entity("Backend.Model.UserModel.Feedback", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<bool>("Anonymous")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Comment")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("Public")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Published")
                        .HasColumnType("tinyint(1)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("Backend.Model.UserModel.Hospital", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("AddressID")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Telephone")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Website")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("AddressID");

                    b.ToTable("Hospitals");
                });

            modelBuilder.Entity("Backend.Model.UserModel.Location", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("City")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Country")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("Backend.Model.UserModel.Question", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Text")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("Backend.Model.UserModel.QuestionAnswer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("FeedbackId")
                        .HasColumnType("bigint");

                    b.Property<long>("QuestionId")
                        .HasColumnType("bigint");

                    b.Property<long>("RatingId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("FeedbackId");

                    b.HasIndex("QuestionId");

                    b.HasIndex("RatingId");

                    b.ToTable("QuestionAnswer");
                });

            modelBuilder.Entity("Backend.Model.UserModel.Rating", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Comment")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Stars")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Rating");
                });

            modelBuilder.Entity("Backend.Model.UserModel.Room", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<long?>("HospitalId")
                        .HasColumnType("bigint");

                    b.Property<bool>("Occupied")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("RoomNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("RoomType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HospitalId");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("Backend.Model.UserModel.TimeTable", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("TimeTable");
                });

            modelBuilder.Entity("Backend.Model.UserModel.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("AddressID")
                        .HasColumnType("bigint");

                    b.Property<string>("CellPhone")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email1")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email2")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("HomePhone")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("MiddleName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<long?>("UidId")
                        .HasColumnType("bigint");

                    b.Property<string>("Uidn")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("AddressID");

                    b.HasIndex("UidId");

                    b.ToTable("User");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("Backend.Model.UserModel.UserID", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("varchar(1) CHARACTER SET utf8mb4");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserID");
                });

            modelBuilder.Entity("Backend.Util.TimeInterval", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("TimeInterval");
                });

            modelBuilder.Entity("Backend.Model.UserModel.Employee", b =>
                {
                    b.HasBaseType("Backend.Model.UserModel.User");

                    b.Property<long>("HospitalID")
                        .HasColumnType("bigint");

                    b.Property<long>("TimeTableID")
                        .HasColumnType("bigint");

                    b.HasIndex("HospitalID");

                    b.HasIndex("TimeTableID");

                    b.HasDiscriminator().HasValue("Employee");
                });

            modelBuilder.Entity("Backend.Model.UserModel.Address", b =>
                {
                    b.HasOne("Backend.Model.UserModel.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Model.UserModel.DailyWorkingHours", b =>
                {
                    b.HasOne("Backend.Util.TimeInterval", "TimeInterval")
                        .WithMany()
                        .HasForeignKey("TimeIntervalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Model.UserModel.TimeTable", null)
                        .WithMany("WorkingHours")
                        .HasForeignKey("TimeTableId");
                });

            modelBuilder.Entity("Backend.Model.UserModel.Feedback", b =>
                {
                    b.HasOne("Backend.Model.UserModel.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Model.UserModel.Hospital", b =>
                {
                    b.HasOne("Backend.Model.UserModel.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Model.UserModel.QuestionAnswer", b =>
                {
                    b.HasOne("Backend.Model.UserModel.Feedback", null)
                        .WithMany("Rating")
                        .HasForeignKey("FeedbackId");

                    b.HasOne("Backend.Model.UserModel.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Model.UserModel.Rating", "Rating")
                        .WithMany()
                        .HasForeignKey("RatingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Model.UserModel.Room", b =>
                {
                    b.HasOne("Backend.Model.UserModel.Hospital", null)
                        .WithMany("Room")
                        .HasForeignKey("HospitalId");
                });

            modelBuilder.Entity("Backend.Model.UserModel.User", b =>
                {
                    b.HasOne("Backend.Model.UserModel.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Model.UserModel.UserID", "Uid")
                        .WithMany()
                        .HasForeignKey("UidId");
                });

            modelBuilder.Entity("Backend.Model.UserModel.Employee", b =>
                {
                    b.HasOne("Backend.Model.UserModel.Hospital", "Hospital")
                        .WithMany("Employee")
                        .HasForeignKey("HospitalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Model.UserModel.TimeTable", "TimeTable")
                        .WithMany()
                        .HasForeignKey("TimeTableID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
