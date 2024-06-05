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
    [Route("[controller]")]
    public class PetsController : Controller
    {
        private readonly IPetsService _petsService;

        public PetsController(IPetsService petsService)
        {
            _petsService = petsService;
        }

        [HttpGet]
        public ActionResult<Pet> GetPets()
        {
            try
            {
                var result = _petsService.GetPets();
                return Ok(result);
                
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al ejecutar en codigo{ex.Message}");
            }
        }
       
    }
}