using System;

namespace EShopAPI.Contracts.Tags
{
    public class TagDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OtherInformation { get; set; }
        public DateTime Created { get; set; }
    }
}
