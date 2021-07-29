using FluentValidation;
using GenericApi.Bl.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Bl.Validations
{
    public class WorkShopDayValidator : AbstractValidator<WorkShopDayDto>
    {
		public WorkShopDayValidator()
		{
			RuleFor(x => x.Day).NotNull().WithMessage("The day is required");
		}
	}
}
