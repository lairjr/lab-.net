using System.Reflection;
using System.Xml;

namespace MovieMakerExporter
{
    class Program
    {
        private static IExportHandler _exportHandler;

        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                RegisterIoC();

                _exportHandler.Execute(args[0]);   
            }
        }

        static void RegisterIoC()
        {
            var xmlDocument = new XmlDocument();
            var movieMakerXmlHandler = new MovieMakerXmlHandler();
            var fileWrapper = new FileWrapper();

            var projectOperations = new ProjectOperations(xmlDocument, movieMakerXmlHandler, fileWrapper);

            _exportHandler = new ExportHandler(projectOperations);
        }
    }
}
