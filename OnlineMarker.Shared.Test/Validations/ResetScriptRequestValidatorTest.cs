using NUnit.Framework;
using OnlineMarker.Api.Validations;
using OnlineMarker.Shared.Request;

namespace OnlineMarker.Shared.Test.Validations
{
    [TestFixture]
    public class ResetScriptRequestValidatorTest
    {
        [Test]
        public void ResetScriptRequestValidation_Test_Failed()
        {
            var validator = new ResetScriptRequestValidator();
            var result = validator.Validate(new ResetScriptRequest   { });

            Assert.IsFalse(result.IsValid);

        }

        [Test]
        public void SubmitMarkedScriptRequestValidation_Test_Passed()
        {
            var validator = new ResetScriptRequestValidator();

            var result = validator.Validate(new ResetScriptRequest { markerid = "markerid", scriptid = "scriptno", papercode="02"});

            Assert.IsTrue(result.IsValid);

        }
    }
}
