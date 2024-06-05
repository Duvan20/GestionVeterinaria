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
    [Route("[controller]")]
    public class VetsController : Controller
    {
       private readonly IVetsService _VetsService;

        public VetsController(IVetsService VetsService)
        {
            _VetsService = VetsService;
        }

        [HttpGet]
        public ActionResult<Vet> GetVets()
        {
            try
            {
                var result = _VetsService.GetVets();
                return Ok(result);
                
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al ejecutar en codigo{ex.Message}");
            }

        }

        
    }
}