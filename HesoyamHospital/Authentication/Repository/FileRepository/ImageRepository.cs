﻿using Authentication.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Authentication.Repository.FileRepository
{
    public class ImageRepository : IImageRepository
    {
        public void SaveImage(IFormFile file, string fileName)
        {
            try
            {
                var folderName = Path.Combine("Resources", "Images");
                var solutionPath = Directory.GetParent(Environment.CurrentDirectory).ToString();
                var documentsPath = Path.Combine(solutionPath, "Documents");
                var pathToSave = Path.Combine(documentsPath, folderName);
                var fullPath = Path.Combine(pathToSave, fileName);
                var stream = new FileStream(fullPath, FileMode.Create);
                file.CopyTo(stream);
                stream.Close();
            }
            catch (Exception)
            {
                return;
            }

        }
    }
}
