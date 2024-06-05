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
    public class CreateOwnersController : Controller
    {
        private readonly IOwnersService _ownersService;

        public CreateOwnersController(IOwnersService ownersService)
        {
            _ownersService = ownersService;
        }

        [HttpPost]
        public ActionResult<Owner> CreateOwners(Owner owner)
        {
            try
            {

                var emailexist= _ownersService.EmailExist(owner.Email);

                if(emailexist != null)
                {
                    return BadRequest($"El correo que estas registrando ya es existente en la base de datos");
                }
                var result = _ownersService.CreateOwner(owner);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al ejecutar en codigo{ex.Message}"); 
            }
        }
        
    }
}