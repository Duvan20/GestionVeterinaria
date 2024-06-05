using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionVeterinaria.Models;
using GestionVeterinaria.Data;

namespace GestionVeterinaria.Services.Vets
{
    public class VetsService : IVetsService
    {
        private readonly GestionVeterinariaContext _context;

        public VetsService(GestionVeterinariaContext context)
        {
            _context = context;
        }
        public IEnumerable<Vet> GetVets()
        {
            return _context.Vets.ToList();
        }

        public Vet Search(int id)
        {
            return _context.Vets.Find(id);
        }
    }
}