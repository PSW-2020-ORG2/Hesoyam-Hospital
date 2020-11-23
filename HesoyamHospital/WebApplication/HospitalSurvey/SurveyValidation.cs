using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.HospitalSurvey
{
    public class SurveyValidation
    {
        public static bool isNewSurveyValid(SurveyDTO dto)
            => dto != null;
    }
}
