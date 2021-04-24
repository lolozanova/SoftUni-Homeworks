using AutoMapper;
using ProductShop.DataTransferedObject.Input;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {

            CreateMap<UserInputModel, User>();

            CreateMap<ProductInputModel, Product>();

            CreateMap<CategoryInputModel, Category>();

            this.CreateMap<CategoryProductInputModel, CategoryProduct>();

        }
    }
}
