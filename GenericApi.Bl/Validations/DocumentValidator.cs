using FluentValidation;
using GenericApi.Bl.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Bl.Validations
{
    public class DocumentValidator : AbstractValidator<DocumentDto>
    {
		public DocumentValidator()
		{
			RuleFor(x => x.FileName)
				.NotEmpty()
				.WithMessage("Document's filename is required");
		}
	}
}
