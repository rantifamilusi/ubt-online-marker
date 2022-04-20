using NUnit.Framework;
using OnlineMarker.Api.Validations;
using OnlineMarker.Shared.Request;

namespace OnlineMarker.Shared.Test.Validations
{
    [TestFixture]
    public class SubmitMarkedScriptRequestValidatorTest
    {
        [Test]
        public void SubmitMarkedScriptRequestValidation_Test_Failed()
        {
            var validator = new SubmitMarkedScriptRequestValidator();
            var result = validator.Validate(new  SubmitMarkedScriptRequest { });

            Assert.IsFalse(result.IsValid);

        }

        [Test]
        public void SubmitMarkedScriptRequestValidation_Test_Passed()
        {
            var validator = new SubmitMarkedScriptRequestValidator();

            var result = validator.Validate(new SubmitMarkedScriptRequest { markerid = "markerid", vetteeid = "vettee", examtype = "test", scriptno = "scriptno", papercode="02"});

            Assert.IsTrue(result.IsValid);

        }
    }
}
