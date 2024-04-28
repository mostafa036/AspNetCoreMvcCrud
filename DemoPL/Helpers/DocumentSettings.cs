using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace DemoPL.Helpers
{
    public static class DocumentSettings
    {
        public static string UploadFiles(IFormFile file , string folderName)
        {
            // 1- get file path
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", folderName);

            // 2- get filr name and make it unique
            string fileName = $"{Guid.NewGuid()}{file.FileName}";

            // 3- get file path

            string filePath = Path.Combine(folderPath, fileName);
            // 4- save file as streams (data per time)
            using var fs = new FileStream(filePath,FileMode.Create);
            file.CopyTo(fs); 

            return fileName;
        }

        public static void DeleteFile(string fileName, string folderName)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", folderName, fileName);
            if (File.Exists(filePath))
                File.Delete(filePath);
        }
    }
}
