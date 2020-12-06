using System;
using System.Collections.Generic;
using System.IO;

namespace GraphicEditor
{
    class GraphicRepository
    {
        public GraphicRepository()
        {

        }

        public List<GraphicalObject> ReadFromFile(string fileName)
        {
            string path = Path.GetFullPath(fileName);
            List<GraphicalObject> list = new List<GraphicalObject>();

            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                string[] loc = lines[0].Split(',');
                string hospital = loc[0].Trim();
                string floor = loc[1].Trim();
                foreach (string line in lines)
                {
                    GraphicalObject graphical_object = ConvertLineToGraphicalObject(line, hospital, floor);
                    if(graphical_object != null)
                        list.Add(graphical_object);
                }
            }
            else
            {
                return list;
            }
            return list;
        }

        private GraphicalObject ConvertLineToGraphicalObject(string line, string hospital, string floor)
        {
            string[] fields = line.Split(',');
            if (fields.Length != 7) {

                return null;
            }
            string type = fields[0].Trim();
            string name = fields[1].Trim();
            long width = Convert.ToInt64(fields[2]);
            long height = Convert.ToInt64(fields[3]);
            long top = Convert.ToInt64(fields[4]);
            long left = Convert.ToInt64(fields[5]);
            string shape = fields[6].Trim();

            return new GraphicalObject(type, name, width, height, top, left, shape, hospital, floor);

        }

        public List<FileInformation> readFileInformation(string fileName) {
            string path = Path.GetFullPath(fileName);
            List<FileInformation> information = new List<FileInformation>();

            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    FileInformation fileInformation = ConvertLineToFileInformation(line);
                    if (fileInformation != null)
                        information.Add(fileInformation);
                }
            }

            return information;
        }

        private FileInformation ConvertLineToFileInformation(string line)
        {
            string[] fields = line.Split(',');
            if (fields.Length != 2)
            {
                return null;
            }
            string name = fields[0].Trim();
            string path = fields[1].Trim();

            return new FileInformation(name, path);
        }
    }
}
