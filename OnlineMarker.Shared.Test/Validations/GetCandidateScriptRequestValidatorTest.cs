using NUnit.Framework;
using OnlineMarker.Api.Validations;
using OnlineMarker.Shared.Request;

namespace OnlineMarker.Shared.Test.Validations
{
    [TestFixture]
    public class GetCandidateScriptRequestValidatorTest
    {
        [Test]
        public void GetCandidateScriptRequestValidation_Test_Failed()
        {
            var validator = new GetCandidateScriptRequestValidator();
            var result = validator.Validate(new GetCandidateScriptsRequest { });

            Assert.IsFalse(result.IsValid);

        }

        [Test]
        public void GetCandidateScriptRequestValidation_Test_Passed()
        {
            var validator = new GetCandidateScriptRequestValidator();

            var result = validator.Validate(new GetCandidateScriptsRequest { examtype="test", indexnumber="indexnumber", markerid="marker", papercode="02"});

            Assert.IsTrue(result.IsValid);

        }
    }
}
