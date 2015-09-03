using System;
using System.IO;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MovieMakerExporter.Tests
{
    [TestClass]
    public class ExportHandlerTest
    {
        private IExportHandler _sut;
        private readonly Mock<XmlDocument> _fakeXmlDocument = new Mock<XmlDocument>();
        private readonly Mock<IFileWrapper> _fileWrapper = new Mock<IFileWrapper>();
    }
}
