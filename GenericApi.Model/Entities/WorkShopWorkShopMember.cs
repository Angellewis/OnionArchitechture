using GenericApi.Core.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Model.Entities
{
    public class WorkShopWorkShopMember : BaseEntity
    {
        public int WorkShopId { get; set; }
        public int WorkShopMemberId { get; set; }
        public virtual WorkShop WorkShop { get; set; }
        public virtual WorkShopMember WorkShopMember { get; set; }
    }
}
