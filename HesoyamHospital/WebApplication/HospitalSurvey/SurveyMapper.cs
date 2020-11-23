using Backend;
using Backend.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.HospitalSurvey
{
    public class SurveyMapper
    {
        public static Survey SurveyDTOToSurvey(SurveyDTO dto)
        {
            Survey survey = new Survey();

            Section doctorSection = new Section(dto.AnswerOne, dto.AnswerTwo, dto.AnswerThree, dto.AnswerFour);
            Section staffSection= new Section(dto.AnswerFive, dto.AnswerSix, dto.AnswerSeven, dto.AnswerEight);
            Section hygieneSection = new Section(dto.AnswerNine, dto.AnswerTen, dto.AnswerEleven, dto.AnswerTwelve);
            Section equipmentSection = new Section(dto.AnswerThirteen, dto.AnswerFourteen, dto.AnswerFifteen, dto.AnswerSixteen);

            survey.Doctor = AppResources.getInstance().doctorService.GetByID(600);
            survey.DoctorSection = doctorSection;
            survey.StaffSection = staffSection;
            survey.HygieneSection = hygieneSection;
            survey.EquipmentSection = equipmentSection;

            return survey; 
        }
    }
}
