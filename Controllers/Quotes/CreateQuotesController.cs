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
    [Route("Quotes")]
    public class CreateQuotesController : Controller
    {
         private readonly IQuotesService _QuotesService;

        public CreateQuotesController(IQuotesService QuotesService)
        {
            _QuotesService = QuotesService;
        }

        [HttpPost]
        public ActionResult<Quote> CreateQuotes(Quote quote)
        {
            try
            {
                var result = _QuotesService.CreateQuote(quote);
                return Ok(result);
                
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al ejecutar en codigo{ex.Message}");
                
            }

        }

        
    }
}