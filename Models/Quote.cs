namespace GestionVeterinaria.Models
{
    public class Quote
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int Petid { get; set; }

        public Pet? pets { get; set; }

        public int Vetid { get; set; }

        public Vet? vets { get; set; }

        public string? Description { get; set; } 

        public string? Status { get; set; }
    }
}