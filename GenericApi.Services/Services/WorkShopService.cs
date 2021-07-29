using AutoMapper;
using FluentValidation;
using GenericApi.Bl.Dto;
using GenericApi.Model.Entities;
using GenericApi.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Services.Services
{
    public interface IWorkShopService : IBaseService<WorkShop, WorkShopDto>
    {

    }
    public class WorkShopService : BaseService<WorkShop, WorkShopDto>, IWorkShopService
    {
        public WorkShopService(
            WorkShopRepository repository,
            IMapper mapper,
            IValidator<WorkShopDto> validator) : base(repository, mapper, validator)
        {

        }
    }
}
