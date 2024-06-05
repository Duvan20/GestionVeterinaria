using Microsoft.EntityFrameworkCore;
using GestionVeterinaria.Models;

namespace GestionVeterinaria.Data
{
    public class GestionVeterinariaContext : DbContext
    {
        public GestionVeterinariaContext (DbContextOptions<GestionVeterinariaContext> options)
            : base(options)
        {
        }

        public DbSet<Owner> Owners { get; set; }

        public DbSet<Pet> Pets { get; set; }

        public DbSet<Quote> Quotes { get; set;}

        public DbSet<Vet> Vets { get; set; } 

    }

}