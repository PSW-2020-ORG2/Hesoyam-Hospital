
namespace GraphicEditor
{
    class FileInformation
    {
        public FileInformation(string name, string filePath)
        {
            Name = name;
            FilePath = filePath;
        }
        public string Name { get; set; }

        public string FilePath { get; set; }
    }
}
