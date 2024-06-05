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
    public class SearchPetsController : Controller
    {
          private readonly IPetsService _petsService;

        public SearchPetsController(IPetsService petsService)
        {
            _petsService = petsService;
        }

        [HttpGet("{id}")]
        public ActionResult<Pet> SearchPets(int id)
        {
            try
            { 
                var result = _petsService.SearchPet(id);
                if(result == null)
                {
                    return BadRequest($"No se Encontraron resultados");
                }
                return Ok(result);
                
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al ejecutar en codigo{ex.Message}");
            }
        }
     
    }
}