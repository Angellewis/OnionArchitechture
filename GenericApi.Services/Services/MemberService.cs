using AutoMapper;
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
    public interface IMemberService : IBaseService<Member, MemberDto>  {}
    public class MemberService : BaseService<Member, MemberDto>, IMemberService
    {
        public MemberService(IMemberRepository repository, IMapper mapper) : base(repository,mapper)
        {
        }
    }
}
