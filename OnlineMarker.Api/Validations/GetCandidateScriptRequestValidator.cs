using FluentValidation;
using OnlineMarker.Shared.Request;

namespace OnlineMarker.Api.Validations
{
    public class GetCandidateScriptRequestValidator : AbstractValidator<GetCandidateScriptsRequest>
    {
        public GetCandidateScriptRequestValidator()
        {
            RuleFor(x => x.examtype).NotNull();
            RuleFor(x => x.indexnumber).NotNull();
            RuleFor(x => x.markerid).NotNull();
            RuleFor(x => x.papercode).NotNull();
        }
    }
}
