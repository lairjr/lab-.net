using System.IO;
using System.Xml;

namespace MovieMakerExporter
{
    public interface IProjectOperations
    {
        void MoveMediaFiles(string newProjectPath);
        string PrepareDestinationFolder(string fromProjectPath);
    }

    public class ProjectOperations : IProjectOperations
    {
        private readonly XmlDocument _movieDocument;
        private readonly IMovieMakerXmlHandler _movieMakerXmlHandler;
        private readonly IFileWrapper _fileWrapper;

        public ProjectOperations(
            XmlDocument movieDocument,
            IMovieMakerXmlHandler movieMakerXmlHandler,
            IFileWrapper fileWrapper)
        {
            _movieDocument = movieDocument;
            _movieMakerXmlHandler = movieMakerXmlHandler;
            _fileWrapper = fileWrapper;
        }

        private string GetDestinationFilePath(string projectPath, string sourceFilePath)
        {
            var destinationFolderPath = _fileWrapper.GetFolderPath(projectPath);
            var fileName = _fileWrapper.GetFileName(sourceFilePath);

            return string.Format("{0}\\{1}", destinationFolderPath, fileName);
        }

        private string GetDestinationDirPath(string projectName, string sourceFilePath)
        {
            var folderPath = _fileWrapper.GetFolderPath(sourceFilePath);
            var destinationFolderPath = string.Format("{0}\\{1}", folderPath, projectName);

            int modifier = 1;
            while (_fileWrapper.DirExists(destinationFolderPath))
            {
                destinationFolderPath = string.Format("{0}\\{1}[{2}]", folderPath, projectName, modifier);
                modifier++;
            }

            return destinationFolderPath;
        }

        public void MoveMediaFiles(string newProjectPath)
        {
            _movieDocument.Load(newProjectPath);

            var mediaItems = _movieMakerXmlHandler.GetMediaItems(_movieDocument);

            for (var i = 0; i < mediaItems.Count; i++)
            {
                var sourceFilePath = _movieMakerXmlHandler.GetFilePath(mediaItems[i]);
                var destinationFilePath = GetDestinationFilePath(newProjectPath, sourceFilePath);

                _fileWrapper.Copy(sourceFilePath, destinationFilePath);

                _movieMakerXmlHandler.SetFilePath(mediaItems[i], destinationFilePath);
            }

            _movieDocument.Save(newProjectPath);
        }

        public string PrepareDestinationFolder(string fromProjectPath)
        {
            _movieDocument.Load(fromProjectPath);

            var projectName = _movieMakerXmlHandler.GetProjectName(_movieDocument);

            if (!string.IsNullOrEmpty(projectName))
            {
                var destinationDir = GetDestinationDirPath(projectName, fromProjectPath);
                _fileWrapper.CreateDirectory(destinationDir);

                var newProjectPath = destinationDir + "\\" + _fileWrapper.GetFileName(fromProjectPath);
                _fileWrapper.Copy(fromProjectPath, newProjectPath);

                return newProjectPath;
            }

            return string.Empty;
        }
    }
}