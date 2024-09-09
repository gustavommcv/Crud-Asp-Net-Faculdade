namespace Imobiliaria.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string? Address { get; set; }
        public decimal Price { get; set; }
        public int ClientId { get; set; }
        public Client? Client { get; set; }
    }

}
