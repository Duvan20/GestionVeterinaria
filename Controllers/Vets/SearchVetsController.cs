using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GestionVeterinaria.Services.Vets;
using GestionVeterinaria.Models;

namespace GestionVeterinaria.Controllers.Vets
{
    [ApiController]
    [Route("VETS")]
    public class SearchVetsController : Controller
    {
        private readonly IVetsService _VetsService;

        public SearchVetsController(IVetsService VetsService)
        {
            _VetsService = VetsService;
        }

        [HttpGet("{id}")]
        public ActionResult<Vet> SearchVet(int id)
        {
            try
            {
                var result = _VetsService.Search(id);
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