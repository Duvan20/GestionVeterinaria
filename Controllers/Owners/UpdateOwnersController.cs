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
    [Route("OWNERS")]
    public class UpdateOwnersController : Controller
    {
      
       private readonly IOwnersService _ownersService;

        public UpdateOwnersController(IOwnersService ownersService)
        {
            _ownersService = ownersService;
        }

        [HttpPut("{id}")]
        public ActionResult<Owner> UpdateOwners(Owner owner,int id)
        {
            try
            {
                var idexist = _ownersService.IdExist(id);
                if(idexist == null)
                {
                    return BadRequest($"El Dueño no existe en la base de datos");

                }
                var result = _ownersService.UpdateOwner(owner,id);
                return Ok(result);
                
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al ejecutar en codigo{ex.Message}");
            }

        }
    }
}