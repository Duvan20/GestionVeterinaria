using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionVeterinaria.Models;

namespace GestionVeterinaria.Services.Quotes
{
    public interface IQuotesService 
    {
        IEnumerable<Quote> GetQuotes();

        Quote CreateQuote(Quote quote);

        Quote SearchQuote(int id);
        Quote UpdateQuote(Quote quote,int id);

        IEnumerable<Quote> GetDate(string date);

        IEnumerable<Quote> GetQuotesVets(int id);


        Quote ExistId(int id);



        
    }
}