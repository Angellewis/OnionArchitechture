using GenericApi.Core.BaseModel;
using GenericApi.Core.Enums;
using GenericApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Bl.Dto
{
    public class WorkShopMemberDto : BaseEntityDto
    {
        public WorkShopMemberRole Role { get; set; }
        public int WorkShopId { get; set; }
        public virtual WorkShop WorkShop { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
