using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionVeterinaria.Data;
using GestionVeterinaria.Models;

namespace GestionVeterinaria.Services.Owners
{
    public class OwnerService : IOwnersService
    {
        private readonly GestionVeterinariaContext _context;

        public OwnerService(GestionVeterinariaContext context)
        {
            _context = context;
        }

        public Owner CreateOwner(Owner owner)
        {
            _context.Owners.Add(owner);
            _context.SaveChanges();
            return owner;
            
        }

        public Owner EmailExist(string email)
        {
            return _context.Owners.FirstOrDefault(d => d.Email == email);
            
        }

        public IEnumerable<Owner> GetOwners()
        {
            return _context.Owners.ToList();
        }

        public Owner IdExist(int id)
        {
            return _context.Owners.FirstOrDefault(d => d.Id == id);
            
        }

        public Owner SearchOwner(int Id)
        {
            return _context.Owners.Find(Id);
        }

        public Owner UpdateOwner(Owner owner, int id)
        {
            owner.Id = id;
            _context.Owners.Update(owner);
            _context.SaveChanges();
            return owner;
        }
    }
}