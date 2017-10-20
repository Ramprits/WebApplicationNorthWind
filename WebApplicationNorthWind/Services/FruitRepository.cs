using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationNorthWind.SampleDb.SampleEntities;

namespace WebApplicationNorthWind.Services
{
    public class FruitRepository : IFruitRepository
    {

        private readonly SampledbContext _context;
        public FruitRepository(SampledbContext context)
        {
            _context = context;
        }
        public void AddFruits(Fruits fruit)
        {
            throw new NotImplementedException();
        }

        public void DeleteFruits(Fruits fruitId)
        {
            throw new NotImplementedException();
        }

        public bool FruitsExists(Guid fruitId)
        {
            throw new NotImplementedException();
        }

        public Fruits GetFruits(Guid fruitId)
        {
            return _context.Fruits.FirstOrDefault(x => x.FruitId == fruitId);
        }

        public IEnumerable<Fruits> GetFruits()
        {
            return _context.Fruits.OrderByDescending(x => x.Name).ToList();
        }

        public void UpdateFruits(Fruits fruitId)
        {
            throw new NotImplementedException();
        }
    }
}
