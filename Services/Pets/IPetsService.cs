using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionVeterinaria.Models;

namespace GestionVeterinaria.Services.Pets
{
    public interface IPetsService
    {
        IEnumerable<Pet> GetPets();

        Pet CreatePet(Pet pet);

        Pet SearchPet(int id);

        Pet UpdatePet(Pet pet,int id);

        IEnumerable<Pet> GetOwnerPets(int IdOwner);

        IEnumerable<Pet> BirhDate(string DateBirh);

        Pet ExistId(int id);



        
        
    }
}