using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Inkopslista.Dtos;
using Inkopslista.Models;

namespace Inkopslista.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();

            Mapper.CreateMap<Food, FoodDto>();
            Mapper.CreateMap<Product, ProductDto>();
            Mapper.CreateMap<Shoppinglist, ShoppinglistDto>();

            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<FoodDto, Food>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<ProductDto, Product>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<ShoppinglistDto, Shoppinglist>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}