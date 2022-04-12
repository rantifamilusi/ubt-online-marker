using Moq;
using NUnit.Framework;
using OnlineMarker.Api.Repository.Generic;
using OnlineMarker.Api.Repository.Interfaces;
using System.Collections.Generic;
using System.IO;

namespace OnlineMarker.Shared.Test.Repository.Generic
{
    [TestFixture]
    public class UtilityTest
    {
        Mock<IFileService>? _mockFileService;

        [OneTimeSetUp]
        public void SetUp()
        {
            _mockFileService = new Mock<IFileService>();
        }

        [Test]
        [TestCase(2)]
        [TestCase(100)]
        [TestCase(-99)]
        public void GetNoScriptInfo_Test(int errorid)
        {
            var result = Utility.GetNoScriptInfo(errorid);
            Assert.IsNotNull(result);
            Assert.AreEqual (result.Count, 1);
            Assert.AreEqual(result[0].Markid, errorid);
        }

        [Test]
        [TestCase(2,50)]
        [TestCase(5,30)]
     
        public void GetNextValueTest(int seedinterval, int totalmarked)
        {
            var result = Utility.GetNextSeedValue(seedinterval, totalmarked);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<int>(result);
            Assert.That(result, Is.GreaterThan(totalmarked));

        }

        [Test]
        [TestCase(0, 30)]
        public void GetNextValueTest_With_0_Seed_Interval(int seedinterval, int totalmarked)
        {
            var result = Utility.GetNextSeedValue(seedinterval, totalmarked);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<int>(result);
            Assert.AreEqual(result, -1);

        }

        [Test]
       
        public void GetSeedScriptFiles_Not_Empty_Seededd_Test()
        {
            string folderPath = @"C:\Test";
            _mockFileService
                .Setup(x => x.FileExists(It.IsAny<string>()))
                .Returns(true);

            
            _mockFileService.
                Setup(x => x.GetDirectoryInfo(It.IsAny<string>()))
                .Returns(new DirectoryInfo(folderPath));

            var list = new List<FileInfo>();
            _mockFileService.
                Setup(x => x.GetFiles(It.IsAny<DirectoryInfo>(), It.IsAny<string>(), It.IsAny<SearchOption>()))
                .Returns(list.ToArray());

           

            var result = Utility.GetSeedScriptFiles("papercode", "scriptno",new DirectoryInfo(folderPath), new DirectoryInfo (folderPath),"2022");
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<bool>(result);
            Assert.AreEqual(result,true);

        }

        [Test]

        public void GetSeedScriptFiles_Empty_Seededd_Test()
        {
            string folderPath = @"C:\Test";
          
            _mockFileService
                .Setup(x => x.FileExists(It.IsAny<string>()))
                .Returns(true);


            _mockFileService.
                Setup(x => x.GetDirectoryInfo(It.IsAny<string>()))
                .Returns(new DirectoryInfo(folderPath));

            var list = new List<FileInfo>() 
            { 
                new FileInfo("a.txt"),
                new FileInfo("b.txt"),
            };
            _mockFileService.
                Setup(x => x.GetFiles(It.IsAny<DirectoryInfo>(), It.IsAny<string>(), It.IsAny<SearchOption>()))
                .Returns(list.ToArray());

            _mockFileService.
                Setup(x => x.CopyTo(It.IsAny<FileInfo>(), It.IsAny<string>(), It.IsAny<bool>()))
                .Returns(new FileInfo("a.txt"));



            var result = Utility.GetSeedScriptFiles("papercode", "scriptno", new DirectoryInfo(folderPath), new DirectoryInfo(folderPath), "2022");
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<bool>(result);
            Assert.AreEqual(result, true);

  
        }

        [Test]

        public void GeBackUpScriptFules_Test()
        {
            string folderPath = @"C:\Test";

            _mockFileService
                .Setup(x => x.FileExists(It.IsAny<string>()))
                .Returns(true);


            _mockFileService.
                Setup(x => x.GetDirectoryInfo(It.IsAny<string>()))
                .Returns(new DirectoryInfo(folderPath));

            var list = new List<FileInfo>()
            {
                new FileInfo("a.txt"),
                new FileInfo("b.txt"),
            };
            _mockFileService.
                Setup(x => x.GetFiles(It.IsAny<DirectoryInfo>(), It.IsAny<string>(), It.IsAny<SearchOption>()))
                .Returns(list.ToArray());

            _mockFileService.
                Setup(x => x.CopyTo(It.IsAny<FileInfo>(), It.IsAny<string>(), It.IsAny<bool>()))
                .Returns(new FileInfo("a.txt"));



            var result = Utility.BackupScriptFiles("papercode", "scriptno", new DirectoryInfo(folderPath), "2022");
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<bool>(result);
            Assert.AreEqual(result, true);


        }

    }
}
