using FluentValidation;
using OnlineMarker.Shared.Request;

namespace OnlineMarker.Api.Validations
{
    public class SubmitMarkedScriptRequestValidator : AbstractValidator<SubmitMarkedScriptRequest>
    {
        public SubmitMarkedScriptRequestValidator()
        {
            RuleFor(x => x.examtype).NotNull();
           
            RuleFor(x => x.markerid).NotNull();
            RuleFor(x => x.papercode).NotNull();
        
            RuleFor(x => x.scriptno).NotNull();
            RuleFor(x => x.vetteeid).NotNull();

        }
    }
}
