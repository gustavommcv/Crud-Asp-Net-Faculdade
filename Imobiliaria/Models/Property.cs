namespace Imobiliaria.Models {
    public class Property {
        public int Id { get; set; }
        public string? Address { get; set; }
        public decimal Price { get; set; }
        public int? ClientId { get; set; }
        public Client? Client { get; set; }
        public Contract? Contract { get; set; }

        public override string ToString() {
            return $"Property ID: {Id}, Address: {Address}, Price: {Price:C}, " +
                   $"Client ID: {ClientId?.ToString() ?? "None"}, " +
                   $"Client Name: {Client?.FullName ?? "No Client"}, " +
                   $"Contract: {(Contract != null ? "Yes" : "No")}";
        }
    }
}
