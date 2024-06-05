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

namespace GestionVeterinaria.Controllers.Additional
{
    [ApiController]
    [Route("pets")]
    public class ListDateController : Controller
    {
         private readonly IPetsService _petsService;

        public ListDateController(IPetsService petsService)
        {
            _petsService = petsService;
        }

        [HttpGet("{id}/owner")]
        public ActionResult<Pet> PetOwner(int id)
        {
            try
            {
                var result = _petsService.GetOwnerPets(id);
                if(result == null)
                {
                    return BadRequest($"No se Encontraron resultados");
                }
                var Select = result.Select(b => new 
                {
                    b.Id,
                    b.Name,
                    b.Specie,
                    b.Race,
                    Ower = b.Owner != null ? b.Owner.Names : null,b.Owner.LastName

                });
                return Ok(Select);
                
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al ejecutar en codigo{ex.Message}");
            }

        }

        
    }
}