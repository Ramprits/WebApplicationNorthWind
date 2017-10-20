using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationNorthWind.SampleDb.SampleEntities;

namespace WebApplicationNorthWind.Services
{
    public interface IFruitRepository
    {
        Fruits GetFruits(Guid fruitId);
        IEnumerable<Fruits> GetFruits();
        void AddFruits(Fruits fruit);
        void DeleteFruits(Fruits fruitId);
        void UpdateFruits(Fruits fruitId);
        bool FruitsExists(Guid fruitId);
    }
}
