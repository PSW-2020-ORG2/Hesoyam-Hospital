using System;
using Xunit;
using GraphicEditor.Service;
using Backend.Model.UserModel;
using System.Collections.Generic;
using System.Windows.Automation;

namespace GraphicEditorTests
{
    public class LogInTests
    {
        [Fact]
        public void find_all_doctors()
        {
            LogInService service = new LogInService();
            List<Doctor> d = service.getAllDoctors();
            Assert.NotNull(d);
        }
        [Fact]
        public void find_all_patients()
        {
            LogInService service = new LogInService();
            List<Patient> p = service.getAllPatients();
            Assert.NotNull(p);
        }
        [Fact]
        public void find_all_mangers()
        {
            LogInService service = new LogInService();
            List<Manager> m = service.getAllManagers();
            Assert.NotNull(m);
        }

    }
}
