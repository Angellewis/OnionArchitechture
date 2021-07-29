using FluentValidation;
using GenericApi.Bl.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Bl.Validations
{
    public class WorkShopValidator : AbstractValidator<WorkShopDto>
    {
		public WorkShopValidator()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("The Name is required");
		}
	}
}
