using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GestionVeterinaria.Models;
using GestionVeterinaria.Services.Quotes;

namespace GestionVeterinaria.Controllers.Quotes
{
    [ApiController]
    [Route("QUOTES")]
    public class UpdateQuotesController : Controller
    {
     
        private readonly IQuotesService _QuotesService;

        public UpdateQuotesController(IQuotesService QuotesService)
        {
            _QuotesService = QuotesService;
        }

        [HttpPut("{id}")]
        public ActionResult<Quote> UpdateQuotes(Quote quote,int id)
        {
            try
            {   
                var existid = _QuotesService.ExistId(id);
                if(existid == null)
                {
                    return BadRequest($"La citas que deseas actualizar no se a encontrado");
                }
                var result = _QuotesService.UpdateQuote(quote,id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al ejecutar en codigo{ex.Message}");
            }

        }
    }
}