using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicEditor.DTOs
{
    public class PatientDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Jmbg { get; set; }


        public string DateOfBirth { get; set; }

        public PatientDTO(long id, string name, string surname, string jmbg, string dateOfBirth)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Jmbg = jmbg;
            DateOfBirth = dateOfBirth;
        }
    }
}
