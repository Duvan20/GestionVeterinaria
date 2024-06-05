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
    [Route("[controller]")]
    public class OwnersController : Controller
    {
        private readonly IOwnersService _ownersService;

        public OwnersController(IOwnersService ownersService)
        {
            _ownersService = ownersService;
        }

        [HttpGet]
        public ActionResult<Owner> GetOwner()
        {
            try
            {
                var result = _ownersService.GetOwners();
                return Ok(result);
                
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al ejecutar en codigo{ex.Message}");
            }
        }
       
       
    }
}