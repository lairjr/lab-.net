using System.Xml;

namespace MovieMakerExporter
{
    public interface IMovieMakerXmlHandler
    {
        string GetFilePath(XmlNode xmlNode);
        XmlNodeList GetMediaItems(XmlDocument xmlDocument);
        string GetProjectName(XmlDocument xmlDocument);
        void SetFilePath(XmlNode xmlNode, string destinationFilePath);
    }

    public class MovieMakerXmlHandler : IMovieMakerXmlHandler
    {
        public string GetFilePath(XmlNode xmlNode)
        {
            if (xmlNode.Attributes != null)
            {
                var filePath = xmlNode.Attributes["filePath"].Value;
                return filePath;
            }

            return string.Empty;
        }

        public XmlNodeList GetMediaItems(XmlDocument xmlDocument)
        {
            return xmlDocument.GetElementsByTagName("MediaItem");
        }

        public string GetProjectName(XmlDocument xmlDocument)
        {
            var projectTag = xmlDocument.DocumentElement;

            if (projectTag != null)
            {
                return projectTag.GetAttribute("name");
            }

            return string.Empty;
        }

        void IMovieMakerXmlHandler.SetFilePath(XmlNode xmlNode, string destinationFilePath)
        {
            if (xmlNode.Attributes != null)
            {
                xmlNode.Attributes["filePath"].Value = destinationFilePath;
            }
        }
    }
}
