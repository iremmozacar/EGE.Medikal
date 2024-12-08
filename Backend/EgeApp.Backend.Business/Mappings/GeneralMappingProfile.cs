using AutoMapper;
using EgeApp.Backend.Entity.Concrete;
using EgeApp.Backend.Models;
using EgeApp.Backend.Shared.Dtos.CartDtos;
using EgeApp.Backend.Shared.Dtos.CategoryDtos;
using EgeApp.Backend.Shared.Dtos.OrderDtos;
using EgeApp.Backend.Shared.Dtos.ProductDtos;

namespace EgeApp.Backend.Business.Mappings
{
    public class GeneralMappingProfile : Profile
    {
        public GeneralMappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryCreateDto>().ReverseMap();
            CreateMap<Category, CategoryUpdateDto>().ReverseMap();

            CreateMap<Product, ProductDto>()
         .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category)); 
            CreateMap<Category, CategoryDto>();
            CreateMap<Product, ProductCreateDto>().ReverseMap();
            CreateMap<Product, ProductUpdateDto>().ReverseMap();

            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemCreateDto>().ReverseMap();


            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, OrderCreateDto>().ReverseMap();
            CreateMap<Order, InOrderItemOrderDto>().ReverseMap();

            CreateMap<Cart, CartDto>()
                    .ForMember(dest => dest.CartItems, opt => opt.MapFrom(src => src.CartItems)) // CartItems ilişkisini belirtiyoruz
                    .ReverseMap();

            CreateMap<CartItem, CartItemDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name)) // Ürün adını eşleştir
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Product.ImageUrl)) // Görsel URL eşleştir
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product.Price)) // Fiyatı eşleştir
                .ReverseMap();

        }
    }
}
