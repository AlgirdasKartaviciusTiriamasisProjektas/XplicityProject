using System.Linq;
using AutoMapper;
using EShopAPI.Contracts.Products;
using EShopAPI.Contracts.Tags;
using EShopAPI.Infrastructure.Database.Models;

namespace EShopAPI.Configurations
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration() : this("AcademyDemo")
        {

        }

        protected AutoMapperConfiguration(string name) : base(name)
        {
            CreateMap<NewProductDto, Product>(MemberList.None);
            CreateMap<ProductDto, Product>(MemberList.None);
            CreateMap<Product, ProductDto>(MemberList.Destination)
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.ProductTag.Select(x => x.Tag)));

            CreateMap<Tag, TagDto>(MemberList.Destination);
            CreateMap<TagDto, Tag>(MemberList.None);
            CreateMap<NewTagDto, Tag>(MemberList.None);
        }
    }
}