/***********************************************************************
 * Module:  DiseaseType.cs
 * Author:  nikola
 * Purpose: Definition of the Class DiseaseType
 ***********************************************************************/

using System;

namespace SIMS.Model.PatientModel
{
    public class DiseaseType
    {
        private bool infectious;
        private bool genetic;
        private string type;

        public DiseaseType(bool infectious, bool genetic, string type)
        {
            this.Infectious = infectious;
            this.Genetic = genetic;
            this.Type = type;
        }

        public bool Infectious { get => infectious; set => infectious = value; }
        public bool Genetic { get => genetic; set => genetic = value; }
        public string Type { get => type; set => type = value; }
    }


}