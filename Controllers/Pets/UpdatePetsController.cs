using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GestionVeterinaria.Models;
using GestionVeterinaria.Data;
using GestionVeterinaria.Services.Pets;

namespace GestionVeterinaria.Controllers.Pets
{
    [ApiController]
    [Route("Pets")]
    public class UpdatePetsController : Controller
    {
        private readonly IPetsService _petsService;

        public UpdatePetsController(IPetsService petsService)
        {
            _petsService = petsService;
        }

        [HttpPut]
        public ActionResult<Pet> UpdatePets(Pet pet)
        {
            try
            {
                var idExist = _petsService.ExistId(pet.Id);
                if(idExist ==  null)
                {
                    return BadRequest($"El Animal al que deseas actualizar no se encuentra en la base de datos");

                }

                var result = _petsService.UpdatePet(pet,pet.Id);
                return Ok(result);
                
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al ejecutar en codigo{ex.Message}");
                
                
            }

        }
    }
}