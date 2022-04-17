using NUnit.Framework;
using OnlineMarker.Api.Validations;
using OnlineMarker.Shared.Request;

namespace OnlineMarker.Shared.Test.Validations
{
    [TestFixture]
    public class SaveMarkedScriptsRequestValidatorTest
    {
        [Test]
        public void SaveMarkedScriptsRequestValidation_Test_Failed()
        {
            var validator = new SaveMarkedScriptsRequestValidator();
            var result = validator.Validate(new SaveMarkedScriptsRequest { });

            Assert.IsFalse(result.IsValid);

        }

        [Test]
        public void SaveMarkedScriptsRequestValidation_Test_Passed()
        {
            var validator = new SaveMarkedScriptsRequestValidator();

            var result = validator.Validate(new SaveMarkedScriptsRequest { markerid = "markerid", vetteeid = "vettee", examtype = "test", scriptno = "scriptno", indexno="indexnumber", papercode="02", quesno= "1" });

            Assert.IsTrue(result.IsValid);

        }
    }
}
