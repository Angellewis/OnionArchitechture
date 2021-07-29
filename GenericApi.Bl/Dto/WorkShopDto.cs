using GenericApi.Core.BaseModel;
using GenericApi.Core.Enums;
using GenericApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Bl.Dto
{
    public class WorkShopDto : BaseEntityDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ContentSupport { get; set; }
        public virtual ICollection<WorkShopDay> Days { get; set; }
        public virtual ICollection<WorkShopMember> Members { get; set; }
    }
}
