using System.IO;
using System.Xml;

namespace MovieMakerExporter
{
    public class ExportHandler : IExportHandler
    {
        private readonly XmlDocument _movieDocument;
        private readonly IFileWrapper _fileWrapper;

        public ExportHandler(
            XmlDocument movieDocument, 
            IFileWrapper fileWrapper)
        {
            _movieDocument = movieDocument;
            _fileWrapper = fileWrapper;
        }

        public void Execute(string fromFile)
        {
            _movieDocument.Load(fromFile);

            var project = _movieDocument.GetElementsByTagName("Project");
            var attributeCollection = project[0].Attributes;
            var projectName = string.Empty;
            if (attributeCollection != null)
            {
                projectName = attributeCollection["name"].Value;
                CreateFolder(projectName);
            }

            var mediaItems = _movieDocument.GetElementsByTagName("MediaItem");
            for (int i = 0; i < mediaItems.Count; i++)
            {
                var xmlAttributeCollection = mediaItems[i].Attributes;

                if (xmlAttributeCollection != null)
                {
                    var mediaPath = xmlAttributeCollection["fileName"].Value;
                    var fileName = Path.GetFileName(mediaPath);
                    var toMediaPath = string.Format(projectName + "\\" + fileName);
                    File.Copy(mediaPath, toMediaPath);
                    xmlAttributeCollection["fileName"].Value = toMediaPath;
                }
            }
        }

        private void CreateFolder(string folderName)
        {
            Directory.CreateDirectory(folderName);
        }
    }

    public interface IExportHandler
    {
        void Execute(string fromFilePath);
    }
}
