using GenericApi.Controllers;
using GenericApi.Model.Entities;
using GenericApi.Bl.Dto;
using GenericApi.Services.Services;

namespace GenericApi.Controllers
{
    public class WorkShopController : BaseController<WorkShop, WorkShopDto>
    {
        public WorkShopController(IWorkShopService service) : base(service)
        {

        }
    }
}
