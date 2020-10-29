using SIMS.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SIMS.Repository.CSVFileRepository.Csv.Converter.HospitalManagementConverter;
using SIMS.Model.ManagerModel;
using SIMS.Repository.CSVFileRepository.Csv.Converter.MedicalConverter;
using SIMS.Model.DoctorModel;
using SIMS.Model.PatientModel;

using SIMS.Repository.CSVFileRepository.MedicalRepository;
using SIMS.Repository.CSVFileRepository.HospitalManagementRepository;
using SIMS.Util;
using SIMS.Repository.CSVFileRepository.Csv.Converter.UsersConverter;
using SIMS.Repository.CSVFileRepository.Csv.Converter.MiscConverter;
using System.Windows.Controls;
using SIMS.Service.UsersService;
using SIMS.Service.MedicalService;
using SIMS.Controller.MedicalController;

namespace SIMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Patient p = new Patient();

            //HospitalConverter converter = new HospitalConverter(",");
            //List<Room> testList = new List<Room>();
            //testList.Add(new Room(1, "22", true, 2, RoomType.operation, new Model.ManagerModel.InventoryItem()));
            //testList.Add(new Room(2, "23", true, 2, RoomType.operation, new Model.ManagerModel.InventoryItem()));
            //Hospital hospital = new Hospital(1,"Test hospital", "555-333", "besthospital.com", new List<Room>(), new List<Employee>(), new Address("koste sokice 3",new Location(22,new Country("RS","Srbija"),new City("novi sad","21000"))));
            //HospitalConverter converter = new HospitalConverter(",", ";");
            //List<Room> testList = new List<Room>();
            //List<Employee> employeeList = new List<Employee>();
            //Address address = new Address("koste sokice 3", new Location(22, new Country("RS", "Srbija"), new City("novi sad", "21000")));
            //Doctor doctor = new Doctor(new UserID("D123"), "pera", "pera123", DateTime.Now, "Pera", "Vunic", "Puck", Sex.MALE, DateTime.Now, "12345667", address, "555-333", "06130959858", "pera@gmail.com", "pera111@gmail.com", new TimeTable(new Dictionary<WorkingDaysEnum, Util.TimeInterval>()), new Hospital("test", address, "555-333", "zzzz"), new Room(1), DocTypeEnum.CARDIOLOGIST);
            //employeeList.Add(doctor);
            //List<InventoryItem> listItem = new List<InventoryItem>();
            //listItem.Add(new InventoryItem("skalpel", 5, 2, new Room(-1)));
            //listItem.Add(new InventoryItem("pera", 10, 3, new Room(-2)));
            //testList.Add(new Room(1, "22", true, 2, RoomType.OPERATION, listItem));
            //testList.Add(new Room(2, "23", true, 2, RoomType.OPERATION, listItem));
            //Hospital hospital = new Hospital(6, "tst hosp", new Address("koste sokice 3", new Location(22, new Country("RS", "Srbija"), new City("novi sad", "21000"))), "555-333", "www.facebook.com", testList, employeeList);
            //string csv = converter.ConvertEntityToCSV(hospital);
            //Console.WriteLine("OLD CSV: " + csv);
            //Hospital newHospital = converter.ConvertCSVToEntity(csv);


            //Console.WriteLine("NEW CSV: " + converter.ConvertEntityToCSV(newHospital));
            //Room testRoom = new Room(22);
            //List<Medicine> medicines = new List<Medicine>();
            //List<InventoryItem> inventoryItems = new List<InventoryItem>();
            //Medicine medicine1 = new Medicine(22, "pera", 33, MedicineType.DROPS, true, new List<Disease>(), new List<Ingredient>(), 5, 6);
            //Medicine medicine2 = new Medicine(77, "pera", 33, MedicineType.DROPS, true, new List<Disease>(), new List<Ingredient>(), 5, 6);

            //InventoryItem inventoryItem1 = new InventoryItem(33, "inventoryItem1", 2, 5, testRoom);
            //InventoryItem inventoryItem2 = new InventoryItem(44, "inventoryItem2", 2, 5, testRoom);

            //medicines.Add(medicine1);
            //medicines.Add(medicine2);

            //inventoryItems.Add(inventoryItem1);
            //inventoryItems.Add(inventoryItem2);

            //InventoryConverter inventoryConverter = new InventoryConverter(",", ";");
            //Inventory inventory = new Inventory(69, inventoryItems, medicines);

            //string csv = inventoryConverter.ConvertEntityToCSV(inventory);
            //Console.WriteLine("OLD CSV: " + csv);

            //Inventory inventoryNew = inventoryConverter.ConvertCSVToEntity(csv);

            //Console.WriteLine("New csv" + inventoryConverter.ConvertEntityToCSV(inventoryNew));
            //Disease disease = new Disease(2);
            //Disease disease1 = new Disease(5);
            //Disease disease2 = new Disease(7);
            //List<Disease> diseaseList = new List<Disease>();
            //diseaseList.Add(disease);
            //diseaseList.Add(disease1);
            //diseaseList.Add(disease2);
            //Ingredient ingredient = new Ingredient(1);
            //Ingredient ingredient1 = new Ingredient(2);
            //Ingredient ingredient2 = new Ingredient(3);
            //List<Ingredient> ingredientList = new List<Ingredient>();
            //ingredientList.Add(ingredient);
            //ingredientList.Add(ingredient1);
            //ingredientList.Add(ingredient2);

            //Medicine medicine = new Medicine(69, "droga", 500, MedicineType.DROPS, true, diseaseList, ingredientList, 6, 9);
            //MedicineConverter medicineConverter = new MedicineConverter(",", ";");
            //string csv = medicineConverter.ConvertEntityToCSV(medicine);
            //Console.WriteLine("OLD CSV: " + csv);
            //Medicine newMedicine = medicineConverter.ConvertCSVToEntity(csv);
            //Console.WriteLine("New CSV: " + medicineConverter.ConvertEntityToCSV(newMedicine));


            //string retVal = converter.ConvertEntityToCSV(hospital);
            //Console.WriteLine(retVal);
            //Console.WriteLine("TEST");


            /*
            RoomConverter converter = new RoomConverter();

            Room room2 = new Room(2, "23", true, 3, RoomType.OPERATION);
            Room room1 = new Room(1, "22", true, 2, RoomType.OPERATION);

            string retVal1 = converter.ConvertEntityToCSV(room1);
            string retVal2 = converter.ConvertEntityToCSV(converter.ConvertCSVToEntity(retVal1));

            Console.WriteLine(retVal1.Equals(retVal2));

            */
            /*
            MedicalRecordConverter converter2 = new MedicalRecordConverter("*");

            List <Diagnosis> diagList = new List<Diagnosis>();
            diagList.Add(new Diagnosis(2, new Disease(2),new Therapy(2),new List<Therapy>()));
            diagList.Add(new Diagnosis(4, new Disease(2), new Therapy(5), new List<Therapy>()));

            List<Allergy> alerList = new List<Allergy>();
            alerList.Add(new Allergy(6));
            alerList.Add(new Allergy(8));


            MedicalRecord medRec = new MedicalRecord(2, new Patient(new UserID("P69")), BloodType.AB_NEGATIVE, diagList, alerList);
            List<Diagnosis> lista = medRec.PatientDiagnosis;
            string csv = converter2.ConvertEntityToCSV(medRec);
            
            Console.WriteLine("===================================================");
            Console.WriteLine(csv);
            Console.WriteLine("===================================================");
            MedicalRecord medRec2 = converter2.ConvertCSVToEntity(csv);
            Console.WriteLine(converter2.ConvertEntityToCSV(medRec2));
            Console.WriteLine("===================================================");
            */

            /*
            Secretary secretary = new Secretary(new UserID("s1"), "gergoo", "pass123", DateTime.Now, "Sekretar", "Sekretaric", "M", Sex.OTHER, new DateTime(1980,6,18), "0123456789", new Address("Ulica br 4", new Location(87, "Serbia", "Novi Sad")), "021787878", "0646464646", "email1@email", "email2@email", new TimeTable(78), new Hospital(7));
            SecretaryConverter conv = new SecretaryConverter(";", "dd.MM.yyyy.");
            string secString1 = conv.ConvertEntityToCSV(secretary);
            Console.WriteLine(secString1);
            string secString2 = conv.ConvertEntityToCSV(conv.ConvertCSVToEntity(secString1));
            Console.WriteLine(secString1.Equals(secString2));
            */
            /*
            User user = new User(new UserID("d5677"), "usernaaaa", "passwd", DateTime.Now, true);
            UserConverter conv = new UserConverter(",", "dd.MM.yyyy.");
            string usrString1 = conv.ConvertEntityToCSV(user);
            Console.WriteLine(usrString1);
            string usrString2 = conv.ConvertEntityToCSV(conv.ConvertCSVToEntity(usrString1));
            Console.WriteLine(usrString1.Equals(usrString2));*/

            /** Prescription tests **/

            //Dictionary<Medicine, TherapyDose> medicine = new Dictionary<Medicine, TherapyDose>();
            //Dictionary<TherapyTime, double> dosage1 = new Dictionary<TherapyTime, double>();
            //dosage1.Add(TherapyTime.Afternoon, 7);
            //dosage1.Add(TherapyTime.BeforeBed, 3);
            //dosage1.Add(TherapyTime.WhenIWakeUp, 2);
            //medicine.Add(new Medicine(75), new TherapyDose(dosage1));

            //Dictionary<TherapyTime, double> dosage2 = new Dictionary<TherapyTime, double>();
            //dosage2.Add(TherapyTime.AsNeeded, 1);
            //dosage2.Add(TherapyTime.BeforeBed, 2);
            //dosage2.Add(TherapyTime.Afternoon, 6);
            //medicine.Add(new Medicine(54), new TherapyDose(dosage2));

            //Dictionary<TherapyTime, double> dosage3 = new Dictionary<TherapyTime, double>();
            //dosage3.Add(TherapyTime.AsNeeded, 9);
            //dosage3.Add(TherapyTime.Evening, 5);
            //dosage3.Add(TherapyTime.BeforeBed, 3);
            //medicine.Add(new Medicine(23), new TherapyDose(dosage3));

            //Prescription p = new Prescription(78, PrescriptionStatus.ACTIVE, new Doctor(new UserID("d78")), medicine);

            //PrescriptionConverter conv = new PrescriptionConverter(",","~","#","/","!");
            //string csv1 = conv.ConvertEntityToCSV(p);
            //string csv2 = conv.ConvertEntityToCSV(conv.ConvertCSVToEntity(csv1));

            //Console.WriteLine(csv1.Equals(csv2));


            //Allergy allergy = new Allergy(55);

            //Symptom symptom = new Symptom(1);
            //Symptom symptom1 = new Symptom(2);
            //Symptom symptom2 = new Symptom(3);
            //Symptom symptom3 = new Symptom(4);
            //Symptom symptom4 = new Symptom(5);
            //Symptom symptom5 = new Symptom(6);

            //List<Symptom> symptoms = new List<Symptom>();
            //symptoms.Add(symptom);
            //symptoms.Add(symptom1);
            //symptoms.Add(symptom2);
            //symptoms.Add(symptom3);
            //symptoms.Add(symptom4);
            //symptoms.Add(symptom5);

            //allergy.Symptoms = symptoms;

            //Symptom temp = symptoms[1];
            //temp = new Symptom(6000);



            //AllergyConverter allergyConverter = new AllergyConverter(",", ";");
            //Symptom symptom = new Symptom(1);
            //Symptom symptom1 = new Symptom(2);
            //Ingredient ingredient = new Ingredient(69);

            //List<Symptom> symptom_list = new List<Symptom>();

            //symptom_list.Add(symptom);
            //symptom_list.Add(symptom1);


            ////Allergy allergy = new Allergy(33, "Test alergija", ingredient, symptom_list);
            //Allergy allergy = new Allergy(33, "Test alergija", ingredient, null);

            //string csv = allergyConverter.ConvertEntityToCSV(allergy);

            //Allergy newAllergy = allergyConverter.ConvertCSVToEntity(csv);

            //Console.WriteLine("OLD CSV: " + csv);
            //Console.WriteLine("NEW CSV: " + allergyConverter.ConvertEntityToCSV(newAllergy));
            //String ingredient_path = @"../../files/ingredients.txt";
            //String symptom_path = @"../../files/symptoms.txt";
            //String allergy_path = @"../../files/allergies.txt";


            //IngredientRepository ingredientRepository = new IngredientRepository("ingredient_test", new CSVStream<Ingredient>(ingredient_path, new IngredientConverter(",")), new LongSequencer());
            //SymptomRepository symptomRepository = new SymptomRepository("symptom_repo", new CSVStream<Symptom>(symptom_path, new SymptomConverter(",")), new LongSequencer());
            //AllergyRepository allergyRepository = new AllergyRepository("test", new CSVStream<Allergy>(allergy_path, new AllergyConverter(",",";")), new LongSequencer(), ingredientRepository, symptomRepository);

            //Ingredient ingredient1 = new Ingredient("ingredient_1");
            //Ingredient ingredient2 = new Ingredient("ingredient_2");

            //Symptom symptom1 = new Symptom("Boli me nos", "Jako me boli nos");
            //Symptom symptom2 = new Symptom("Boli me glava", "Jako me boli glava");

            //ingredientRepository.Create(ingredient1);
            //ingredientRepository.Create(ingredient2);

            //symptomRepository.Create(symptom1);
            //symptomRepository.Create(symptom2);

            //List<Symptom> test_list = new List<Symptom>();
            //test_list.Add(symptomRepository.GetByID(1));
            //test_list.Add(symptomRepository.GetByID(2));


            //Allergy allergy = new Allergy("Test allergy", ingredientRepository.GetByID(1), new List<Symptom>());

            //allergyRepository.Create(allergy);


            //String ingredient_path = @"../../files/MedicalFiles/ingredients.txt";
            //String symptom_path = @"../../files/MedicalFiles/symptoms.txt";
            //String allergy_path = @"../../files/MedicalFiles/allergies.txt";


            //IngredientRepository ingredientRepository = new IngredientRepository("ingredient_test", new CSVStream<Ingredient>(ingredient_path, new IngredientConverter(",")), new LongSequencer());
            //SymptomRepository symptomRepository = new SymptomRepository("symptom_repo", new CSVStream<Symptom>(symptom_path, new SymptomConverter(",")), new LongSequencer());
            //AllergyRepository allergyRepository = new AllergyRepository("test", new CSVStream<Allergy>(allergy_path, new AllergyConverter(",", ";")), new LongSequencer(), ingredientRepository, symptomRepository);

            //Ingredient ingredient1 = new Ingredient("ingredient_1");
            //Ingredient ingredient2 = new Ingredient("ingredient_2");

            //Symptom symptom1 = new Symptom("Boli me nos", "Jako me boli nos");
            //Symptom symptom2 = new Symptom("Boli me glava", "Jako me boli glava");

            //ingredientRepository.Create(ingredient1);
            //ingredientRepository.Create(ingredient2);

            //symptomRepository.Create(symptom1);
            //symptomRepository.Create(symptom2);

            //List<Symptom> test_list = new List<Symptom>();
            //test_list.Add(symptomRepository.GetByID(1));
            //test_list.Add(symptomRepository.GetByID(2));


            //Allergy allergy = new Allergy("Test allergy", ingredientRepository.GetByID(1), test_list);

            //Allergy tst = allergyRepository.Create(allergy);

            //foreach (Symptom symp in tst.Symptoms)
            //    Console.WriteLine(symp.Name);
            /*
            AppResources appResources = AppResources.getInstance();

            SymptomRepository symptomRepository = appResources.symptomRepository;
            Symptom symptom1 = new Symptom("B123", "Soba za operacije");
            Symptom symptom2 = new Symptom("B134", "Soba za prijem");
            symptomRepository.Create(symptom1);
            symptomRepository.Create(symptom2);
            

            */



            //AppResources res = AppResources.getInstance();

            //LocationRepoTest();
            //SecretaryRepoTest();
            //PatientRepoTest();
            //TimeTableRepoTest();
            //ManagerRepoTest();
            //DoctorRepoTest();

            //RoomRepoTest();
            //AppointmentRepoTest();

            //NotificationRepoTest();
            //MessageRepoTest();
            //ArticleRepoTest();
            //QuestionRepoTest();
            //FeedbackTest();
            //HospitalRepoTest();
            //DateTimeTest();
            //SymptomRepoTest();
            //IngredientRepoTest();
            //DiseaseMedicineRepoTest();

            //PrescriptionRepoTest();
            //AllergyRepoTest();

            //testDocStats();
            //testInventoryStats();
            //testRoomStats();

            //AppointmentNotificationSenderTest();
        }

        private void AppointmentNotificationSenderTest()
        {
            AppointmentNotificationSender sender = AppResources.getInstance().appointmentNotificationSender;
            AppointmentController controller = AppResources.getInstance().appointmentController;

            Appointment app = controller.GetByID(2);
            Appointment app2 = controller.GetByID(1);
            
            sender.SendCreateNotification(app);
            sender.SendUpdateNotification(app, app2);
            sender.SendCancelNotification(app);

            var notifications = AppResources.getInstance().notificationController.GetNotificationByUser(new User(new UserID("p1")));

            notifications.Select(n => n.Text).ToList().ForEach(Console.WriteLine);
        }

        private void testRoomStats()
        {
            RoomStatisticsRepository rsr = AppResources.getInstance().roomStatisticRepository;
            var room = AppResources.getInstance().roomRepository.GetAll().ToList()[0];

            //var temp = new StatsRoom(100, 50, 15, room);
            //var created = rsr.Create(temp);
            var temp = rsr.GetAllEager().ToList()[0];

            temp.AvgAppointmentTime = 100;
            rsr.Update(temp);

            rsr.Delete(temp);

            Console.WriteLine(temp);
        }

        private void testDocStats()
        {
            Address address = new Address("koste sokice 3", new Location(22, "Srbija", "Novi Sad"));
            Doctor doctor = new Doctor(new UserID("D123"), "pera", "pera123", DateTime.Now, "Pera", "Vunic", "Puck", Sex.MALE, DateTime.Now, "12345667", address, "555-333", "06130959858", "pera@gmail.com", "pera111@gmail.com", new TimeTable(new Dictionary<WorkingDaysEnum, Util.TimeInterval>()), new Hospital("test", address, "555-333", "zzzz"), new Room(1), DoctorType.CARDIOLOGIST);
            DoctorStatisticRepository dsr = AppResources.getInstance().doctorStatisticRepository;

            //StatsDoctor temp = new StatsDoctor(111, 15, "15 minutes", doctor);
            //dsr.Create(temp);
            var AllStats = dsr.GetAllEager();
            StatsDoctor temp = AllStats.ToList()[0];

            temp.NumberOfAppointments = 20;
            temp.AvgAppointmentTime = "20 minutes";
            dsr.Update(temp);
            dsr.Delete(temp);
            Console.WriteLine(AllStats);
        }

        private void testInventoryStats()
        {
            InventoryStatisticsRepository isr = AppResources.getInstance().inventoryStatisticRepository;
            var AllStats = isr.GetAllEager();
            Medicine medicine1 = AppResources.getInstance().medicineRepository.GetAllEager().ToList()[0];
            var iir = AppResources.getInstance().inventoryItemRepository;
            iir.Create(new InventoryItem("Papir", 5, 1, new Room(5)));
            InventoryItem ii1 = iir.GetAllEager().ToList()[0];


            StatsInventory temp = new StatsInventory(50, medicine1, ii1);
            //isr.Create(temp);
            var temp1 = AllStats.ToList()[0];
            temp.Usage = 100;

            isr.Update(temp1);

            var updated = isr.GetAllEager().ToList()[0];

            Console.WriteLine(updated);
        }

        private void AllergyRepoTest()
        {
            AllergyRepository allergyRepository = AppResources.getInstance().allergyRepository;
            SymptomRepository symptomRepository = AppResources.getInstance().symptomRepository;
            IngredientRepository ingredientRepository = AppResources.getInstance().ingredientRepository;

            Ingredient ingredient1 = ingredientRepository.Create(new Ingredient("Koka"));
            Ingredient ingredient2 = ingredientRepository.Create(new Ingredient("Amphetamine"));
            Ingredient ingredient3 = ingredientRepository.Create(new Ingredient("Lavanda"));

            Symptom symptom1 = symptomRepository.Create(new Symptom("Simptom 1", "Opis 1 simptoma"));
            Symptom symptom2 = symptomRepository.Create(new Symptom("Simptom 2", "Opis 2 simptoma"));
            Symptom symptom3 = symptomRepository.Create(new Symptom("Simptom 3", "Opis 3 simptoma"));

            List<Symptom> symptomList1 = new List<Symptom>();
            List<Symptom> symptomList2 = new List<Symptom>();
            List<Symptom> symptomList3 = new List<Symptom>();


            symptomList2.Add(symptom1);
            symptomList2.Add(symptom2);

            symptomList3.Add(symptom1);
            symptomList3.Add(symptom2);
            symptomList3.Add(symptom3);



            Allergy allergy1 = allergyRepository.Create(new Allergy("Alergija 1", ingredient1, symptomList1));
            Allergy allergy2 = allergyRepository.Create(new Allergy("Alergija 2", ingredient2, symptomList2));
            Allergy allergy3 = allergyRepository.Create(new Allergy("Alergija 3", ingredient3, symptomList3));


            allergy1.Name = "TEST ALLERGY";

            allergyRepository.Update(allergy1);

            Allergy temp = allergyRepository.GetByID(1);

            Console.WriteLine(temp.Name);


        }

        private void PrescriptionRepoTest()
        {
            PrescriptionRepository prescriptionRepository = AppResources.getInstance().prescriptionRepository;
            Dictionary<Medicine, TherapyDose> medicine = new Dictionary<Medicine, TherapyDose>();
            Dictionary<TherapyTime, double> dosage1 = new Dictionary<TherapyTime, double>();
            dosage1.Add(TherapyTime.Afternoon, 7);
            dosage1.Add(TherapyTime.BeforeBed, 3);
            dosage1.Add(TherapyTime.WhenIWakeUp, 2);
            Medicine test1 = new Medicine(75);
            medicine.Add(test1, new TherapyDose(dosage1));

            Dictionary<TherapyTime, double> dosage2 = new Dictionary<TherapyTime, double>();
            dosage2.Add(TherapyTime.AsNeeded, 1);
            dosage2.Add(TherapyTime.BeforeBed, 2);
            dosage2.Add(TherapyTime.Afternoon, 6);
            Medicine test2 = new Medicine(54);
            medicine.Add(test2, new TherapyDose(dosage2));

            Dictionary<TherapyTime, double> dosage3 = new Dictionary<TherapyTime, double>();
            dosage3.Add(TherapyTime.AsNeeded, 9);
            dosage3.Add(TherapyTime.Evening, 5);
            dosage3.Add(TherapyTime.BeforeBed, 3);
            medicine.Add(new Medicine(23), new TherapyDose(dosage3));

            Prescription p = new Prescription(PrescriptionStatus.ACTIVE, new Doctor(new UserID("d78")), medicine);
            Prescription p1 = new Prescription(PrescriptionStatus.ACTIVE, new Doctor(new UserID("d65")), medicine);

            p = prescriptionRepository.Create(p);
            p1 = prescriptionRepository.Create(p1);

            p.Medicine.Remove(test2);

            //A p1-u cemo da promenimo dosage da se uzima i as needed
            TherapyDose newTherapy = p1.Medicine[test1];
            newTherapy.Dosage.Add(TherapyTime.AsNeeded, 555);
            p1.Medicine.Remove(test1);
            p1.Medicine.Add(test1, newTherapy);

            prescriptionRepository.Update(p1);
            prescriptionRepository.Update(p);





        }

        private void DiseaseMedicineRepoTest()
        {
            SymptomRepository symptomRepository = AppResources.getInstance().symptomRepository;
            DiseaseRepository diseaseRepository = AppResources.getInstance().diseaseRepository;
            MedicineRepository medicineRepository = AppResources.getInstance().medicineRepository;

            Symptom symptom1 = symptomRepository.Create(new Symptom("Bol u vratu", "Jak bol u prednjem delu vrata"));
            Symptom symptom2 = symptomRepository.Create(new Symptom("bol u uvetu", "Jak bol u srednjem uvetu"));
            List<Symptom> symptomList = new List<Symptom>();
            symptomList.Add(symptom1);
            symptomList.Add(symptom2);


            Medicine medicine1 = medicineRepository.Create(new Medicine("Oljaprofen", 10000, MedicineType.PILL, 5, 7));
            Medicine medicine2 = medicineRepository.Create(new Medicine("Zetaprofen", 1200, MedicineType.LIQUID, 5, 7));
            Disease disease = new Disease("Hashimoto's disease", "Bolest stitne zlezde", true, new DiseaseType(false, true, "teska boles'"), symptomList);
            Disease disease1 = new Disease("Tumor", "Bolest glave", true, new DiseaseType(false, true, "teska boles'"), symptomList);

            disease = diseaseRepository.Create(disease);
            disease1 = diseaseRepository.Create(disease1);

            disease.AdministratedFor.Add(medicine1);
            medicine1.UsedFor.Add(disease);
            disease.AdministratedFor.Add(medicine2);
            medicine2.UsedFor.Add(disease);

            medicineRepository.Update(medicine1);
            medicineRepository.Update(medicine2);

            diseaseRepository.Update(disease);



        }


        private void IngredientRepoTest()
        {
            IngredientRepository ingredientRepository = AppResources.getInstance().ingredientRepository;
            Ingredient ingredient1 = new Ingredient("Koka");
            Ingredient ingredient2 = new Ingredient("Amphetamine");
            Ingredient ingredient3 = new Ingredient("Lavanda");
            ingredientRepository.Create(ingredient1);
            ingredientRepository.Create(ingredient2);
            ingredientRepository.Create(ingredient3);

            Ingredient test1 = ingredientRepository.GetByID(1);
            Ingredient test2 = ingredientRepository.GetByID(2);
            Ingredient test3 = ingredientRepository.GetByID(3);

            Console.WriteLine(test1.Id + test1.Name);
            Console.WriteLine(test2.Id + test2.Name);
            Console.WriteLine(test3.Id + test3.Name);

            ingredientRepository.Delete(test1);
            ingredientRepository.Delete(test2);
        }

        private void SymptomRepoTest()
        {
            SymptomRepository symptomRepository = AppResources.getInstance().symptomRepository;
            Symptom symptom1 = new Symptom("Simptom 1", "Opis 1 simptoma");
            Symptom symptom2 = new Symptom("Simptom 2", "Opis 2 simptoma");
            Symptom symptom3 = new Symptom("Simptom 3", "Opis 3 simptoma");

            symptomRepository.Create(symptom1);
            symptomRepository.Create(symptom2);
            symptomRepository.Create(symptom3);


            Symptom test1 = symptomRepository.GetByID(1);
            Symptom test2 = symptomRepository.GetByID(2);
            Symptom test3 = symptomRepository.GetByID(3);
            Symptom test4 = symptomRepository.GetByID(4);

            Console.WriteLine(test1.GetId() + " " + test1.Name + " " + test1.ShortDescription);
            Console.WriteLine(test2.GetId() + " " + test2.Name + " " + test2.ShortDescription);
            Console.WriteLine(test3.GetId() + " " + test3.Name + " " + test3.ShortDescription);

            if(test4 == null)
            {
                Console.WriteLine("Test 4 je null, nije pronadjen sa tim ID-om!");
            }

            symptomRepository.Delete(test1);
            symptomRepository.Delete(test2);
            symptomRepository.Delete(test3);

            symptomRepository.Create(symptom1);
        }

        private void DateTimeTest()
        {
            DateTime dt1start = new DateTime(2020, 6, 12, 9, 40, 0);
            DateTime dt1end = new DateTime(2020, 6, 12, 9, 50, 0);
            DateTime dt2start = new DateTime(1990, 7, 5, 8, 0, 0);
            DateTime dt2end = new DateTime(1990, 7, 5, 11, 0, 0);

            // Is 9:40 - 9:50 between 8:00 - 11:00 ?
            Console.WriteLine(new TimeInterval(dt2start, dt2end).IsTimeBetween(new TimeInterval(dt1start, dt1end)));
            Console.WriteLine(new TimeInterval(dt2start, dt2end).IsDateTimeBetween(new TimeInterval(dt1start, dt1end)));


        }

        private void HospitalRepoTest()
        {
            AppResources res = AppResources.getInstance();
            Hospital h1 = new Hospital("mndjns", new Address("sowijdwlk", res.locationRepository.GetLocationByCountry("Serbia").ToList()[5]), "jsihkjsd", "shjdhsk");
            h1.AddRoom(res.roomRepository.GetAll().ToList()[0]);
            h1.AddRoom(res.roomRepository.GetAll().ToList()[1]);
            h1.AddEmployee(res.managerRepository.GetAllEager().ToList()[0]);
            h1.AddEmployee(res.secretaryRepository.GetAllEager().ToList()[0]);
            h1.AddEmployee(res.doctorRepository.GetAllEager().ToList()[0]);

            res.hospitalRepository.Create(h1);

            foreach(Hospital h in res.hospitalRepository.GetAllEager())
            {
                Console.WriteLine("Rooms: ");
                foreach(Room r in h.Room)
                {
                    Console.WriteLine(r.GetId() + " " + r.RoomNumber);
                }
                Console.WriteLine("Employees: ");
                foreach (Employee e in h.Employee)
                {
                    Console.WriteLine(e.GetId().ToString() + " " + e.Name);
                }
            }
        }

        private void QuestionRepoTest()
        {
            AppResources res = AppResources.getInstance();

            /*
            Question q1 = new Question("Prvo pitanje");
            Question q2 = new Question("Drugo pitanje");
            Question q3 = new Question("Treće pitanje");
            Question q4 = new Question("Četvrto pitanje");

            res.questionRepository.Create(q1);
            res.questionRepository.Create(q2);
            res.questionRepository.Create(q3);
            res.questionRepository.Create(q4);

            foreach(Question q in res.questionRepository.GetAll())
            {
                Console.WriteLine(q.Text);
            }
            */
            Question q1 = new Question("Prvo doktor pitanje");
            Question q2 = new Question("Drugo doktor pitanje");
            Question q3 = new Question("Treće doktor pitanje");
            Question q4 = new Question("Četvrto doktor pitanje");

            //res.doctorQuestionRepository.Create(q1);
            //res.doctorQuestionRepository.Create(q2);
            //res.doctorQuestionRepository.Create(q3);
            //res.doctorQuestionRepository.Create(q4);

            foreach (Question q in res.doctorQuestionRepository.GetAll())
            {
                Console.WriteLine(q.Text);
            }

            //Note (Gergo) : Primetio sam da Console.WriteLine() ne ispise UTF-8 karaktere, i umesto ć,č pise c. Ali string je dobro ucitano iz fajla, UTF-8 enkodingom.
            Question ques = res.doctorQuestionRepository.GetAll().ToList()[2];
            Console.WriteLine(ques.Text.Equals("Treće doktor pitanje"));
            Console.WriteLine(ques.Text.Equals("Trece doktor pitanje"));

        }

        private void FeedbackTest()
        {
            AppResources res = AppResources.getInstance();
            /*
            Dictionary<Question, Rating> r1 = new Dictionary<Question, Rating>();
            r1.Add(new Question(1), new Rating("rating nesto", 7));
            r1.Add(new Question(2), new Rating("rating nesto 2", 5));
            r1.Add(new Question(3), new Rating("rating nesto 3", 1));
            Feedback f1 = new Feedback(new User(new UserID("p3")), "commmment", r1);

            Dictionary<Question, Rating> r2 = new Dictionary<Question, Rating>();
            r2.Add(new Question(1), new Rating("rating nesto", 9));
            r2.Add(new Question(2), new Rating("rating nesto 2", 4));
            r2.Add(new Question(4), new Rating("rating nesto 3", 6));
            Feedback f2 = new Feedback(new User(new UserID("p1")), "commmment22", r2);

            Dictionary<Question, Rating> r3 = new Dictionary<Question, Rating>();
            r3.Add(new Question(2), new Rating("rating nesto", 6));
            r3.Add(new Question(3), new Rating("rating nesto 2", 2));
            r3.Add(new Question(4), new Rating("rating nesto 3", 1));
            Feedback f3 = new Feedback(new User(new UserID("p5")), "commmment33", r3);

            res.feedbackRepository.Create(f1);
            res.feedbackRepository.Create(f2);
            f3 = res.feedbackRepository.Create(f3);

            f3.AddRating(new Question(1), new Rating("rating nesto 4 ADDED", 10));
            res.feedbackRepository.Update(f3);

            foreach(Feedback f in res.feedbackRepository.GetAllEager())
            {
                Console.WriteLine("User: " + f.User.GetId() + " " + f.User.Name);
                Console.WriteLine("Ratings: ");
                foreach(Question q in f.Rating.Keys)
                {
                    Console.WriteLine("Question: " + q.Text);
                    Console.WriteLine("Rating: " + f.Rating[q].Stars);
                }
            }
            */

            Dictionary<Question, Rating> r1 = new Dictionary<Question, Rating>();
            r1.Add(new Question(1), new Rating("rating nesto", 7));
            r1.Add(new Question(2), new Rating("rating nesto 2", 5));
            r1.Add(new Question(3), new Rating("rating nesto 3", 1));
            DoctorFeedback f1 = new DoctorFeedback(new User(new UserID("p3")), "commmment", r1, res.doctorRepository.GetByID(new UserID("d1")));

            Dictionary<Question, Rating> r2 = new Dictionary<Question, Rating>();
            r2.Add(new Question(1), new Rating("rating nesto", 9));
            r2.Add(new Question(2), new Rating("rating nesto 2", 4));
            r2.Add(new Question(4), new Rating("rating nesto 3", 6));
            DoctorFeedback f2 = new DoctorFeedback(new User(new UserID("p1")), "commmment22", r2, res.doctorRepository.GetByID(new UserID("d2")));

            Dictionary<Question, Rating> r3 = new Dictionary<Question, Rating>();
            r3.Add(new Question(2), new Rating("rating nesto", 6));
            r3.Add(new Question(3), new Rating("rating nesto 2", 2));
            r3.Add(new Question(4), new Rating("rating nesto 3", 1));
            DoctorFeedback f3 = new DoctorFeedback(new User(new UserID("p5")), "commmment33", r3, res.doctorRepository.GetByID(new UserID("d3")));

            res.doctorFeedbackRepository.Create(f1);
            res.doctorFeedbackRepository.Create(f2);
            f3 = res.doctorFeedbackRepository.Create(f3);

            f3.AddRating(new Question(1), new Rating("rating nesto 4 ADDED", 10));
            res.doctorFeedbackRepository.Update(f3);

            foreach (DoctorFeedback f in res.doctorFeedbackRepository.GetAllEager())
            {
                Console.WriteLine("Patient: " + f.User.GetId() + " " + f.User.Name);
                Console.WriteLine("Doctor: " + f.Doctor.GetId() + " " + f.Doctor.Name);
                Console.WriteLine("Ratings: ");
                foreach (Question q in f.Rating.Keys)
                {
                    Console.WriteLine("Question: " + q.Text);
                    Console.WriteLine("Rating: " + f.Rating[q].Stars);
                }
            }

        }

        private void ArticleRepoTest()
        {
            AppResources res = AppResources.getInstance();

            Article a1 = new Article("Title jshkj", "short descjiddhj", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi non felis auctor, bibendum sapien ut, tristique arcu. Nullam sed sem quis lectus vestibulum efficitur eu sed dui. Vivamus porttitor nibh. ", res.secretaryRepository.GetByID(new UserID("s1")));
            Article a2 = new Article("Title jshkj", "short descjiddhj", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam dignissim malesuada turpis, vel fringilla velit dapibus non. Pellentesque pellentesque nibh sed nunc auctor, sed aliquet justo rhoncus. Nunc odio diam. ", res.secretaryRepository.GetByID(new UserID("s1")));
            Article a3 = new Article("Title jshkj", "short descjiddhj", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur porta ut enim aliquam commodo. Pellentesque commodo sodales pretium. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia. ", res.managerRepository.GetByID(new UserID("m1")));
            Article a4 = new Article("Title jshkj", "short descjiddhj", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur porta ut enim aliquam commodo. Pellentesque commodo sodales pretium. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia. ", res.doctorRepository.GetByID(new UserID("d3")));
            Article a5 = new Article("Title jshkj", "short descjiddhj", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur porta ut enim aliquam commodo. Pellentesque commodo sodales pretium. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia. ", res.doctorRepository.GetByID(new UserID("d3")));

            res.articleRepository.Create(a1);
            res.articleRepository.Create(a2);
            res.articleRepository.Create(a3);
            res.articleRepository.Create(a4);
            a5 = res.articleRepository.Create(a5);
            a5.Title = "New title";
            res.articleRepository.Update(a5);

            foreach (Article a in res.articleRepository.GetAllEager())
            {
                Console.WriteLine(a.Author.GetId().ToString() + " " + a.Author.Name);
            }

            var articles = res.articleRepository.GetArticleByAuthor(new Employee(new UserID("d3")));
            Console.WriteLine("Get articles by author: " + (articles.Count() == 2));

            articles = res.articleRepository.GetArticleByAuthor(new Employee(new UserID("m5")));
            Console.WriteLine("Get articles by author: " + (articles.Count() == 0));

        }

        private void MessageRepoTest()
        {
            AppResources res = AppResources.getInstance();
            Message m1 = new Message("Lorem ipsum dolor sit amet, consectetur adipiscing elit. In magna mi, posuere id ex ac, egestas congue risus. Sed varius mollis eros, rutrum venenatis urna auctor cursus. Sed non neque.", recipient: new User(new UserID("p5")), sender: new User(new UserID("s1")));
            Message m2 = new Message("Lorem ipsum dolor sit amet, consectetur adipiscing elit. In magna mi, posuere id ex ac, egestas congue risus. Sed varius mollis eros, rutrum venenatis urna auctor cursus. Sed non neque.", recipient: new User(new UserID("p3")), sender: new User(new UserID("d1")));
            Message m3 = new Message("Lorem ipsum dolor sit amet, consectetur adipiscing elit. In magna mi, posuere id ex ac, egestas congue risus. Sed varius mollis eros, rutrum venenatis urna auctor cursus. Sed non neque.", recipient: new User(new UserID("p3")), sender: new User(new UserID("s1")));
            Message m4 = new Message("Lorem ipsum dolor sit amet, consectetur adipiscing elit. In magna mi, posuere id ex ac, egestas congue risus. Sed varius mollis eros, rutrum venenatis urna auctor cursus. Sed non neque.", recipient: new User(new UserID("d1")), sender: new User(new UserID("p3")));
            Message m5 = new Message("Lorem ipsum dolor sit amet, consectetur adipiscing elit. In magna mi, posuere id ex ac, egestas congue risus. Sed varius mollis eros, rutrum venenatis urna auctor cursus. Sed non neque.", recipient: new User(new UserID("m1")), sender: new User(new UserID("s1")));

            //res.messageRepository.Create(m1);
            //res.messageRepository.Create(m2);
            //res.messageRepository.Create(m3);
            //res.messageRepository.Create(m4);
            //m5 = res.messageRepository.Create(m5);
            //m5.Opened = true;

            res.messageRepository.Update(m5);

            Console.WriteLine("Sent messages: " + (res.messageRepository.GetSent(new User(new UserID("d99"))).Count() == 0));

            foreach(Message m in res.messageRepository.GetReceived(new User(new UserID("p3"))))
            {
                Console.WriteLine(m.Recipient.GetId().ToString() + " " + m.Recipient.Name);
            }

            foreach (Message m in res.messageRepository.GetSent(new User(new UserID("s1"))))
            {
                Console.WriteLine(m.Recipient.GetId().ToString() + " " + m.Recipient.Name);
            }

            Console.WriteLine("Received messages: " + (res.messageRepository.GetReceived(new User(new UserID("m99"))).Count() == 0));

            foreach (Message m in res.messageRepository.GetAllEager())
            {
                Console.WriteLine(m.Recipient.Name + " " + m.Sender.Name);
            }
        }

        private void NotificationRepoTest()
        {
            AppResources res = AppResources.getInstance();
            Notification n1 = new Notification("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi non felis auctor, bibendum sapien ut, tristique arcu. Nullam sed sem quis lectus vestibulum efficitur eu sed dui. Vivamus porttitor nibh. ", res.patientRepository.GetByID(new UserID("p1")));
            Notification n2 = new Notification("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam dignissim malesuada turpis, vel fringilla velit dapibus non. Pellentesque pellentesque nibh sed nunc auctor, sed aliquet justo rhoncus. Nunc odio diam. ", res.patientRepository.GetByID(new UserID("p5")));
            Notification n3 = new Notification("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur porta ut enim aliquam commodo. Pellentesque commodo sodales pretium. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia. ", res.patientRepository.GetByID(new UserID("p5")));
            Notification n4 = new Notification("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur porta ut enim aliquam commodo. Pellentesque commodo sodales pretium. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia. ", res.patientRepository.GetByID(new UserID("p2")));
            Notification n5 = new Notification("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur porta ut enim aliquam commodo. Pellentesque commodo sodales pretium. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia. ", res.secretaryRepository.GetByID(new UserID("s2")));

            res.notificationRepository.Create(n1);
            res.notificationRepository.Create(n2);
            res.notificationRepository.Create(n3);
            res.notificationRepository.Create(n4);
            res.notificationRepository.Create(n5);

            foreach (Notification n in res.notificationRepository.GetAllEager())
            {
                Console.WriteLine(n.Recipient.GetId().ToString() + " " + n.Recipient.Name);
            }

            var notifications = res.notificationRepository.GetNotificationByUser(new User(new UserID("p5")));
            Console.WriteLine("Get notifications by user: " + (notifications.Count() == 2));

            notifications = res.notificationRepository.GetNotificationByUser(new User(new UserID("m5")));
            Console.WriteLine("Get notifications by user: " + (notifications.Count() == 0));

        }

        private void AppointmentRepoTest()
        {
            //CONVERTER
            /*
            Appointment ap1 = new Appointment(new Doctor(new UserID("d1")), new Patient(new UserID("p1")), new Room(2), AppointmentType.checkup, new TimeInterval(DateTime.Now, DateTime.Now.AddMinutes(20)));
            Appointment ap2 = new Appointment(null, null, new Room(2), AppointmentType.renovation, new TimeInterval(DateTime.Now, DateTime.Now.AddMinutes(20)));

            AppointmentConverter conv = new AppointmentConverter();
            string s1 = conv.ConvertEntityToCSV(ap1);
            string s2 = conv.ConvertEntityToCSV(conv.ConvertCSVToEntity(s1));
            Console.WriteLine(s1.Equals(s2));

            s1 = conv.ConvertEntityToCSV(ap2);
            s2 = conv.ConvertEntityToCSV(conv.ConvertCSVToEntity(s1));
            Console.WriteLine(s1.Equals(s2));
            */

            //TODO: AppointmentRepoTest

            AppResources res = AppResources.getInstance();
            Appointment ap1 = new Appointment(res.doctorRepository.GetByID(new UserID("d1")), res.patientRepository.GetByID(new UserID("p3")), res.roomRepository.GetByID(2), AppointmentType.checkup, new TimeInterval(new DateTime(2020,6,10,14,0,0), new DateTime(2020, 6, 10, 14, 15, 0)));
            Appointment ap2 = new Appointment(res.doctorRepository.GetByID(new UserID("d2")), res.patientRepository.GetByID(new UserID("p1")), res.roomRepository.GetByID(1), AppointmentType.checkup, new TimeInterval(new DateTime(2020, 6, 10, 15, 0, 0), new DateTime(2020, 6, 10, 15, 15, 0)));
            Appointment ap3 = new Appointment(res.doctorRepository.GetByID(new UserID("d2")), res.patientRepository.GetByID(new UserID("p1")), res.roomRepository.GetByID(3), AppointmentType.checkup, new TimeInterval(new DateTime(2020, 6, 10, 15, 0, 0), new DateTime(2020, 6, 10, 15, 15, 0)));
            Appointment ap4 = new Appointment(res.doctorRepository.GetByID(new UserID("d3")), res.patientRepository.GetByID(new UserID("p1")), res.roomRepository.GetByID(1), AppointmentType.checkup, new TimeInterval(new DateTime(2020,6,10,14,0,0), new DateTime(2020, 6, 10, 14, 15, 0)));

            //res.appointmentRepository.Create(ap1);
            //res.appointmentRepository.Create(ap2);
            //ap3 = res.appointmentRepository.Create(ap3);
            //res.appointmentRepository.Create(ap4);

            //ap3.Canceled = true;
            //res.appointmentRepository.Update(ap3);

            //GET PATIENTS APPOINTMENTS:
            /*
            Console.WriteLine("GET PATIENTS APPOINTMENTS:");
            Console.WriteLine(res.appointmentRepository.GetPatientAppointments(res.patientRepository.GetByID(new UserID("p5"))).Count() == 0);

            Console.WriteLine("GET PATIENTS APPOINTMENTS:");
            Console.WriteLine(res.appointmentRepository.GetPatientAppointments(res.patientRepository.GetByID(new UserID("p3"))).ToList()[0].DoctorInAppointment.GetId().Equals(new UserID("d1")));

            Console.WriteLine("GET APPOINTMENTS BY TIME:");
            Console.WriteLine(res.appointmentRepository.GetAppointmentsByTime(new TimeInterval(new DateTime(2020, 6, 10, 14, 10, 0), new DateTime(2020, 6, 10, 15, 5, 0))).Count() == 4);

            Console.WriteLine("GET APPOINTMENTS BY DOCTOR:");
            Console.WriteLine(res.appointmentRepository.GetAppointmentsByDoctor(res.doctorRepository.GetByID(new UserID("d2"))).ToList()[0].Room.GetId() == 1);

            Console.WriteLine("GET CANCELLED APPOINTMENTS:");
            Console.WriteLine(res.appointmentRepository.GetCanceledAppointments().ToList()[0].Patient.GetId().Equals(new UserID("p1")));

            Console.WriteLine("GET COMPLETED APPOINTMENTS BY PATIENT:");
            Console.WriteLine(res.appointmentRepository.GetCompletedAppointmentsByPatient(res.patientRepository.GetByID(new UserID("p1"))).Count() == 1);

            Console.WriteLine("GET APPOINTMENTS BY ROOM:");
            Console.WriteLine(res.appointmentRepository.GetAppointmentsByRoom(res.roomRepository.GetByID(1)).Count() == 2);

            Console.WriteLine("GET UPCOMING APPOINTMENTS BY PATIENT:");
            Console.WriteLine(res.appointmentRepository.GetUpcomingAppointmentsForPatient(res.patientRepository.GetByID(new UserID("p1"))).Count() == 1);

            Console.WriteLine("GET UPCOMING APPOINTMENTS BY DOCTOR:");
            Console.WriteLine(res.appointmentRepository.GetUpcomingAppointmentsForDoctor(res.doctorRepository.GetByID(new UserID("d2"))).Count() == 1);
            */

            Appointment ap5 = new Appointment(null, null, res.roomRepository.GetByID(1), AppointmentType.renovation, new TimeInterval(new DateTime(2020,6,10,14,0,0), new DateTime(2020, 6, 11, 14, 15, 0)));
            res.appointmentRepository.Create(ap5);

            res.appointmentRepository.GetAllEager();

            AppointmentFilter filter = new AppointmentFilter(res.doctorRepository.GetByID(new UserID("d1")), DoctorType.UNDEFINED, null, AppointmentType.checkup);
            res.appointmentRepository.GetFilteredAppointment(filter);

        }

        private void RoomRepoTest()
        {
            AppResources res = AppResources.getInstance();

            Room r1 = new Room("a1", false, 1, RoomType.EXAMINATION);
            Room r2 = new Room("b2", false, 2, RoomType.EXAMINATION);
            Room r3 = new Room("c3", false, 2, RoomType.OPERATION);
            Room r4 = new Room("d4", false, 4, RoomType.AFTERCARE);
            Room r5 = new Room("b2", false, 4, RoomType.AFTERCARE);

            //res.roomRepository.Create(r1);
            //res.roomRepository.Create(r2);
            //res.roomRepository.Create(r3);
            //res.roomRepository.Create(r4);
            //res.roomRepository.Create(r5);

            Room room = res.roomRepository.GetRoomByName("b2");
            Console.WriteLine("Room by name 'b2'");
            Console.WriteLine(room.RoomNumber + " " + room.RoomType);

            IEnumerable<Room> rooms2 = res.roomRepository.GetRoomsByFloor(2);
            Console.WriteLine("Rooms by floor 2");
            foreach(Room r in rooms2)
            {
                Console.WriteLine(r.RoomNumber);
            }

            IEnumerable<Room> rooms5 = res.roomRepository.GetRoomsByFloor(5);
            Console.WriteLine("Rooms by floor 5");
            foreach (Room r in rooms5)
            {
                Console.WriteLine(r.RoomNumber);
            }

            IEnumerable<Room> roomsExam = res.roomRepository.GetRoomsByType(RoomType.EXAMINATION);
            Console.WriteLine("Examination rooms");
            foreach (Room r in roomsExam)
            {
                Console.WriteLine(r.RoomNumber);
            }


        }

        private void DoctorRepoTest()
        {
            AppResources res = AppResources.getInstance();

            Doctor d1 = new Doctor("drstrange", "VVVVV", "Stephen", "Strange", "Doctor", Sex.MALE, DateTime.Now, "4578457854", null, "0081747474", "", "drstrange@marvel.com", "stephen.strange@marvel.com", null, null, null, DoctorType.SURGEON);
            Doctor d2 = new Doctor("p.kon", "", "Predrag", "Kon", "", Sex.MALE, DateTime.Now, "113543545488", null, "0118754786", "", "dr.kon@zdrav.gov.rs", "", null, null, null, DoctorType.INFECTOLOGIST);
            Doctor d3 = new Doctor("darija", "", "Darija", "Kisic", "", Sex.FEMALE, DateTime.Now, "251812065115", null, "0118798449", "", "darija.kk@gmail.com", "", null, null, null, DoctorType.INFECTOLOGIST);
            Doctor d4 = new Doctor("doktorr", "", "OKurrr", "Kisic", "", Sex.FEMALE, DateTime.Now, "251812065115", null, "0118798449", "", "darija.kk@gmail.com", "", null, null, null, DoctorType.INFECTOLOGIST);

            //res.doctorRepository.Create(d1);
            //res.doctorRepository.Create(d2);
            //res.doctorRepository.Create(d3);
            //res.doctorRepository.Create(d4);
            
            IEnumerable<Doctor> docs = res.doctorRepository.GetDoctorByType(DoctorType.CARDIOLOGIST);
            Console.WriteLine("ByType(CARDIOLOGIST): " + (docs.ToList().Count == 0));

            IEnumerable<Doctor> docs2 = res.doctorRepository.GetDoctorByType(DoctorType.INFECTOLOGIST);
            foreach(Doctor doc in docs2)
            {
                Console.WriteLine(doc.Name + " " + doc.Surname + " " + doc.DoctorType);
            }


            Console.WriteLine("Doctor Filter");

            DoctorFilter filter1 = new DoctorFilter("Stephen", null, DoctorType.UNDEFINED);
            Console.WriteLine("Only Stephen");
            IEnumerable<Doctor> filtered1 = res.doctorRepository.GetFilteredDoctors(filter1);
            foreach (Doctor doc in filtered1)
            {
                Console.WriteLine(doc.Name + " " + doc.Surname + " " + doc.DoctorType);
            }

            DoctorFilter filter2 = new DoctorFilter("", null, DoctorType.INFECTOLOGIST);
            Console.WriteLine("Only infectologists");
            IEnumerable<Doctor> filtered2 = res.doctorRepository.GetFilteredDoctors(filter2);
            foreach (Doctor doc in filtered2)
            {
                Console.WriteLine(doc.Name + " " + doc.Surname + " " + doc.DoctorType);
            }

            DoctorFilter filter3 = new DoctorFilter("", "Kisic", DoctorType.INFECTOLOGIST);
            Console.WriteLine("Only Kisic Infectologist");
            IEnumerable<Doctor> filtered3 = res.doctorRepository.GetFilteredDoctors(filter3);
            foreach (Doctor doc in filtered3)
            {
                Console.WriteLine(doc.Name + " " + doc.Surname + " " + doc.DoctorType);
            }

            DoctorFilter filter4 = new DoctorFilter("Predrag", "Kon", DoctorType.INFECTOLOGIST);
            Console.WriteLine("Only Predrag Kon");
            IEnumerable<Doctor> filtered4 = res.doctorRepository.GetFilteredDoctors(filter4);
            foreach (Doctor doc in filtered4)
            {
                Console.WriteLine(doc.Name + " " + doc.Surname + " " + doc.DoctorType);
            }

            DoctorFilter filter5 = new DoctorFilter("Predrag", "Kon", DoctorType.DERMATOLOGIST);
            Console.WriteLine("Empty");
            IEnumerable<Doctor> filtered5 = res.doctorRepository.GetFilteredDoctors(filter5);
            Console.WriteLine(filtered5.Count() == 0);
            foreach (Doctor doc in filtered5)
            {
                Console.WriteLine(doc.Name + " " + doc.Surname + " " + doc.DoctorType);
            }

            filtered4.ToList()[0].TimeTable = res.timeTableRepository.GetByID(1);
            res.doctorRepository.Update(filtered4.ToList()[0]);

            res.doctorRepository.GetAllEager();
            
        }

        private void ManagerRepoTest()
        {
            AppResources res = AppResources.getInstance();

            Manager manager = new Manager("vucajj", "PASSWRD", "Aleksa", "Vucaj", "", Sex.MALE, new DateTime(1998, 4, 16), "8646532184", new Address("fukdhfid", new Location(659, "Serbia", "Novi Sad")), "", "", "", "", null, null);
            Manager manager2 = new Manager("dragic", "PASSWRD", "Aleksa", "Vucaj", "", Sex.MALE, new DateTime(1998, 4, 16), "8646532184", null, "", "", "", "", null, null);

            //res.managerRepository.Create(manager);
            //res.managerRepository.Create(manager2);
            
            IEnumerable<Manager> managers = res.managerRepository.GetAllEager();
            managers.ToList()[0].Address = new Address("fukdhfid", res.locationRepository.GetByID(659));
            res.managerRepository.Update(managers.ToList()[0]);
            res.managerRepository.GetAllEager();
        
        }

        private void PatientRepoTest()
        {
            AppResources res = AppResources.getInstance();

            Patient p = new Patient(
                                        "ppppp",
                                        "PASSWORD",
                                        "Pera",
                                        "Perić",
                                        "P.",
                                        Sex.MALE,
                                        new DateTime(1987, 10, 12),
                                        "01234678",
                                        null,
                                        "0217878787",
                                        "25848596532",
                                        "pera@peric.rs",
                                        "",
                                        new EmergencyContact("Milan", "Milanović", "", "025478956325"),
                                        PatientType.GUEST,
                                        null);
            Patient p2 = new Patient(
                                        "milic",
                                        "PASSWORD",
                                        "Milica",
                                        "Mikic",
                                        "M.",
                                        Sex.FEMALE,
                                        new DateTime(1992, 11, 7),
                                        "9876543221",
                                        new Address("Partizanska 5", new Location(1, "Serbia", "Novi Sad")),
                                        "0213698569",
                                        "06454545454",
                                        "milica@gmail.com",
                                        "",
                                        new EmergencyContact("Milana", "Milanović", "", "0217474859"),
                                        PatientType.GENERAL,
                                        null);

            //res.patientRepository.Create(p);
            //res.patientRepository.Create(p2);

            Patient patient1 = res.patientRepository.GetByID(new UserID("p7"));
            patient1.SelectedDoctor = res.doctorRepository.GetByID(new UserID("d1"));
            res.patientRepository.Update(patient1);

            Patient patient2 = res.patientRepository.GetByID(new UserID("p6"));
            patient2.SelectedDoctor = res.doctorRepository.GetByID(new UserID("d1"));
            res.patientRepository.Update(patient2);

            Patient patient3 = res.patientRepository.GetByID(new UserID("p3"));
            patient3.SelectedDoctor = res.doctorRepository.GetByID(new UserID("d3"));
            res.patientRepository.Update(patient3);

            IEnumerable<Patient> patients1 =  res.patientRepository.GetPatientByDoctor(new Doctor(new UserID("d1")));
            IEnumerable<Patient> patients2 =  res.patientRepository.GetPatientByDoctor(new Doctor(new UserID("d3")));
            IEnumerable<Patient> patients3 =  res.patientRepository.GetPatientByDoctor(new Doctor(new UserID("d2")));

            Console.WriteLine("D1 doctor's patients");
            foreach(Patient pp in patients1)
            {
                Console.WriteLine(pp.GetId().ToString());
            }

            Console.WriteLine("D3 doctor's patients");
            foreach (Patient pp in patients2)
            {
                Console.WriteLine(pp.GetId().ToString());
            }

            Console.WriteLine("D2 doctor's patients");
            foreach (Patient pp in patients3)
            {
                Console.WriteLine(pp.GetId().ToString());
            }

        }

        private void TimeTableRepoTest()
        {
            AppResources res = AppResources.getInstance();

            Dictionary<WorkingDaysEnum, TimeInterval> shifts = new Dictionary<WorkingDaysEnum, TimeInterval>();
            shifts.Add(WorkingDaysEnum.MONDAY, new TimeInterval(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0), new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 14, 0, 0)));
            shifts.Add(WorkingDaysEnum.TUESDAY, new TimeInterval(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0), new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 20, 0, 0)));
            shifts.Add(WorkingDaysEnum.WEDNESDAY, new TimeInterval(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0), new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 14, 0, 0)));
            shifts.Add(WorkingDaysEnum.THURSDAY, new TimeInterval(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0), new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 20, 0, 0)));
            shifts.Add(WorkingDaysEnum.FRIDAY, new TimeInterval(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0), new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 14, 0, 0)));
            shifts.Add(WorkingDaysEnum.SATURDAY, new TimeInterval(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0), new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0)));
            shifts.Add(WorkingDaysEnum.SUNDAY, new TimeInterval(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0), new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0)));
            TimeTable tt = new TimeTable(shifts);
            //res.timeTableRepository.Create(tt);
            
        }

        private void SecretaryRepoTest()
        {
            /*
            Secretary secretary = new Secretary(new UserID("s1"),"secr3450", "passwd", DateTime.Now, "SekretarIme", "SekretarPrezime", null, Sex.MALE, new DateTime(1999, 5, 5), "4578145236", null, null, null, null, null, null, null);
            SecretaryConverter con = new SecretaryConverter();
            string sec1 = con.ConvertEntityToCSV(secretary);
            Console.WriteLine(sec1);
            string sec2 = con.ConvertEntityToCSV(con.ConvertCSVToEntity(sec1));
            Console.WriteLine(sec2);
            */
            
            //Secretary secretary2 = new Secretary("jidhsdi", "123456", "SekretarIme2", "SekretarPrezime2", null, Sex.MALE, new DateTime(2000, 5, 5), "164410546", null, null, null, null, null, null, null);

            
            AppResources res = AppResources.getInstance();
            IEnumerable<Secretary> s = res.secretaryRepository.GetAllEager();
            s.ToList()[1].TimeTable = res.timeTableRepository.GetByID(1);
            res.secretaryRepository.Update(s.ToList()[1]);
            res.secretaryRepository.GetAllEager();
            
        }

        private void LocationRepoTest()
        {
            AppResources res = AppResources.getInstance();

            IEnumerable<string> countries = res.locationRepository.GetAllCountries();

            string country = countries.ToList()[50];
            Console.WriteLine("Selected country: " + country);
            Console.WriteLine("Cities: ");

            IEnumerable<Location> locs = res.locationRepository.GetLocationByCountry(country);
            foreach(Location l in locs)
            {
                Console.WriteLine(l.City + " " + l.Country);
            }
        }
    }
}
