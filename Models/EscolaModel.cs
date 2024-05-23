namespace ASPNETSEMED.Models
{
    public class EscolaModel
    {
        public required string Id { get; set; }
        public required string Escola { get; set; }
        public string? Cnpj { get; set; }
        public string? Telefone { get; set; }
        public required string Diretor { get; set; }
        public string? Email { get; set; }
        public required string Ra { get; set; }
        public required string Bairro { get; set; }
        public float? Lat { get; set; }
        public float Lon { get; set; }
        public string? Status { get; set; }
        public string? Endereco { get; set; }
        
        public string? Ip { get; set; }
        
        public string? Circuito { get; set; }
        public string? Imagem { get; set; }


    }
}