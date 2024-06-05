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
    [Route("quotes")]
    public class DateQuoteController : Controller
    {
        private readonly IQuotesService _QuotesService;

        public DateQuoteController(IQuotesService QuotesService)
        {
            _QuotesService = QuotesService;
        }

        [HttpGet("{day}/date")]
        public ActionResult<Quote> GetDate(string day)
        {
            try
            {
                var result = _QuotesService.GetDate(day);
                if(result == null)
                {
                    return BadRequest($"En esta fecha no hay citas agendas");
                }
                var select = result.Select(b => new
                {
                    b.Id,
                    b.Date,
                    b.Description,
                    Name = b.pets != null ? b.pets.Name : null,
                    Race = b.pets != null ? b.pets.Race : null,
                    NameVet= b.vets != null ? b.vets.Name : null

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