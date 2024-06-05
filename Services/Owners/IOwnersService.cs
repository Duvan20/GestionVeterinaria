using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionVeterinaria.Models;

namespace GestionVeterinaria.Services.Owners
{
    public interface IOwnersService
    {
        IEnumerable<Owner> GetOwners();

        Owner CreateOwner(Owner owner);

        Owner SearchOwner(int Id);

        Owner UpdateOwner(Owner owner,int id);

        //buscar email
        Owner EmailExist(string email);

        //buscar id existe
        Owner IdExist(int id);

    
        
    }
}