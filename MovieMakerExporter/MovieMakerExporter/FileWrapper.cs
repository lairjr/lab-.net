using System.IO;

namespace MovieMakerExporter
{
    public interface IFileWrapper
    {
        void Copy(string sourceFileName, string destinationFileName);
        DirectoryInfo CreateDirectory(string path);
        bool DirExists(string folderPath);
        bool Exists(string path);
        string GetFileName(string filePath);
        string GetFolderPath(string filePath);
    }

    public class FileWrapper : IFileWrapper
    {
        public DirectoryInfo CreateDirectory(string folderName)
        {
            return Directory.CreateDirectory(folderName);
        }

        public void Copy(string sourceFileName, string destinationFileName)
        {
            File.Copy(sourceFileName, destinationFileName);
        }

        public bool DirExists(string folderPath)
        {
            return Directory.Exists(folderPath);
        }

        public bool Exists(string path)
        {
            return File.Exists(path);
        }

        public string GetFileName(string filePath)
        {
            return Path.GetFileName(filePath);
        }

        public string GetFolderPath(string filePath)
        {
            return Path.GetDirectoryName(filePath);
        }
    }
}
