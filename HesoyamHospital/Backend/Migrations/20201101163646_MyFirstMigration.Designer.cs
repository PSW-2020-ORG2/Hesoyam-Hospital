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
    [Migration("20201101163646_MyFirstMigration")]
    partial class MyFirstMigration
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

                    b.Property<long?>("Locationid")
                        .HasColumnType("bigint");

                    b.Property<string>("Street")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("Locationid");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Backend.Model.UserModel.Employee", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("AddressId")
                        .HasColumnType("bigint");

                    b.Property<string>("CellPhone")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Email1")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email2")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("HomePhone")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<long?>("Hospitalid")
                        .HasColumnType("bigint");

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

                    b.Property<long?>("TimeTableid")
                        .HasColumnType("bigint");

                    b.Property<string>("Uidn")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<long?>("UserIDid")
                        .HasColumnType("bigint");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("id");

                    b.HasIndex("AddressId");

                    b.HasIndex("Hospitalid");

                    b.HasIndex("TimeTableid");

                    b.HasIndex("UserIDid");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Backend.Model.UserModel.Hospital", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("AddressId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Telephone")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Website")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("id");

                    b.HasIndex("AddressId");

                    b.ToTable("Hospitals");
                });

            modelBuilder.Entity("Backend.Model.UserModel.Location", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("City")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Country")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("Backend.Model.UserModel.Room", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<long?>("Hospitalid")
                        .HasColumnType("bigint");

                    b.Property<bool>("Occupied")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("RoomNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("RoomType")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Hospitalid");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("Backend.Model.UserModel.TimeTable", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.ToTable("TimeTable");
                });

            modelBuilder.Entity("Backend.Model.UserModel.UserID", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("varchar(1) CHARACTER SET utf8mb4");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("UserID");
                });

            modelBuilder.Entity("Backend.Model.UserModel.Address", b =>
                {
                    b.HasOne("Backend.Model.UserModel.Location", "Location")
                        .WithMany()
                        .HasForeignKey("Locationid");
                });

            modelBuilder.Entity("Backend.Model.UserModel.Employee", b =>
                {
                    b.HasOne("Backend.Model.UserModel.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("Backend.Model.UserModel.Hospital", "Hospital")
                        .WithMany("Employee")
                        .HasForeignKey("Hospitalid");

                    b.HasOne("Backend.Model.UserModel.TimeTable", "TimeTable")
                        .WithMany()
                        .HasForeignKey("TimeTableid");

                    b.HasOne("Backend.Model.UserModel.UserID", "UserID")
                        .WithMany()
                        .HasForeignKey("UserIDid");
                });

            modelBuilder.Entity("Backend.Model.UserModel.Hospital", b =>
                {
                    b.HasOne("Backend.Model.UserModel.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");
                });

            modelBuilder.Entity("Backend.Model.UserModel.Room", b =>
                {
                    b.HasOne("Backend.Model.UserModel.Hospital", null)
                        .WithMany("Room")
                        .HasForeignKey("Hospitalid");
                });
#pragma warning restore 612, 618
        }
    }
}
