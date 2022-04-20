using FluentValidation;
using OnlineMarker.Shared.Request;

namespace OnlineMarker.Api.Validations
{
    public class ResetScriptRequestValidator : AbstractValidator<ResetScriptRequest>
    {
        public ResetScriptRequestValidator()
        {
            RuleFor(x => x.markerid).NotNull();

            RuleFor(x => x.scriptid).NotNull();
            RuleFor(x => x.papercode).NotNull();

     

        }
    }
}
