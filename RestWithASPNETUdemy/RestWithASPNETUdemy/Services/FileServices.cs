using RestWithASPNETUdemy.Services.Interfaces;
using System.IO;

namespace RestWithASPNETUdemy.Services
{
    public class FileService : IFileService
    {
        public byte[] GetPdfFile()
        {
            string path = Directory.GetCurrentDirectory();
            var fullpath = path + "\\Other\\fatura-Net-10-04-2019.pdf";
            return File.ReadAllBytes(fullpath);
        }
    }
}
