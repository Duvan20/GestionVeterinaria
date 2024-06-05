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
    public class CreatePetsController : Controller
    {
        private readonly IPetsService _petsService;

        public CreatePetsController(IPetsService petsService)
        {
            _petsService = petsService;
        }

        [HttpPost]
        public ActionResult<Pet> CreatePets(Pet pet)
        {
            try
            {
                var result = _petsService.CreatePet(pet);
                return Ok(result);
                
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al ejecutar en codigo{ex.Message}");
            }

        }
       
    }
}