using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GestionVeterinaria.Models;
using GestionVeterinaria.Data;
using GestionVeterinaria.Services.Owners;

namespace GestionVeterinaria.Controllers.Owners
{
    [ApiController]
    [Route("owners")]
    public class SearchOwnersController : Controller
    {
        private readonly IOwnersService _ownersService;

        public SearchOwnersController(IOwnersService ownersService)
        {
            _ownersService = ownersService;
        }

        [HttpGet("{id}")]
        public ActionResult<Owner> SearchOwner(int id)
        {
            try
            {
                var result = _ownersService.SearchOwner(id);
                if(result == null)
                {
                    return BadRequest($"El id no existe en la base de datos");

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