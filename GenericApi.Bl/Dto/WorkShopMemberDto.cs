using GenericApi.Model.Entities;
using GenericApi.Core.BaseModel;
using GenericApi.Core.Enums;

namespace GenericApi.Bl.Dto
{
    public class WorkShopMemberDto : BaseEntityDto
    {
        public WorkShopMemberRole Role { get; set; }
        public int WorkShopId { get; set; }
        public int UserId { get; set; }
    }
}
