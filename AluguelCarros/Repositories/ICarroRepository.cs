using System.Collections.Generic;
using AluguelCarros.Models;

namespace AluguelCarros.Repositories
{
    public interface ICarroRepository
    {
        IEnumerable<Carro> GetAll();
        Carro GetById(int id);
        void Add(Carro carro);
        void Update(Carro carro);
        void Delete(int id);
        void Save();
    }
}
