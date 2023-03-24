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

        /// <summary>
        /// creates a new grid based on the data read from a file
        /// </summary>
        /// <param name="path">the file path of the file being used to load the data</param>
        /// <returns>a 2D int array that contains the grid data</returns>
        public int[,] LoadGrid(string path)
        {
            StreamReader reader = new StreamReader(path);
            int[,] grid = null;




        }
    }
}
