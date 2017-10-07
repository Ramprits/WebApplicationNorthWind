using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationNorthWind.Northwind;
using WebApplicationNorthWind.NorthwindModel.Order;

namespace WebApplicationNorthWind.Infrastructure
{
    public class OrderMapper : Profile
    {
        public OrderMapper()
        {
            CreateMap<Orders, OrderViewModel>().ReverseMap();
        }
    }
}
