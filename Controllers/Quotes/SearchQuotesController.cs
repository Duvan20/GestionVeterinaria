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
    public class SearchQuotesController : Controller
    {
        private readonly IQuotesService _QuotesService;

        public SearchQuotesController(IQuotesService QuotesService)
        {
            _QuotesService = QuotesService;
        }

        [HttpGet("{id}")]
        public ActionResult<Quote> SearchQuotes(int id)
        {
            try
            {
                var result = _QuotesService.SearchQuote(id);
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