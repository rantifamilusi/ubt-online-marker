using FluentValidation;
using OnlineMarker.Shared.Request;

namespace OnlineMarker.Api.Validations
{
    public class SaveMarkedScriptsRequestValidator : AbstractValidator<SaveMarkedScriptsRequest>
    {
        public SaveMarkedScriptsRequestValidator()
        {
            RuleFor(x => x.examtype).NotNull();
            RuleFor(x => x.indexno).NotNull();
            RuleFor(x => x.markerid).NotNull();
            RuleFor(x => x.papercode).NotNull();
            RuleFor(x => x.quesno).NotNull();
            RuleFor(x => x.scriptno).NotNull();
            RuleFor(x => x.vetteeid).NotNull();

        }
    }
}
