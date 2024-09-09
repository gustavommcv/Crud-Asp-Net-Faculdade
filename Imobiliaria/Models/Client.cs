namespace Imobiliaria.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public List<Property> Properties { get; set; } = new List<Property>();
        public string FullName => $"{FirstName} {LastName}";
    }
}
