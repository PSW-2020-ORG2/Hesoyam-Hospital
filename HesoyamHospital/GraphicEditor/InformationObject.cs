using System.Windows;

namespace GraphicEditor
{
    public class InformationObject
    {
        public InformationObject()
        {
        }
        public string VisitingHours { get; set; }

        public string WorkingHours { get; set; }

        public string Doctor { get; set; }

        public InformationObject(string visitingHours, string workingHours, string doctor)
        {
            VisitingHours = visitingHours;
            WorkingHours = workingHours;
            Doctor = doctor;
        }
    }
}