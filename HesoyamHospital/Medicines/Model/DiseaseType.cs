namespace Medicines.Model
{
    public class DiseaseType
    {
        public long Id { get; set; }
        public bool Infectious { get; set; }
        public bool Genetic { get; set; }
        public string Type { get; set; }

        public DiseaseType(bool infectious, bool genetic, string type)
        {
            this.Infectious = infectious;
            this.Genetic = genetic;
            this.Type = type;
        }
    }
}