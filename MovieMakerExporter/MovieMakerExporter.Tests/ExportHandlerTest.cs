using System;
using System.IO;
using System.Xml;
using FakeItEasy;
using FakeItEasy.ExtensionSyntax.Full;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MovieMakerExporter.Tests
{
    [TestClass]
    public class ExportHandlerTest
    {
        private IExportHandler _sut;
        private readonly XmlDocument _fakeXmlDocument = A.Fake<XmlDocument>();
        private readonly IFileWrapper _fileWrapper = A.Fake<IFileWrapper>();

        [TestInitialize]
        public void SetUp()
        {
            _sut = new ExportHandler(
                _fakeXmlDocument, 
                _fileWrapper);
        }

        [TestMethod]
        public void ExecutseShouldRunWithNoErrors()
        {
            _sut.Execute(string.Empty);
        }

        private void SetupXmlDocument(string xmlFilePath)
        {
            _fakeXmlDocument.CallsTo(f => f.Load(xmlFilePath)).MustHaveHappened(Repeated.Exactly.Once);
        }
    }
}
