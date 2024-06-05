using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionVeterinaria.Models;
using GestionVeterinaria.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionVeterinaria.Services.Quotes
{
    public class QuotesService : IQuotesService
    {
        private readonly GestionVeterinariaContext _context;

        public QuotesService(GestionVeterinariaContext context)
        {
            _context = context;
        }

        public Quote CreateQuote(Quote quote)
        {
            _context.Quotes.Add(quote);
            _context.SaveChanges();
            return quote;
        }

        public Quote ExistId(int id)
        {
            return _context.Quotes.Include(p => p.pets).Include(v => v.vets).FirstOrDefault(d => d.Id == id);

        }

        public IEnumerable<Quote> GetDate(string date)
        {
            DateTime DateDay = DateTime.Parse(date);
            return _context.Quotes.Include(p => p.pets).Include(v => v.vets).Where(d => d.Date == DateDay).ToList();
        }

        public IEnumerable<Quote> GetQuotes()
        {
            return _context.Quotes.Include(p => p.pets).Include(v => v.vets).ToList();
           
        }

        public IEnumerable<Quote> GetQuotesVets(int id)
        {
            return _context.Quotes.Include(p => p.pets).Include(v => v.vets).Where(d => d.Vetid == id).ToList();
        }

        public Quote SearchQuote(int id)
        {
            return _context.Quotes.Include(p => p.pets).Include(v => v.vets).FirstOrDefault(q => q.Id == id);
        }

        public Quote UpdateQuote(Quote quote, int id)
        {
            quote.Id = id;
            _context.Quotes.Update(quote);
            _context.SaveChanges();
            return quote;
        }
    }
}