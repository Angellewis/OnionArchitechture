using FluentValidation;
using GenericApi.Bl.Dto;

namespace GenericApi.Bl.Validations
{
    public class WorkShopValidator : AbstractValidator<WorkShopDto>
    {
        public WorkShopValidator()
        {
            RuleFor(x => x.Name)
                .MinimumLength(8)
                .WithMessage("WorkShop's Name length must be at least 8 characters")
                .NotEmpty()
                .WithMessage("WorkShop's Name is required");
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("WorkShop's Description is required");
            RuleFor(x => x.StartDate)
                .NotEmpty()
                .WithMessage("WorkShop's StartDate is required");
            RuleFor(x => x.ContentSupport)
                .NotEmpty()
                .WithMessage("WorkShop's ContentSupport is required");


        }
    }
}
