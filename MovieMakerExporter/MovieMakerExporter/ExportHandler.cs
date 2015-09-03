using System.IO;
using System.Xml;

namespace MovieMakerExporter
{
    public class ExportHandler : IExportHandler
    {
        private readonly IProjectOperations _projectOperations;

        public ExportHandler(
            IProjectOperations projectOperations)
        {
            _projectOperations = projectOperations;
        }

        public void Execute(string fromProjectPath)
        {
            var newProjectPath = _projectOperations.PrepareDestinationFolder(fromProjectPath);

            _projectOperations.MoveMediaFiles(newProjectPath);
        }
    }

    public interface IExportHandler
    {
        void Execute(string fromProjectPath);
    }
}
