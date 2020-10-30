﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model.DoctorModel;
using Backend.Model.ManagerModel;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Repository.CSVFileRepository.Csv.Converter.HospitalManagementConverter;
using Backend.Repository.CSVFileRepository.Csv.Converter.MedicalConverter;
using Backend.Repository.CSVFileRepository.Csv.Converter.MiscConverter;
using Backend.Repository.CSVFileRepository.Csv.Converter.UsersConverter;
using Backend.Repository.CSVFileRepository.Csv.Stream;
using Backend.Repository.CSVFileRepository.HospitalManagementRepository;
using Backend.Repository.CSVFileRepository.MedicalRepository;
using Backend.Repository.CSVFileRepository.MiscRepository;
using Backend.Repository.CSVFileRepository.UsersRepository;
using Backend.Repository.Sequencer;
using Backend.Service.HospitalManagementService;
using Backend.Service.MedicalService;
using Backend.Service.MiscService;
using Backend.Service.UsersService;
using Backend.Util;

namespace Backend
{
    public class AppResources
    {
        public User loggedInUser;

        #region Files
        //Hospital management files
        private readonly string userFile = @"..\Backend\Files\UserFiles\users.txt";
        private readonly string patientFile = @"..\Backend\Files\UserFiles\patients.txt";
        private readonly string doctorFile = @"..\Backend\Files\UserFiles\doctors.txt";
        private readonly string managerFile = @"..\Backend\Files\UserFiles\managers.txt";

        private readonly string secretaryFile = @"..\Backend\Files\UserFiles\secretaries.txt";

        private readonly string timeTableFile = @"..\Backend\Files\HospitalManagementFiles\timeTables.txt";
        private readonly string hospitalFile = @"..\Backend\Files\HospitalManagementFiles\hospitals.txt";
        private readonly string roomFile = @"..\Backend\Files\HospitalManagementFiles\rooms.txt";
        private readonly string medicineFile = @"..\Backend\Files\HospitalManagementFiles\medicines.txt";
        private readonly string inventoryItemFile = @"..\Backend\Files\HospitalManagementFiles\inventoryItems.txt";
        private readonly string doctorStatisticsFile = @"..\Backend\Files\HospitalManagementFiles\doctorStatistics.txt";
        private readonly string inventoryStatisticsFile = @"..\Backend\Files\HospitalManagementFiles\inventoryStatistics.txt";
        private readonly string roomStatisticsFile = @"..\Backend\Files\HospitalManagementFiles\roomStatistics.txt";
        private readonly string inventoryFile = @"..\Backend\Files\HospitalManagementFiles\inventories.txt";

        //MiscFiles
        private readonly string locationFile = @"..\Backend\Files\MiscFiles\locations.txt";
        private readonly string notificationFile = @"..\Backend\Files\MiscFiles\notifications.txt";
        private readonly string messageFile = @"..\Backend\Files\MiscFiles\messages.txt";
        private readonly string articleFile = @"..\Backend\Files\MiscFiles\articles.txt";
        private readonly string questionFile = @"..\Backend\Files\MiscFiles\questions.txt";
        private readonly string doctorQuestionFile = @"..\Backend\Files\MiscFiles\doctorQuestions.txt";
        private readonly string feedbackFile = @"..\Backend\Files\MiscFiles\feedbacks.txt";
        private readonly string doctorFeedbackFile = @"..\Backend\Files\MiscFiles\doctorFeedbacks.txt";



        //Medical repository files
        private readonly string allergyFile = @"..\Backend\Files\MedicalFiles\allergies.txt";
        private readonly string appointmentsFile = @"..\Backend\Files\MedicalFiles\appointments.txt";
        private readonly string diagnosisFile = @"..\Backend\Files\MedicalFiles\diagnosis.txt";
        private readonly string diseaseFile = @"..\Backend\Files\MedicalFiles\diseases.txt";
        private readonly string ingredientFile = @"..\Backend\Files\MedicalFiles\ingredients.txt";
        private readonly string medicalRecordFile = @"..\Backend\Files\MedicalFiles\medicalRecords.txt";
        private readonly string prescriptionFile = @"..\Backend\Files\MedicalFiles\prescriptions.txt";
        private readonly string symptomsFile = @"..\Backend\Files\MedicalFiles\symptoms.txt";
        private readonly string therapyFile = @"..\Backend\Files\MedicalFiles\therapies.txt";

        #endregion Files

        private static AppResources instance = null;

        #region Repositories
        public UserRepository userRepository;
        public DoctorRepository doctorRepository;
        public PatientRepository patientRepository;
        public ManagerRepository managerRepository;
        public SecretaryRepository secretaryRepository;
        public TimeTableRepository timeTableRepository;
        public HospitalRepository hospitalRepository;
        public RoomRepository roomRepository;
        public InventoryItemRepository inventoryItemRepository;
        public DoctorStatisticRepository doctorStatisticRepository;
        public InventoryStatisticsRepository inventoryStatisticRepository;
        public RoomStatisticsRepository roomStatisticRepository;
        public InventoryRepository inventoryRepository;

        //Misc repositories
        public LocationRepository locationRepository;
        public NotificationRepository notificationRepository;
        public MessageRepository messageRepository;
        public ArticleRepository articleRepository;
        public QuestionRepository questionRepository;
        public QuestionRepository doctorQuestionRepository;
        public FeedbackRepository feedbackRepository;
        public DoctorFeedbackRepository doctorFeedbackRepository;


        //Hospital management
        public MedicineRepository medicineRepository;

        //Medical repositories
        public AllergyRepository allergyRepository;
        public AppointmentRepository appointmentRepository;
        public DiagnosisRepository diagnosisRepository;
        public DiseaseRepository diseaseRepository;
        public IngredientRepository ingredientRepository;
        public MedicalRecordRepository medicalRecordRepository;
        public PrescriptionRepository prescriptionRepository;
        public SymptomRepository symptomRepository;
        public TherapyRepository therapyRepository;

        #endregion Repositories

        public IAppointmentStrategy appointmentStrategy;

        #region service definitions
        // HospitalManagementServices
        public DoctorStatisticsService doctorStatisticsService;
        public InventoryStatisticsService inventoryStatisticsService;
        public RoomStatisticsService roomStatisticsService;
        public HospitalService hospitalService;
        public InventoryService inventoryService;
        public MedicineService medicineService;
        public RoomService roomService;

        // MedicalService
        public AppointmentService appointmentService;
        public AppointmentRecommendationService appointmentRecommendationService;
        public DiagnosisService diagnosisService;
        public DiseaseService diseaseService;
        public MedicalRecordService medicalRecordService;
        public TherapyService therapyService;

        // MiscService
        public ArticleService articleService;
        public DoctorFeedbackService doctorFeedbackService;
        public FeedbackService feedbackService;
        public LocationService locationService;
        public MessageService messageService;
        public NotificationService notificationService;
        public AppointmentNotificationSender appointmentNotificationSender;

        // UsersService
        public DoctorService doctorService;
        public ManagerService managerService;
        public PatientService patientService;
        public SecretaryService secretaryService;
        public UserService userService;
        #endregion


        private AppResources()
        {
            LoadRepositories();
            LoadServices();
        }

        private void LoadServices()
        {
            // HospitalManagementService
            doctorStatisticsService = new DoctorStatisticsService(doctorStatisticRepository);
            inventoryStatisticsService = new InventoryStatisticsService(inventoryStatisticRepository);
            roomStatisticsService = new RoomStatisticsService(roomStatisticRepository);
            hospitalService = new HospitalService(hospitalRepository);
            inventoryService = new InventoryService(inventoryRepository, inventoryItemRepository, medicineRepository);
            roomService = new RoomService(roomRepository, appointmentRepository);
            medicineService = new MedicineService(medicineRepository);

            // MedicineService
            diagnosisService = new DiagnosisService(diagnosisRepository);
            diseaseService = new DiseaseService(diseaseRepository);
            medicalRecordService = new MedicalRecordService(medicalRecordRepository);
            therapyService = new TherapyService(therapyRepository, medicalRecordService);

            // MiscService
            articleService = new ArticleService(articleRepository);
            doctorFeedbackService = new DoctorFeedbackService(doctorFeedbackRepository);

            feedbackService = new FeedbackService(feedbackRepository, questionRepository);
            locationService = new LocationService(locationRepository);
            messageService = new MessageService(messageRepository);
            notificationService = new NotificationService(notificationRepository);
            appointmentNotificationSender = new AppointmentNotificationSender(notificationService);
            appointmentService = new AppointmentService(appointmentRepository, appointmentStrategy, appointmentNotificationSender);

            // UsersService
            doctorService = new DoctorService(doctorRepository, userRepository, appointmentService);
            managerService = new ManagerService(managerRepository);
            patientService = new PatientService(patientRepository, medicalRecordRepository);
            secretaryService = new SecretaryService(secretaryRepository);
            userService = new UserService(userRepository);

            appointmentRecommendationService = new AppointmentRecommendationService(appointmentService, doctorService);
        }

        private void LoadRepositories()
        {
            userRepository = new UserRepository(new CSVStream<User>(userFile, new UserConverter()), new ComplexSequencer());
            // USER OK


            roomRepository = new RoomRepository(new CSVStream<Room>(roomFile, new RoomConverter()), new LongSequencer());
            // ROOM OK

            inventoryItemRepository = new InventoryItemRepository(new CSVStream<InventoryItem>(inventoryItemFile, new InventoryItemConverter()), new LongSequencer(), roomRepository);

            timeTableRepository = new TimeTableRepository(new CSVStream<TimeTable>(timeTableFile, new TimeTableConverter()), new LongSequencer());
            // TIMETABLE OK
            hospitalRepository = new HospitalRepository(new CSVStream<Hospital>(hospitalFile, new HospitalConverter()), new LongSequencer(), roomRepository);
            // HOSPITAL OK

            secretaryRepository = new SecretaryRepository(new CSVStream<Secretary>(secretaryFile, new SecretaryConverter()), new ComplexSequencer(), timeTableRepository, hospitalRepository, userRepository);
            // SECRETARY OK
            managerRepository = new ManagerRepository(new CSVStream<Manager>(managerFile, new ManagerConverter()), new ComplexSequencer(), timeTableRepository, hospitalRepository, userRepository);
            // MANAGER OK
            doctorRepository = new DoctorRepository(new CSVStream<Doctor>(doctorFile, new DoctorConverter()), new ComplexSequencer(), timeTableRepository, hospitalRepository, roomRepository, userRepository);
            // DOCTOR OK
            patientRepository = new PatientRepository(new CSVStream<Patient>(patientFile, new PatientConverter()), new ComplexSequencer(), doctorRepository, userRepository);
            // PATIENT OK



            hospitalRepository.DoctorRepository = doctorRepository;
            hospitalRepository.ManagerRepository = managerRepository;
            hospitalRepository.SecretaryRepository = secretaryRepository;


            //Misc repositories
            locationRepository = new LocationRepository(new CSVStream<Location>(locationFile, new LocationConverter()), new LongSequencer());
            // LOCATION OK
            notificationRepository = new NotificationRepository(new CSVStream<Notification>(notificationFile, new NotificationConverter()), new LongSequencer(), patientRepository, doctorRepository, managerRepository, secretaryRepository);
            // NOTIFICATION OK
            messageRepository = new MessageRepository(new CSVStream<Message>(messageFile, new MessageConverter()), new LongSequencer(), patientRepository, doctorRepository, managerRepository, secretaryRepository);
            // MESSAGE OK
            articleRepository = new ArticleRepository(new CSVStream<Article>(articleFile, new ArticleConverter()), new LongSequencer(), doctorRepository, managerRepository, secretaryRepository);
            //ARTICLE OK
            questionRepository = new QuestionRepository(new CSVStream<Question>(questionFile, new QuestionConverter()), new LongSequencer());
            // QUESTION OK
            doctorQuestionRepository = new QuestionRepository(new CSVStream<Question>(doctorQuestionFile, new QuestionConverter()), new LongSequencer());
            //DOCTOR QUESTION OK
            feedbackRepository = new FeedbackRepository(new CSVStream<Feedback>(feedbackFile, new FeedbackConverter()), new LongSequencer(), questionRepository, patientRepository, doctorRepository, managerRepository, secretaryRepository);
            doctorFeedbackRepository = new DoctorFeedbackRepository(new CSVStream<DoctorFeedback>(doctorFeedbackFile, new DoctorFeedbackConverter()), new LongSequencer(), doctorQuestionRepository, patientRepository, doctorRepository);


            //Hospital management repositories
            symptomRepository = new SymptomRepository(new CSVStream<Symptom>(symptomsFile, new SymptomConverter()), new LongSequencer());
            //SYMPTOM REPO OK
            diseaseRepository = new DiseaseRepository(new CSVStream<Disease>(diseaseFile, new DiseaseConverter()), new LongSequencer(), medicineRepository, symptomRepository);
            //DISEASE REPO OK
            ingredientRepository = new IngredientRepository(new CSVStream<Ingredient>(ingredientFile, new IngredientConverter()), new LongSequencer());
            //INGREDIENT REPO OK
            medicineRepository = new MedicineRepository(new CSVStream<Medicine>(medicineFile, new MedicineConverter()), new LongSequencer(), ingredientRepository, diseaseRepository);
            //MEDICINE REPO OK


            prescriptionRepository = new PrescriptionRepository(new CSVStream<Prescription>(prescriptionFile, new PrescriptionConverter()), new LongSequencer(), doctorRepository, medicineRepository);
            //PRESCRIPTION REPO OK

            //Medical repositories

            allergyRepository = new AllergyRepository(new CSVStream<Allergy>(allergyFile, new AllergyConverter()), new LongSequencer(), ingredientRepository, symptomRepository);
            //ALLERGY REPO OK

            appointmentRepository = new AppointmentRepository(new CSVStream<Appointment>(appointmentsFile, new AppointmentConverter()), new LongSequencer(), patientRepository, doctorRepository, roomRepository);
            //GERGO REPO OK?
            therapyRepository = new TherapyRepository(new CSVStream<Therapy>(therapyFile, new TherapyConverter()), new LongSequencer(), medicalRecordRepository, medicalRecordRepository, prescriptionRepository, diagnosisRepository);

            //med record
            medicalRecordRepository = new MedicalRecordRepository(new CSVStream<MedicalRecord>(medicalRecordFile, new MedicalRecordConverter()), new LongSequencer(), patientRepository, diagnosisRepository, allergyRepository);
            //u medical record moras da set diagnosis repo
            diagnosisRepository = new DiagnosisRepository(new CSVStream<Diagnosis>(diagnosisFile, new DiagnosisConverter()), new LongSequencer(), therapyRepository, diseaseRepository, medicalRecordRepository);
            //therapy
            // therapyRepository = new TherapyRepository(new CSVStream<Therapy>(therapyFile,new TherapyConverter()),new LongSequencer(),medicalRecordRepository, )

            diseaseRepository.MedicineEagerCSVRepository = medicineRepository;
            medicineRepository.DiseaseRepository = diseaseRepository;

            medicalRecordRepository.DiagnosisRepository = diagnosisRepository;
            diagnosisRepository.MedicalRecordRepository = medicalRecordRepository;
            diagnosisRepository.TherapyEagerCSVRepository = therapyRepository;
            therapyRepository.DiagnosisCSVRepository = diagnosisRepository;
            therapyRepository.MedicalRecordRepository = medicalRecordRepository;
            therapyRepository.MedicalRecordEagerCSVRepository = medicalRecordRepository;



            //ODAVDDE RADITI OSTALE

            doctorStatisticRepository = new DoctorStatisticRepository(new CSVStream<StatsDoctor>(doctorStatisticsFile, new DoctorStatisticsConverter(",")), new LongSequencer(), doctorRepository);
            // Doc Stats OK

            inventoryStatisticRepository = new InventoryStatisticsRepository(new CSVStream<StatsInventory>(inventoryStatisticsFile, new InventoryStatisticsConverter(",")), new LongSequencer(), medicineRepository, inventoryItemRepository);
            // InventoryStats OK

            roomStatisticRepository = new RoomStatisticsRepository(new CSVStream<StatsRoom>(roomStatisticsFile, new RoomStatisticsConverter(",")), new LongSequencer(), roomRepository);
            // RoomStats OK

            inventoryRepository = new InventoryRepository(new CSVStream<Inventory>(inventoryFile, new InventoryConverter(",", ";")), new LongSequencer(), inventoryItemRepository, medicineRepository);

        }

        public static AppResources getInstance()
        {
            if (instance == null)
            {
                instance = new AppResources();
            }

            return instance;
        }

        public void LoadDoctorResources()
        {
            //TODO: Ovde se mogu ucitati strategy pattern i slicne specificne stvari za doktora
            // Ucitava se prilikom login-a
            appointmentService.AppointmentStrategy = new AppointmentDoctorStrategy();
        }

        public void LoadManagerResources()
        {
            //TODO: Ovde se mogu ucitati strategy pattern i slicne specificne stvari za upravnika
            // Ucitava se prilikom login-a
            appointmentService.AppointmentStrategy = new AppointmentManagerStrategy();
        }

        public void LoadPatientResources()
        {
            //TODO: Ovde se mogu ucitati strategy pattern i slicne specificne stvari za pacijenta
            // Ucitava se prilikom login-a
            appointmentService.AppointmentStrategy = new AppointmentPatientStrategy();
        }

        public void LoadSecretaryResources()
        {
            //TODO: Ovde se mogu ucitati strategy pattern i slicne specificne stvari za sekretara
            // Ucitava se prilikom login-a
            appointmentService.AppointmentStrategy = new AppointmentSecretaryStrategy();
            patientService.UserValidation = new SecretaryPatientValidation();
        }
    }
}
