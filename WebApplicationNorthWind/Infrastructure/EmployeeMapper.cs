using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationNorthWind.Northwind;
using WebApplicationNorthWind.NorthwindModel.Employee;

namespace WebApplicationNorthWind.Infrastructure
{
    public class EmployeeMapper : Profile
    {
        public EmployeeMapper()
        {
            CreateMap<Employees, EmployeeViewModel>().ReverseMap();
        }
    }
}
