using Backend.Service.MedicalService;
using Backend.Util;
using IntegrationAdapter.MedicineReport;
using System;
using System.Collections.Generic;
using Xunit;
using Shouldly;
using System.Media;
using System.Threading;
using System.IO;

namespace IntegrationAdapterTests.Unit
{
    public class PrescribedMedicineReportTests
    {
        private readonly string testFilePath = @"..\..\..\Unit\report.txt";
       
        [Fact]
        public void Checks_if_report_file_is_created()
        {
            TimeInterval interval = new TimeInterval(DateTime.Now, DateTime.Now.AddDays(-7));
            var stubRepository = TherapyStubRepository.CreateRepository(interval);
            TherapyService service = new TherapyService(stubRepository, null);
            PrescribedMedicineReportGenerator generator = new PrescribedMedicineReportGenerator(service, testFilePath);

            generator.GenerateReport(interval);

            File.Exists(testFilePath).ShouldBeTrue();

            File.Delete(testFilePath);

        }
        [Theory]
        [MemberData(nameof(Intervals))]
        public void Checks_if_medicine_is_reported(TimeInterval interval, string includedString, bool expectedValue)
        {   
            var stubRepository = TherapyStubRepository.CreateRepository(interval);
            TherapyService service = new TherapyService(stubRepository, null);
            PrescribedMedicineReportGenerator generator = new PrescribedMedicineReportGenerator(service, testFilePath);

            generator.GenerateReport(interval);

            string text = File.ReadAllText(testFilePath);
            bool compare = text.Contains(includedString);
            compare.ShouldBe(expectedValue);

            File.Delete(testFilePath);

        }

        public static IEnumerable<object[]> Intervals()
        {
            List<object[]> retVal = new List<object[]>();
            //Intervals must include October 15 2020 or November 10 2020 for expected boolean value to be true, else false
            retVal.Add(new object[] { new TimeInterval(new DateTime(2020, 10, 17), new DateTime(2020, 10, 24)), "LEK1", false });
            retVal.Add(new object[] { new TimeInterval(new DateTime(2020, 10, 10), new DateTime(2020, 10, 17)), "LEK2", true });
            retVal.Add(new object[] { new TimeInterval(new DateTime(2020, 11, 5), new DateTime(2020, 11, 12)), "LEK2", false});
            return retVal;
        }
    }
}
