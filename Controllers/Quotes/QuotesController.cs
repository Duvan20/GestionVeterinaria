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
    [Route("[controller]")]
    public class QuotesController : Controller
    {
        private readonly IQuotesService _QuotesService;

        public QuotesController(IQuotesService QuotesService)
        {
            _QuotesService = QuotesService;
        }

        [HttpGet]
        public ActionResult<Quote> GetQuote()
        {   try
            {
                var result = _QuotesService.GetQuotes();
                return Ok(result);     
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al ejecutar en codigo{ex.Message}");
            }

        }
       
    }
}