using System.IO;

namespace TestNinja.Mocking.Refactored
{
    public class FileReader : IFileReader
    {
        public string ReadFromFile(string path)
        {
            using var reader = new StreamReader(path);

            return reader.ReadToEnd();
            
        }
    }

    public interface IFileReader
    {
        string ReadFromFile(string path); 
        
    }
}