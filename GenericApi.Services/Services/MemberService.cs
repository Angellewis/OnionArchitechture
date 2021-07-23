using AutoMapper;
using FluentValidation;
using GenericApi.Bl.Dto;
using GenericApi.Model.Entities;
using GenericApi.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApi.Services.Services
{ 
    public interface IUserService : IBaseService<User, UserDto>  {}
    public class MemberService : BaseService<User, UserDto>, IUserService
    {
        public MemberService(
            IUserRepository repository, 
            IMapper mapper, 
            IValidator<UserDto> validator) : base(repository, mapper, validator)
        {
        }
    }
}
