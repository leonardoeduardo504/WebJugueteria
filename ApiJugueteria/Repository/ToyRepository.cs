using ApiJugueteria.DAL;
using ApiJugueteria.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ApiJugueteria.Repository
{
    public class ToyRepository : IToyRepository
    {
        private readonly ToyContext _context;
        public ToyRepository(ToyContext context)
        {
            _context = context;
        }

        void IToyRepository.CreateToy(Toy toy)
        {
            _context.Toys.Add(toy);
            _context.SaveChanges();            
        }

        void IToyRepository.DeleteToy(int id)
        {
            Toy toy = _context.Toys.Find(id);
            _context.Toys.Remove(toy);
            _context.SaveChanges();
        }

        List<Toy> IToyRepository.GetAllToy()
        {
            return _context.Toys.ToList();
        }

        Toy IToyRepository.GetToyById(int id)
        {
            Toy toy = _context.Toys.Find(id);
            return toy;
        }

        void IToyRepository.UpdateToy(Toy toy)
        {
            _context.Entry(toy).State = EntityState.Modified;
            _context.SaveChanges();
            
        }
    }
}