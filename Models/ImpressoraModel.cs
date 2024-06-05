namespace ASPNETSEMED.Models
{
    public class ImpressoraModel
    {
        public required string Id {get;set;}
        public required string Nome {get;set;}
        public required string Setor {get;set;}

        public string? Sigla  {get;set;}

        public required string Modelo {get;set;}

        public string? Ip  {get;set;}

        public required bool Status {get;set;}

        public string? Printpage {get;set;}
    }
}



// id	nome	setor	sigla	modelo	ip	status	printpage