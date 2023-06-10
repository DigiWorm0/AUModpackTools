using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AUModpackTools.Utils
{
    /// <summary>
    /// Reads files from the game's assembly directory
    /// </summary>
    public static class FileReader
    {
        /// <summary>
        /// Gets the directory of a file in the game's assembly directory
        /// </summary>
        /// <param name="fileName">The name of the file to get the directory of</param>
        /// <returns>The directory of the file</returns>
        public static string GetDirectory(string fileName)
        {
            string gameDir = Assembly.GetAssembly(typeof(AUModpackTools))?.Location ?? "/";
            string filePath = Path.Combine(Path.GetDirectoryName(gameDir) ?? "/", fileName);
            return filePath;
        }

        /// <summary>
        /// Reads a file from the game's assembly directory
        /// </summary>
        /// <param name="fileName">The name of the file to read</param>
        /// <returns>An array of bytes containing the file's data</returns>
        /// <exception cref="FileNotFoundException">Thrown if the file does not exist</exception>
        public static byte[] ReadFileBytes(string fileName)
        {
            string filePath = GetDirectory(fileName);
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Failed to find file at {filePath}");
            byte[] fileData = File.ReadAllBytes(filePath);
            return fileData;
        }

        /// <summary>
        /// Reads a file from the game's assembly directory
        /// </summary>
        /// <param name="fileName">The name of the file to read</param>
        /// <returns>A string containing the file's data</returns>
        /// <exception cref="FileNotFoundException">Thrown if the file does not exist</exception>
        public static string ReadFileString(string fileName)
        {
            string filePath = GetDirectory(fileName);
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Failed to find file at {filePath}");
            string fileData = File.ReadAllText(filePath);
            return fileData;
        }
    }
}
