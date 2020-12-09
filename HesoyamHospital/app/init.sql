CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);

CREATE TABLE `ActionsBenefits` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Text` longtext CHARACTER SET utf8mb4 NULL,
    `Timestamp` datetime(6) NOT NULL,
    `Approved` tinyint(1) NOT NULL,
    CONSTRAINT `PK_ActionsBenefits` PRIMARY KEY (`Id`)
);

CREATE TABLE `Diagnoses` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `DiagnosisCode` longtext CHARACTER SET utf8mb4 NULL,
    `DiagnosisName` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_Diagnoses` PRIMARY KEY (`Id`)
);

CREATE TABLE `DiseaseType` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Infectious` tinyint(1) NOT NULL,
    `Genetic` tinyint(1) NOT NULL,
    `Type` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_DiseaseType` PRIMARY KEY (`Id`)
);

CREATE TABLE `Locations` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Country` longtext CHARACTER SET utf8mb4 NULL,
    `City` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_Locations` PRIMARY KEY (`Id`)
);

CREATE TABLE `Medicine` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    `InStock` int NOT NULL,
    `MinNumber` int NOT NULL,
    `IsValid` tinyint(1) NOT NULL,
    `MedicineType` int NOT NULL,
    CONSTRAINT `PK_Medicine` PRIMARY KEY (`Id`)
);

CREATE TABLE `Question` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Text` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_Question` PRIMARY KEY (`Id`)
);

CREATE TABLE `Rating` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Stars` int NOT NULL,
    `Comment` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_Rating` PRIMARY KEY (`Id`)
);

CREATE TABLE `RegisteredPharmacies` (
    `PharmacyName` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `Id` bigint NOT NULL,
    `ApiKey` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Endpoint` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_RegisteredPharmacies` PRIMARY KEY (`PharmacyName`)
);

CREATE TABLE `Section` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `AnswerOne` bigint NOT NULL,
    `AnswerTwo` bigint NOT NULL,
    `AnswerThree` bigint NOT NULL,
    `AnswerFour` bigint NOT NULL,
    CONSTRAINT `PK_Section` PRIMARY KEY (`Id`)
);

CREATE TABLE `ShiftType` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    `StartTime` datetime(6) NOT NULL,
    `EndTime` datetime(6) NOT NULL,
    CONSTRAINT `PK_ShiftType` PRIMARY KEY (`Id`)
);

CREATE TABLE `TherapyDose` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    CONSTRAINT `PK_TherapyDose` PRIMARY KEY (`Id`)
);

CREATE TABLE `TimeInterval` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `StartTime` datetime(6) NOT NULL,
    `EndTime` datetime(6) NOT NULL,
    CONSTRAINT `PK_TimeInterval` PRIMARY KEY (`Id`)
);

CREATE TABLE `TimeTable` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    CONSTRAINT `PK_TimeTable` PRIMARY KEY (`Id`)
);

CREATE TABLE `UserID` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Code` varchar(1) CHARACTER SET utf8mb4 NOT NULL,
    `Number` int NOT NULL,
    CONSTRAINT `PK_UserID` PRIMARY KEY (`Id`)
);

CREATE TABLE `Disease` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    `Overview` longtext CHARACTER SET utf8mb4 NULL,
    `IsChronic` tinyint(1) NOT NULL,
    `DiseaseTypeId` bigint NULL,
    CONSTRAINT `PK_Disease` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Disease_DiseaseType_DiseaseTypeId` FOREIGN KEY (`DiseaseTypeId`) REFERENCES `DiseaseType` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Address` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Street` longtext CHARACTER SET utf8mb4 NULL,
    `LocationId` bigint NULL,
    CONSTRAINT `PK_Address` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Address_Locations_LocationId` FOREIGN KEY (`LocationId`) REFERENCES `Locations` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Ingredient` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    `MedicineId` bigint NULL,
    CONSTRAINT `PK_Ingredient` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Ingredient_Medicine_MedicineId` FOREIGN KEY (`MedicineId`) REFERENCES `Medicine` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `SingleTherapyDose` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `TherapyTime` int NOT NULL,
    `Quantity` double NOT NULL,
    `TherapyDoseId` bigint NULL,
    CONSTRAINT `PK_SingleTherapyDose` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_SingleTherapyDose_TherapyDose_TherapyDoseId` FOREIGN KEY (`TherapyDoseId`) REFERENCES `TherapyDose` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Shift` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Date` datetime(6) NOT NULL,
    `ShiftTypeId` bigint NULL,
    `TimeTableId` bigint NULL,
    CONSTRAINT `PK_Shift` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Shift_ShiftType_ShiftTypeId` FOREIGN KEY (`ShiftTypeId`) REFERENCES `ShiftType` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Shift_TimeTable_TimeTableId` FOREIGN KEY (`TimeTableId`) REFERENCES `TimeTable` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `DiseaseMedicine` (
    `DiseaseId` bigint NOT NULL,
    `MedicineId` bigint NOT NULL,
    CONSTRAINT `PK_DiseaseMedicine` PRIMARY KEY (`DiseaseId`, `MedicineId`),
    CONSTRAINT `FK_DiseaseMedicine_Disease_DiseaseId` FOREIGN KEY (`DiseaseId`) REFERENCES `Disease` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_DiseaseMedicine_Medicine_MedicineId` FOREIGN KEY (`MedicineId`) REFERENCES `Medicine` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `Symptom` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    `ShortDescription` longtext CHARACTER SET utf8mb4 NULL,
    `DiseaseId` bigint NULL,
    CONSTRAINT `PK_Symptom` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Symptom_Disease_DiseaseId` FOREIGN KEY (`DiseaseId`) REFERENCES `Disease` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Hospitals` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    `Telephone` longtext CHARACTER SET utf8mb4 NULL,
    `Website` longtext CHARACTER SET utf8mb4 NULL,
    `AddressId` bigint NULL,
    CONSTRAINT `PK_Hospitals` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Hospitals_Address_AddressId` FOREIGN KEY (`AddressId`) REFERENCES `Address` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Room` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `RoomNumber` longtext CHARACTER SET utf8mb4 NULL,
    `Occupied` tinyint(1) NOT NULL,
    `Floor` int NOT NULL,
    `RoomType` int NOT NULL,
    `HospitalId` bigint NULL,
    CONSTRAINT `PK_Room` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Room_Hospitals_HospitalId` FOREIGN KEY (`HospitalId`) REFERENCES `Hospitals` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Users` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Uidn` longtext CHARACTER SET utf8mb4 NULL,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    `Surname` longtext CHARACTER SET utf8mb4 NULL,
    `MiddleName` longtext CHARACTER SET utf8mb4 NULL,
    `Jmbg` longtext CHARACTER SET utf8mb4 NULL,
    `DateOfBirth` datetime(6) NOT NULL,
    `HomePhone` longtext CHARACTER SET utf8mb4 NULL,
    `CellPhone` longtext CHARACTER SET utf8mb4 NULL,
    `Email1` longtext CHARACTER SET utf8mb4 NULL,
    `Email2` longtext CHARACTER SET utf8mb4 NULL,
    `AddressId` bigint NULL,
    `Sex` int NOT NULL,
    `UserName` longtext CHARACTER SET utf8mb4 NULL,
    `Password` longtext CHARACTER SET utf8mb4 NULL,
    `DateCreated` datetime(6) NOT NULL,
    `Deleted` tinyint(1) NOT NULL,
    `UidId` bigint NULL,
    `ContentType` longtext CHARACTER SET utf8mb4 NOT NULL,
    `HospitalId` bigint NULL,
    `OfficeId` bigint NULL,
    `Specialisation` int NULL,
    `TimeTableId` bigint NULL,
    `SelectedDoctorId` bigint NULL,
    `Active` tinyint(1) NULL,
    `Blocked` tinyint(1) NULL,
    `HealthCardNumber` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_Users` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Users_Room_OfficeId` FOREIGN KEY (`OfficeId`) REFERENCES `Room` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Users_TimeTable_TimeTableId` FOREIGN KEY (`TimeTableId`) REFERENCES `TimeTable` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Users_Hospitals_HospitalId` FOREIGN KEY (`HospitalId`) REFERENCES `Hospitals` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Users_Users_SelectedDoctorId` FOREIGN KEY (`SelectedDoctorId`) REFERENCES `Users` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Users_Address_AddressId` FOREIGN KEY (`AddressId`) REFERENCES `Address` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Users_UserID_UidId` FOREIGN KEY (`UidId`) REFERENCES `UserID` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Appointment` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Canceled` tinyint(1) NOT NULL,
    `AbleToFillOutSurvey` tinyint(1) NOT NULL,
    `AppointmentType` int NOT NULL,
    `TimeIntervalId` bigint NULL,
    `PatientId` bigint NULL,
    `DoctorInAppointmentId` bigint NULL,
    `RoomId` bigint NULL,
    `ShiftId` bigint NULL,
    CONSTRAINT `PK_Appointment` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Appointment_Users_DoctorInAppointmentId` FOREIGN KEY (`DoctorInAppointmentId`) REFERENCES `Users` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Appointment_Users_PatientId` FOREIGN KEY (`PatientId`) REFERENCES `Users` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Appointment_Room_RoomId` FOREIGN KEY (`RoomId`) REFERENCES `Room` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Appointment_Shift_ShiftId` FOREIGN KEY (`ShiftId`) REFERENCES `Shift` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Appointment_TimeInterval_TimeIntervalId` FOREIGN KEY (`TimeIntervalId`) REFERENCES `TimeInterval` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Feedbacks` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `UserId` bigint NULL,
    `Published` tinyint(1) NOT NULL,
    `Anonymous` tinyint(1) NOT NULL,
    `Public` tinyint(1) NOT NULL,
    `Comment` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_Feedbacks` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Feedbacks_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `MedicalRecords` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `PatientBloodType` int NOT NULL,
    `PatientId` bigint NULL,
    CONSTRAINT `PK_MedicalRecords` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_MedicalRecords_Users_PatientId` FOREIGN KEY (`PatientId`) REFERENCES `Users` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Surveys` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `DoctorId` bigint NULL,
    `StaffSectionId` bigint NULL,
    `DoctorSectionId` bigint NULL,
    `HygieneSectionId` bigint NULL,
    `EquipmentSectionId` bigint NULL,
    CONSTRAINT `PK_Surveys` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Surveys_Users_DoctorId` FOREIGN KEY (`DoctorId`) REFERENCES `Users` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Surveys_Section_DoctorSectionId` FOREIGN KEY (`DoctorSectionId`) REFERENCES `Section` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Surveys_Section_EquipmentSectionId` FOREIGN KEY (`EquipmentSectionId`) REFERENCES `Section` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Surveys_Section_HygieneSectionId` FOREIGN KEY (`HygieneSectionId`) REFERENCES `Section` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Surveys_Section_StaffSectionId` FOREIGN KEY (`StaffSectionId`) REFERENCES `Section` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Cancellations` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `AppointmentId` bigint NULL,
    `DateCancelled` datetime(6) NOT NULL,
    CONSTRAINT `PK_Cancellations` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Cancellations_Appointment_AppointmentId` FOREIGN KEY (`AppointmentId`) REFERENCES `Appointment` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `QuestionAnswer` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `QuestionId` bigint NULL,
    `RatingId` bigint NULL,
    `FeedbackId` bigint NULL,
    CONSTRAINT `PK_QuestionAnswer` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_QuestionAnswer_Feedbacks_FeedbackId` FOREIGN KEY (`FeedbackId`) REFERENCES `Feedbacks` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_QuestionAnswer_Question_QuestionId` FOREIGN KEY (`QuestionId`) REFERENCES `Question` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_QuestionAnswer_Rating_RatingId` FOREIGN KEY (`RatingId`) REFERENCES `Rating` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Allergies` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    `MedicalRecordId` bigint NULL,
    CONSTRAINT `PK_Allergies` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Allergies_MedicalRecords_MedicalRecordId` FOREIGN KEY (`MedicalRecordId`) REFERENCES `MedicalRecords` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Prescriptions` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `DateCreated` datetime(6) NOT NULL,
    `PatientId` bigint NULL,
    `DoctorId` bigint NULL,
    `DiagnosisId` bigint NULL,
    `Type` int NOT NULL,
    `Status` int NOT NULL,
    `MedicalRecordId` bigint NULL,
    CONSTRAINT `PK_Prescriptions` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Prescriptions_Diagnoses_DiagnosisId` FOREIGN KEY (`DiagnosisId`) REFERENCES `Diagnoses` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Prescriptions_Users_DoctorId` FOREIGN KEY (`DoctorId`) REFERENCES `Users` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Prescriptions_MedicalRecords_MedicalRecordId` FOREIGN KEY (`MedicalRecordId`) REFERENCES `MedicalRecords` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Prescriptions_Users_PatientId` FOREIGN KEY (`PatientId`) REFERENCES `Users` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Reports` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `DateCreated` datetime(6) NOT NULL,
    `PatientId` bigint NULL,
    `DoctorId` bigint NULL,
    `DiagnosisId` bigint NULL,
    `Type` int NOT NULL,
    `Comment` longtext CHARACTER SET utf8mb4 NULL,
    `MedicalRecordId` bigint NULL,
    CONSTRAINT `PK_Reports` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Reports_Diagnoses_DiagnosisId` FOREIGN KEY (`DiagnosisId`) REFERENCES `Diagnoses` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Reports_Users_DoctorId` FOREIGN KEY (`DoctorId`) REFERENCES `Users` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Reports_MedicalRecords_MedicalRecordId` FOREIGN KEY (`MedicalRecordId`) REFERENCES `MedicalRecords` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Reports_Users_PatientId` FOREIGN KEY (`PatientId`) REFERENCES `Users` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `PrescriptionsAndTherapies` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `TimeIntervalID` bigint NOT NULL,
    `PrescriptionID` bigint NOT NULL,
    `DatePrescribed` datetime(6) NOT NULL,
    CONSTRAINT `PK_PrescriptionsAndTherapies` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_PrescriptionsAndTherapies_Prescriptions_PrescriptionID` FOREIGN KEY (`PrescriptionID`) REFERENCES `Prescriptions` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_PrescriptionsAndTherapies_TimeInterval_TimeIntervalID` FOREIGN KEY (`TimeIntervalID`) REFERENCES `TimeInterval` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `Therapies` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `MedicineId` bigint NULL,
    `DoseId` bigint NULL,
    `PrescriptionId` bigint NULL,
    CONSTRAINT `PK_Therapies` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Therapies_TherapyDose_DoseId` FOREIGN KEY (`DoseId`) REFERENCES `TherapyDose` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Therapies_Medicine_MedicineId` FOREIGN KEY (`MedicineId`) REFERENCES `Medicine` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Therapies_Prescriptions_PrescriptionId` FOREIGN KEY (`PrescriptionId`) REFERENCES `Prescriptions` (`Id`) ON DELETE RESTRICT
);

CREATE INDEX `IX_Address_LocationId` ON `Address` (`LocationId`);

CREATE INDEX `IX_Allergies_MedicalRecordId` ON `Allergies` (`MedicalRecordId`);

CREATE INDEX `IX_Appointment_DoctorInAppointmentId` ON `Appointment` (`DoctorInAppointmentId`);

CREATE INDEX `IX_Appointment_PatientId` ON `Appointment` (`PatientId`);

CREATE INDEX `IX_Appointment_RoomId` ON `Appointment` (`RoomId`);

CREATE INDEX `IX_Appointment_ShiftId` ON `Appointment` (`ShiftId`);

CREATE INDEX `IX_Appointment_TimeIntervalId` ON `Appointment` (`TimeIntervalId`);

CREATE INDEX `IX_Cancellations_AppointmentId` ON `Cancellations` (`AppointmentId`);

CREATE INDEX `IX_Disease_DiseaseTypeId` ON `Disease` (`DiseaseTypeId`);

CREATE INDEX `IX_DiseaseMedicine_MedicineId` ON `DiseaseMedicine` (`MedicineId`);

CREATE INDEX `IX_Feedbacks_UserId` ON `Feedbacks` (`UserId`);

CREATE INDEX `IX_Hospitals_AddressId` ON `Hospitals` (`AddressId`);

CREATE INDEX `IX_Ingredient_MedicineId` ON `Ingredient` (`MedicineId`);

CREATE INDEX `IX_MedicalRecords_PatientId` ON `MedicalRecords` (`PatientId`);

CREATE INDEX `IX_Prescriptions_DiagnosisId` ON `Prescriptions` (`DiagnosisId`);

CREATE INDEX `IX_Prescriptions_DoctorId` ON `Prescriptions` (`DoctorId`);

CREATE INDEX `IX_Prescriptions_MedicalRecordId` ON `Prescriptions` (`MedicalRecordId`);

CREATE INDEX `IX_Prescriptions_PatientId` ON `Prescriptions` (`PatientId`);

CREATE INDEX `IX_PrescriptionsAndTherapies_PrescriptionID` ON `PrescriptionsAndTherapies` (`PrescriptionID`);

CREATE INDEX `IX_PrescriptionsAndTherapies_TimeIntervalID` ON `PrescriptionsAndTherapies` (`TimeIntervalID`);

CREATE INDEX `IX_QuestionAnswer_FeedbackId` ON `QuestionAnswer` (`FeedbackId`);

CREATE INDEX `IX_QuestionAnswer_QuestionId` ON `QuestionAnswer` (`QuestionId`);

CREATE INDEX `IX_QuestionAnswer_RatingId` ON `QuestionAnswer` (`RatingId`);

CREATE INDEX `IX_Reports_DiagnosisId` ON `Reports` (`DiagnosisId`);

CREATE INDEX `IX_Reports_DoctorId` ON `Reports` (`DoctorId`);

CREATE INDEX `IX_Reports_MedicalRecordId` ON `Reports` (`MedicalRecordId`);

CREATE INDEX `IX_Reports_PatientId` ON `Reports` (`PatientId`);

CREATE INDEX `IX_Room_HospitalId` ON `Room` (`HospitalId`);

CREATE INDEX `IX_Shift_ShiftTypeId` ON `Shift` (`ShiftTypeId`);

CREATE INDEX `IX_Shift_TimeTableId` ON `Shift` (`TimeTableId`);

CREATE INDEX `IX_SingleTherapyDose_TherapyDoseId` ON `SingleTherapyDose` (`TherapyDoseId`);

CREATE INDEX `IX_Surveys_DoctorId` ON `Surveys` (`DoctorId`);

CREATE INDEX `IX_Surveys_DoctorSectionId` ON `Surveys` (`DoctorSectionId`);

CREATE INDEX `IX_Surveys_EquipmentSectionId` ON `Surveys` (`EquipmentSectionId`);

CREATE INDEX `IX_Surveys_HygieneSectionId` ON `Surveys` (`HygieneSectionId`);

CREATE INDEX `IX_Surveys_StaffSectionId` ON `Surveys` (`StaffSectionId`);

CREATE INDEX `IX_Symptom_DiseaseId` ON `Symptom` (`DiseaseId`);

CREATE INDEX `IX_Therapies_DoseId` ON `Therapies` (`DoseId`);

CREATE INDEX `IX_Therapies_MedicineId` ON `Therapies` (`MedicineId`);

CREATE INDEX `IX_Therapies_PrescriptionId` ON `Therapies` (`PrescriptionId`);

CREATE INDEX `IX_Users_OfficeId` ON `Users` (`OfficeId`);

CREATE INDEX `IX_Users_TimeTableId` ON `Users` (`TimeTableId`);

CREATE INDEX `IX_Users_HospitalId` ON `Users` (`HospitalId`);

CREATE INDEX `IX_Users_SelectedDoctorId` ON `Users` (`SelectedDoctorId`);

CREATE INDEX `IX_Users_AddressId` ON `Users` (`AddressId`);

CREATE INDEX `IX_Users_UidId` ON `Users` (`UidId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20201205160108_InitialCreate', '3.1.9');

