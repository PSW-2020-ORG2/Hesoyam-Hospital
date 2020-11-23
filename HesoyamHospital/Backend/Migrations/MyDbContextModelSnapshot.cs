﻿// <auto-generated />
using System;
using Backend.Repository.MySQLRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Backend.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Backend.Model.PatientModel.Allergy", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("MedicalRecordId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("MedicalRecordId");

                    b.ToTable("Allergies");
                });

            modelBuilder.Entity("Backend.Model.PatientModel.Diagnosis", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("DiagnosisCode")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("diagnosisName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Diagnoses");
                });

            modelBuilder.Entity("Backend.Model.PatientModel.Disease", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("DiseaseTypeID")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsChronic")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Overview")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("DiseaseTypeID");

                    b.ToTable("Disease");
                });

            modelBuilder.Entity("Backend.Model.PatientModel.DiseaseMedicine", b =>
                {
                    b.Property<long>("DiseaseId")
                        .HasColumnType("bigint");

                    b.Property<long>("MedicineId")
                        .HasColumnType("bigint");

                    b.HasKey("DiseaseId", "MedicineId");

                    b.HasIndex("MedicineId");

                    b.ToTable("DiseaseMedicine");
                });

            modelBuilder.Entity("Backend.Model.PatientModel.DiseaseType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<bool>("Genetic")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Infectious")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Type")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("DiseaseType");
                });

            modelBuilder.Entity("Backend.Model.PatientModel.Ingredient", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("MedicineId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("MedicineId");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("Backend.Model.PatientModel.MedicalRecord", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("PatientBloodType")
                        .HasColumnType("int");

                    b.Property<long>("PatientID")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PatientID");

                    b.ToTable("MedicalRecords");
                });

            modelBuilder.Entity("Backend.Model.PatientModel.MedicalTherapy", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("DoseId")
                        .HasColumnType("bigint");

                    b.Property<long>("MedicineId")
                        .HasColumnType("bigint");

                    b.Property<long?>("PrescriptionId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DoseId");

                    b.HasIndex("MedicineId");

                    b.HasIndex("PrescriptionId");

                    b.ToTable("MedicalTherapy");
                });

            modelBuilder.Entity("Backend.Model.PatientModel.Medicine", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("InStock")
                        .HasColumnType("int");

                    b.Property<bool>("IsValid")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("MedicineType")
                        .HasColumnType("int");

                    b.Property<int>("MinNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Medicine");
                });

            modelBuilder.Entity("Backend.Model.PatientModel.Prescription", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("DiagnosisID")
                        .HasColumnType("bigint");

                    b.Property<long>("DoctorID")
                        .HasColumnType("bigint");

                    b.Property<long?>("MedicalRecordId")
                        .HasColumnType("bigint");

                    b.Property<long>("PatientID")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DiagnosisID");

                    b.HasIndex("DoctorID");

                    b.HasIndex("MedicalRecordId");

                    b.HasIndex("PatientID");

                    b.ToTable("Prescriptions");
                });

            modelBuilder.Entity("Backend.Model.PatientModel.Report", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Comment")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("DiagnosisID")
                        .HasColumnType("bigint");

                    b.Property<long>("DoctorID")
                        .HasColumnType("bigint");

                    b.Property<long?>("MedicalRecordId")
                        .HasColumnType("bigint");

                    b.Property<long>("PatientID")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DiagnosisID");

                    b.HasIndex("DoctorID");

                    b.HasIndex("MedicalRecordId");

                    b.HasIndex("PatientID");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("Backend.Model.PatientModel.SingleTherapyDose", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<double>("Quantity")
                        .HasColumnType("double");

                    b.Property<long?>("TherapyDoseId")
                        .HasColumnType("bigint");

                    b.Property<int>("TherapyTime")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TherapyDoseId");

                    b.ToTable("SingleTherapyDose");
                });

            modelBuilder.Entity("Backend.Model.PatientModel.Symptom", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("DiseaseId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("DiseaseId");

                    b.ToTable("Symptom");
                });

            modelBuilder.Entity("Backend.Model.PatientModel.Therapy", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("PrescriptionID")
                        .HasColumnType("bigint");

                    b.Property<long>("TimeIntervalID")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PrescriptionID");

                    b.HasIndex("TimeIntervalID");

                    b.ToTable("Therapies");
                });

            modelBuilder.Entity("Backend.Model.PatientModel.TherapyDose", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("TherapyDose");
                });

            modelBuilder.Entity("Backend.Model.PharmacyModel.PharmacyApiKey", b =>
                {
                    b.Property<string>("PharmacyName")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("ApiKey")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.HasKey("PharmacyName");

                    b.ToTable("PharmacyApiKeys");
                });

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

                    b.ToTable("Locations");
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

            modelBuilder.Entity("Backend.Model.UserModel.Section", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("AnswerFour")
                        .HasColumnType("bigint");

                    b.Property<long>("AnswerOne")
                        .HasColumnType("bigint");

                    b.Property<long>("AnswerThree")
                        .HasColumnType("bigint");

                    b.Property<long>("AnswerTwo")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Section");
                });

            modelBuilder.Entity("Backend.Model.UserModel.Survey", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("DoctorID")
                        .HasColumnType("bigint");

                    b.Property<long>("DoctorSectionID")
                        .HasColumnType("bigint");

                    b.Property<long>("EquipmentSectionID")
                        .HasColumnType("bigint");

                    b.Property<long>("HygieneSectionID")
                        .HasColumnType("bigint");

                    b.Property<long>("StaffSectionID")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DoctorID");

                    b.HasIndex("DoctorSectionID");

                    b.HasIndex("EquipmentSectionID");

                    b.HasIndex("HygieneSectionID");

                    b.HasIndex("StaffSectionID");

                    b.ToTable("Surveys");
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

                    b.Property<string>("ContentType")
                        .IsRequired()
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

                    b.Property<string>("Jmbg")
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

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("ContentType").HasValue("User");
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

            modelBuilder.Entity("Backend.Model.UserModel.Patient", b =>
                {
                    b.HasBaseType("Backend.Model.UserModel.User");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("HealthCardNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("PatientType")
                        .HasColumnType("int");

                    b.Property<long>("SelectedDoctorID")
                        .HasColumnType("bigint");

                    b.HasIndex("SelectedDoctorID");

                    b.HasDiscriminator().HasValue("Patient");
                });

            modelBuilder.Entity("Backend.Model.UserModel.SystemAdmin", b =>
                {
                    b.HasBaseType("Backend.Model.UserModel.User");

                    b.HasDiscriminator().HasValue("SystemAdmin");
                });

            modelBuilder.Entity("Backend.Model.UserModel.Doctor", b =>
                {
                    b.HasBaseType("Backend.Model.UserModel.Employee");

                    b.Property<int>("DoctorType")
                        .HasColumnType("int");

                    b.Property<long>("OfficeId")
                        .HasColumnType("bigint");

                    b.HasIndex("OfficeId");

                    b.HasDiscriminator().HasValue("Doctor");
                });

            modelBuilder.Entity("Backend.Model.UserModel.Manager", b =>
                {
                    b.HasBaseType("Backend.Model.UserModel.Employee");

                    b.HasDiscriminator().HasValue("Manager");
                });

            modelBuilder.Entity("Backend.Model.UserModel.Secretary", b =>
                {
                    b.HasBaseType("Backend.Model.UserModel.Employee");

                    b.HasDiscriminator().HasValue("Secretary");
                });

            modelBuilder.Entity("Backend.Model.PatientModel.Allergy", b =>
                {
                    b.HasOne("Backend.Model.PatientModel.MedicalRecord", null)
                        .WithMany("Allergy")
                        .HasForeignKey("MedicalRecordId");
                });

            modelBuilder.Entity("Backend.Model.PatientModel.Disease", b =>
                {
                    b.HasOne("Backend.Model.PatientModel.DiseaseType", "DiseaseType")
                        .WithMany()
                        .HasForeignKey("DiseaseTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Model.PatientModel.DiseaseMedicine", b =>
                {
                    b.HasOne("Backend.Model.PatientModel.Disease", "Disease")
                        .WithMany("AdministratedFor")
                        .HasForeignKey("DiseaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Model.PatientModel.Medicine", "Medicine")
                        .WithMany("UsedFor")
                        .HasForeignKey("MedicineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Model.PatientModel.Ingredient", b =>
                {
                    b.HasOne("Backend.Model.PatientModel.Medicine", null)
                        .WithMany("Ingredient")
                        .HasForeignKey("MedicineId");
                });

            modelBuilder.Entity("Backend.Model.PatientModel.MedicalRecord", b =>
                {
                    b.HasOne("Backend.Model.UserModel.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Model.PatientModel.MedicalTherapy", b =>
                {
                    b.HasOne("Backend.Model.PatientModel.TherapyDose", "Dose")
                        .WithMany()
                        .HasForeignKey("DoseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Model.PatientModel.Medicine", "Medicine")
                        .WithMany()
                        .HasForeignKey("MedicineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Model.PatientModel.Prescription", null)
                        .WithMany("MedicalTherapies")
                        .HasForeignKey("PrescriptionId");
                });

            modelBuilder.Entity("Backend.Model.PatientModel.Prescription", b =>
                {
                    b.HasOne("Backend.Model.PatientModel.Diagnosis", "Diagnosis")
                        .WithMany()
                        .HasForeignKey("DiagnosisID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Model.UserModel.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Model.PatientModel.MedicalRecord", null)
                        .WithMany("Prescriptions")
                        .HasForeignKey("MedicalRecordId");

                    b.HasOne("Backend.Model.UserModel.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Model.PatientModel.Report", b =>
                {
                    b.HasOne("Backend.Model.PatientModel.Diagnosis", "Diagnosis")
                        .WithMany()
                        .HasForeignKey("DiagnosisID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Model.UserModel.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Model.PatientModel.MedicalRecord", null)
                        .WithMany("PatientReports")
                        .HasForeignKey("MedicalRecordId");

                    b.HasOne("Backend.Model.UserModel.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Model.PatientModel.SingleTherapyDose", b =>
                {
                    b.HasOne("Backend.Model.PatientModel.TherapyDose", null)
                        .WithMany("Dosage")
                        .HasForeignKey("TherapyDoseId");
                });

            modelBuilder.Entity("Backend.Model.PatientModel.Symptom", b =>
                {
                    b.HasOne("Backend.Model.PatientModel.Disease", null)
                        .WithMany("Symptoms")
                        .HasForeignKey("DiseaseId");
                });

            modelBuilder.Entity("Backend.Model.PatientModel.Therapy", b =>
                {
                    b.HasOne("Backend.Model.PatientModel.Prescription", "Prescription")
                        .WithMany()
                        .HasForeignKey("PrescriptionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Util.TimeInterval", "TimeInterval")
                        .WithMany()
                        .HasForeignKey("TimeIntervalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

            modelBuilder.Entity("Backend.Model.UserModel.Survey", b =>
                {
                    b.HasOne("Backend.Model.UserModel.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Model.UserModel.Section", "DoctorSection")
                        .WithMany()
                        .HasForeignKey("DoctorSectionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Model.UserModel.Section", "EquipmentSection")
                        .WithMany()
                        .HasForeignKey("EquipmentSectionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Model.UserModel.Section", "HygieneSection")
                        .WithMany()
                        .HasForeignKey("HygieneSectionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Model.UserModel.Section", "StaffSection")
                        .WithMany()
                        .HasForeignKey("StaffSectionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

            modelBuilder.Entity("Backend.Model.UserModel.Patient", b =>
                {
                    b.HasOne("Backend.Model.UserModel.Doctor", "SelectedDoctor")
                        .WithMany()
                        .HasForeignKey("SelectedDoctorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Model.UserModel.Doctor", b =>
                {
                    b.HasOne("Backend.Model.UserModel.Room", "Office")
                        .WithMany()
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
