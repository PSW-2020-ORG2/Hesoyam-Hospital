namespace GraphicEditor
{
    public class MapLocation
    {

        public string Name { get; set; }

        public string Hospital { get; set; }

        public string Floor { get; set; }

        public string FilePath { get; set; }

        public MapLocation()
        {
        }

        public MapLocation(string hospital, string floor, string name, string filePath)
        {
            Name = name;
            Hospital = hospital;
            Floor = floor;
            FilePath = filePath;

        }
    }
}
