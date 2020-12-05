using System;
using System.Collections.Generic;
using System.Text;

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
