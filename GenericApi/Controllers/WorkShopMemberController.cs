using GenericApi.Controllers;
using GenericApi.Model.Entities;
using GenericApi.Bl.Dto;
using GenericApi.Services.Services;

namespace GenericApi.Controllers
{
    public class WorkShopMemberController : BaseController<WorkShopMember, WorkShopMemberDto>
    {
        public WorkShopMemberController(IWorkShopMemberService service) : base(service)
        {

        }
    }
}
