using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.Client.Test.ServicesTest
{
    [TestFixture]
    class DocuentLibraryTest
    {
        [Test]
        public void GetFileNameFromPath_CheckCorrectFileName_GetCorrectFileName()
        {

        //Arrange
        var file = new DocumentLibrary();
        var stubDocumentLibrary = new StubDocumentLibraryTest();
        var stubFilePath = stubDocumentLibrary.GetFileNameFromPath(stubDocumentLibrary.FilePath);

        //Act
        string result = file.GetFileNameFromPath(stubDocumentLibrary.FilePath);

        //Assert
        Assert.That(result, Is.EqualTo(stubFilePath));
        }

        [Test]
        public void CreateDmsSaveFileName_CheckSwitchCaseFunctionPdf_GetCorrectFileName()
        {
            //Arrange
            var id = "123456";
            var file = new DocumentLibrary(id);
            var stubDocumentLibrary = new StubDocumentLibraryTest(id);
            var stubFilePath = stubDocumentLibrary.CreateDmsSaveFileName(stubDocumentLibrary.FilePath, ".pdf");

            //Act
            string result = file.CreateDmsSaveFileName(stubDocumentLibrary.FilePath, ".pdf");

            //Assert
            Assert.That(result, Is.EqualTo(stubFilePath));
        }


        [Test]
        public void CreateDmsSaveFileName_CheckSwitchCaseFunctionXml_GetCorrectFileName()
        {
            //Arrange
            var id = "123456";
            var file = new DocumentLibrary(id);
            var stubDocumentLibrary = new StubDocumentLibraryTest(id);
            var stubFilePath = stubDocumentLibrary.CreateDmsSaveFileName(stubDocumentLibrary.FilePath, ".xml");

            //Act
            string result = file.CreateDmsSaveFileName(stubDocumentLibrary.FilePath, ".xml");

            //Assert
            Assert.That(result, Is.EqualTo(stubFilePath));
        }
    }
}
