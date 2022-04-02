using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using OnlineMarker.Api.Controllers;
using OnlineMarker.Api.Repository.Implementation;
using OnlineMarker.Api.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OnlineMarker.Shared.Test.Controllers
{
    [TestFixture]
    public class ServicesControllerTest
    {
        
        Mock<IOnlineMarkerService>? _mockService;
        ServicesController? _controller;

        [OneTimeSetUp]
        public void SetUp()
        {
            _mockService = new Mock<IOnlineMarkerService>();
            _controller = new ServicesController(_mockService.Object);
            _mockService.Setup(x => x.GetPaperQuesInfos(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(new List<PaperQuesInfo>() { new PaperQuesInfo { }, new PaperQuesInfo { } }));

        }

        [Test]
        public async Task Get_Papers_Quest_Info_Test()
        {
            var items = await _controller.GetPaperQuestionInfo("examptype", "papercode");
            Assert.IsInstanceOf<OkObjectResult>(items);
            Assert.IsInstanceOf<List<PaperQuesInfo>>((List<PaperQuesInfo>)((OkObjectResult)items).Value);
            Assert.AreEqual(((List<PaperQuesInfo>)((OkObjectResult)items).Value).Count, 2);
        }

    }
}
