using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using OnlineMarker.Api.Controllers;
using OnlineMarker.Api.Repository.Interfaces;
using OnlineMarker.Api.Settings;
using OnlineMarker.Shared.Request;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
namespace OnlineMarker.Shared.Test.Controllers
{
    [TestFixture]
    public class ServicesControllerTest
    {
        
        Mock<IOnlineMarkerService>? _mockService;
        Mock<IFileService>? _mockFileService;
        Mock<IOptions<AppSettings>>? _mockAppSettings;
         Mock<IValidator<GetCandidateScriptsRequest>> _validatorMock;
        ServicesController? _controller;

        [OneTimeSetUp]
        public void SetUp()
        {
            string folderPath = @"C:\Test";

            _mockService = new Mock<IOnlineMarkerService>();
            _mockFileService = new Mock<IFileService>();
            _mockAppSettings = new Mock<IOptions<AppSettings>>();
            _validatorMock = new Mock<IValidator<GetCandidateScriptsRequest>>();
          
            _mockAppSettings
                .Setup ( x => x.Value)
                .Returns(new AppSettings {  DataPath = "File_Location", ExamYear="2022"});

            _mockFileService
               .Setup(x => x.FileExists(It.IsAny<string>()))
               .Returns(true);

            _mockFileService.
              Setup(x => x.GetDirectoryInfo(It.IsAny<string>()))
              .Returns(new DirectoryInfo(folderPath));

            _mockService.Setup(x => x.GetPaperQuesInfos(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(new List<PaperQuesInfo>() { new PaperQuesInfo { }, new PaperQuesInfo { } }));

            _controller = new ServicesController(_mockService.Object, _mockFileService.Object, _mockAppSettings.Object, _validatorMock.Object);

        }

        [Test]
        public async Task Get_Papers_Quest_Info_Test()
        {
            var items = await _controller.GetPaperQuestionInfo("examptype", "papercode");
            Assert.IsInstanceOf<OkObjectResult>(items);
            Assert.IsInstanceOf<List<PaperQuesInfo>>((List<PaperQuesInfo>)((OkObjectResult)items).Value);
            Assert.AreEqual(((List<PaperQuesInfo>)((OkObjectResult)items).Value).Count, 2);
        }

        [Test]
        public async Task Get_Papers_Quest_Info_Test_Bad_Request()
        {
            var items = await _controller.GetPaperQuestionInfo("", "");
            Assert.IsInstanceOf<BadRequestObjectResult>(items);
        }

        [Test]
        public async Task Get_Candidate_Scripts_Bad_Request()
        {
            _validatorMock.Setup(x => x.Validate(It.IsAny<GetCandidateScriptsRequest>()))
             .Returns(new ValidationResult(
                 new List<ValidationFailure>() { new ValidationFailure("examtype", "missing") }));

            var items = await _controller.GetCandidateScripts(new GetCandidateScriptsRequest { seedmaster = true, examtype = "", indexnumber = "indexnumber", markerid = "marker", papercode = "02" }); ;
            Assert.IsInstanceOf<BadRequestObjectResult>(items);
          

        }
        [Test]
        public async Task Get_Candidate_Scripts()
        {

            _validatorMock.Setup(x => x.Validate(It.IsAny<GetCandidateScriptsRequest>()))
           .Returns(new ValidationResult(
               new List<ValidationFailure>() ));

            _mockService
                .Setup(x => x.GetSeedScript(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(0);

            _mockService
                 .Setup(x => x.GetScriptsInfo_Seed(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                 .Returns(new ScriptInfo { });

            _mockService
               .Setup(x => x.GetDepletedSeed( It.IsAny<string>(), It.IsAny<string>()))
               .Returns(0);

            _mockService
             .Setup(x => x.GetSeedsMarked_Examiner(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
             .Returns(0);
            _mockService
               .Setup(x => x.GetSeededMarked_ByExaminer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
               .Returns(0);

            _mockService
             .Setup(x => x.GetSeededScript(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
             .Returns(true);

            _mockService
          .Setup(x => x.GetSeededScriptsInfo(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
          .Returns(new ScriptInfo { Markid = 0 });

            _mockService
         .Setup(x => x.GetSeededScriptsInfo(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
         .Returns(new ScriptInfo { Markid = 0 });


            _mockService
           .Setup(x => x.GetVetScriptInfo_ExaminerNo(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()))
           .Returns(new ScriptInfo { Markid = 0 });

            _mockService
            .Setup(x => x.UpdateScript_Review(It.IsAny<int>(), It.IsAny<int>()))
            .Returns(true);


            _mockService
            .Setup(x => x.GetScriptInfo_Review(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
            .Returns(new ScriptInfo { });

            var items = await _controller.GetCandidateScripts(new GetCandidateScriptsRequest { seedmaster = true, examtype = "test", indexnumber = "indexnumber", markerid = "marker", papercode = "02" }); ;
            Assert.IsInstanceOf<OkObjectResult>(items);
            Assert.IsInstanceOf<List<SFilesInfo>>((List<SFilesInfo>)((OkObjectResult)items).Value);
            


        }

    }
}
