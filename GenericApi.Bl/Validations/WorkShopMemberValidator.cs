using FluentValidation;
using GenericApi.Bl.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Bl.Validations
{
    public class WorkShopMemberValidator : AbstractValidator<WorkShopMemberDto>
    {
		public WorkShopMemberValidator()
		{
			RuleFor(x => x.WorkShopId).NotNull().WithMessage("The WorkShop Id is required");
		}
	}
}
