using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationNorthWind.Northwind;

namespace WebApplicationNorthWind.NorthwindModel.Employee
{
    public class EmployeeTerritorieViewModel
    {
        public int EmployeeId { get; set; }
        public string TerritoryId { get; set; }
    }
}
