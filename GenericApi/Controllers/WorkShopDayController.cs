using GenericApi.Controllers;
using GenericApi.Model.Entities;
using GenericApi.Bl.Dto;
using GenericApi.Services.Services;

namespace GenericApi.Controllers
{
    public class WorkShopDayController : BaseController<WorkShopDay, WorkShopDayDto>
    {
        public WorkShopDayController(IWorkShopDayService service) : base(service)
        {

        }
    }
}
