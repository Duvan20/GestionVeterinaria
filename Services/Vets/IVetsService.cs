using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionVeterinaria.Models;

namespace GestionVeterinaria.Services.Vets
{
    public interface IVetsService
    {

        IEnumerable<Vet> GetVets();

        Vet Search(int id);
        
    }
}