using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionVeterinaria.Data;
using GestionVeterinaria.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionVeterinaria.Services.Pets
{
    public class PetsService : IPetsService
    {
        private readonly GestionVeterinariaContext _context;

        public PetsService(GestionVeterinariaContext context)
        {
            _context = context;
        }

        public IEnumerable<Pet> BirhDate(string DateBirh)
        {
            DateTime Date = DateTime.Parse(DateBirh);
            return _context.Pets.Include(o => o.Owner).Where(d => d.DateBirh == Date).ToList();
        }

        public Pet CreatePet(Pet pet)
        {
            _context.Pets.Add(pet);
            _context.SaveChanges();
            return pet;
        }

        public Pet ExistId(int id)
        {
            return _context.Pets.Include(o => o.Owner).FirstOrDefault(d =>d.Id == id);
        }

        public IEnumerable<Pet> GetOwnerPets(int IdOwner)
        {
            return _context.Pets.Include(o => o.Owner).Where(i => i.Id == IdOwner).ToList();
        }

        public IEnumerable<Pet> GetPets()
        {
            return _context.Pets.Include(o => o.Owner).ToList();
        }

        public Pet SearchPet(int id)
        {
            return _context.Pets.Include(o => o.Owner).FirstOrDefault(d => d.Id == id);   
        }

        public Pet UpdatePet(Pet pet, int id)
        {
            pet.Id = id;
            _context.Pets.Update(pet);
            _context.SaveChanges();
            return pet;
        }
    }
}