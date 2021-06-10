using ApiJugueteria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiJugueteria.Repository
{
    public interface IToyRepository
    {
        void CreateToy(Toy toy);
        void UpdateToy(Toy toy);
        void DeleteToy(int toy);
        List<Toy> GetAllToy();
        Toy GetToyById(int toy);
    }
}
