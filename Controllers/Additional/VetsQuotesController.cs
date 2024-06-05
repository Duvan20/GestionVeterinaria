using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GestionVeterinaria.Models;
using GestionVeterinaria.Services.Quotes;


namespace GestionVeterinaria.Controllers.Additional
{
    [ApiController]
    [Route("quotes")]
    public class VetsQuotesController : Controller
    {
        private readonly IQuotesService _QuotesService;

        public VetsQuotesController(IQuotesService QuotesService)
        {
            _QuotesService = QuotesService;
        }
        [HttpGet("{id}/vets")]
        public ActionResult<Quote> QuotesVets(int id)
        {
            try
            { 
                var resutl = _QuotesService.GetQuotesVets(id);
                if(resutl == null )
                {
                     return BadRequest($"El veterinario no tiene citas Agendas");

                }

                var select = resutl.Select( b =>new
                {
                    b.Id,
                    b.Date,
                    b.Description,
                    Vet = b.vets !=null ? b.vets.Name : null,
                    Pet = b.pets !=null ? b.pets.Name : null,
                    Specie = b.pets != null ? b.pets.Specie : null,
                    Race = b.pets != null ? b.pets.Race : null
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