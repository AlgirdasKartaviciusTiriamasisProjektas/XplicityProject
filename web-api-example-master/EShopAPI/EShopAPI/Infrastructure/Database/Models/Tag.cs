using System;
using System.Collections.Generic;

namespace EShopAPI.Infrastructure.Database.Models
{
    public class Tag: BaseEntity
    {
        public string Name { get; set; }
        public string OtherInformation { get; set; }
        public string Demo { get; set; }
        public DateTime Created { get; set; }

        public ICollection<ProductTag> ProductTags { get; set; }
    }
}
