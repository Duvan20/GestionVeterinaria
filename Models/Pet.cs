using System.Text.Json.Serialization;

namespace GestionVeterinaria.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Specie { get; set; }
        public string? Race { get; set; }
        public DateTime DateBirh { get; set; }
        public int Ownerid { get; set; }
        public Owner? Owner { get; set;}

        public string? Status { get; set; }

        [JsonIgnore]
        public ICollection<Quote>? Quotes {get; set;}
    }
}