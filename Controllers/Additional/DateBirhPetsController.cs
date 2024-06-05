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
    public class DateBirhPetsController : Controller
    {
         private readonly IPetsService _petsService;

        public DateBirhPetsController(IPetsService petsService)
        {
            _petsService = petsService;
        }
        [HttpGet("{Date}/birthday")]
        public ActionResult<Pet> DateBirhpest(string Date)
        {
            try
            {
                var result = _petsService.BirhDate(Date);
                 if(result == null)
                {
                    return BadRequest($"En esta fecha no hay cumpleaños de mascotas");

                }
                var select = result.Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.Race,
                    x.DateBirh
                });
                return Ok(select);
                
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al ejecutar en codigo{ex.Message}");
            }

        }

       
     
    }
}