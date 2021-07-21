using FluentValidation;
using FluentValidation.AspNetCore;
using GenericApi.Bl.Validations;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericApi.Config
{
    public static class FluentValidationConfig
    {
        public static IMvcBuilder AddAppFluentValidation(this IMvcBuilder builder)
        {
            builder.AddFluentValidation(x =>
            {
                x.AutomaticValidationEnabled = false;
                x.RegisterValidatorsFromAssemblyContaining<DocumentValidator>();
            });
            return builder;
        }
    }
}
