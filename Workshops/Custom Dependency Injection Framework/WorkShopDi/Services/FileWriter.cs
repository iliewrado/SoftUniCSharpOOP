using System.IO;
using WorkShopDi.Contracts;

namespace WorkShopDi.Services
{
    public class FileWriter : IFileWriter
    {
        public void Write(string text)
        {
            File.WriteAllText("LogFile.txt", text);
        }
    }
}
