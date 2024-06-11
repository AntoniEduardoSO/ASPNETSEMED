
using System.ComponentModel.DataAnnotations;

namespace ASPNETSEMED.Models
{
    public class AlooModel
    {
        [Key]
        public Guid Id {get;set;}

        public required DateTime Criacao {get;set;}

        public required string Escola {get;set;}

        public required string Ip {get;set;}

        public required string Circuito {get;set;}
    }
}



// id	nome	setor	sigla	modelo	ip	status	printpage