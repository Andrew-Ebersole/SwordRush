using System.IO;

namespace SwordRush
{
    internal class FileManager
    {
        public static string LoadFile(string path)
        {
            return File.ReadAllText(path);
        }

        public static void SaveFile(string path)
        {
            StreamWriter writer = new StreamWriter(path);
            writer.WriteLine(path);
            writer.Close();
        }
    }
}
