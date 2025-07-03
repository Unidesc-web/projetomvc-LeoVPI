using System.Collections.Generic;
using System.Linq;
using AluguelCarros.Models;

namespace AluguelCarros.Repositories
{
    public class CarroRepository : ICarroRepository
    {
        private readonly AppDbContext _context;

        public CarroRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Carro> GetAll() => _context.Carros.ToList();

        public Carro GetById(int id) => _context.Carros.Find(id);

        public void Add(Carro carro) => _context.Carros.Add(carro);

        public void Update(Carro carro) => _context.Carros.Update(carro);

        public void Delete(int id)
        {
            var carro = GetById(id);
            if (carro != null)
                _context.Carros.Remove(carro);
        }

        public void Save() => _context.SaveChanges();
    }
}
