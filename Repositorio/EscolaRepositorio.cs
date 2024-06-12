using ASPNETSEMED.Data;
using ASPNETSEMED.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETSEMED.Repositorio
{
    public class EscolaRepositorio : IEscolaRepositorio
    {
        private readonly BancoContext _context;

        public EscolaRepositorio(BancoContext bancoContext)
        {
            _context = bancoContext;
        }
        public EscolaModel Atualizar(EscolaModel model)
        {
            if(model.Escola != null)
            {

                EscolaModel escolaDB = ListarPorId(model.Escola);

                

                escolaDB.Id = model.Id;
                escolaDB.Escola = model.Escola;
                escolaDB.Cnpj = model.Cnpj;
                escolaDB.Telefone = model.Telefone;
                escolaDB.Diretor = model.Diretor;
                escolaDB.Email = model.Email;
                escolaDB.Status = model.Status;


                _context.Escola.Update(escolaDB);
                _context.SaveChanges();

                return escolaDB; 
            }
            
            throw new System.Exception("Erro na alteração, id está vazio");
        }

        public List<EscolaModel> ListaEscola()
        {
            return _context.Escola.ToList();
        }

        public EscolaModel ListarPorId(string nome)
        {
             if (string.IsNullOrEmpty(nome))
            {
                throw new ArgumentException("O ID não pode ser nulo ou vazio", nameof(nome));
            }

            var item = _context.Escola.FirstOrDefault(x => x.Id == nome) ?? throw new Exception($"Nenhum registro encontrado com o ID {nome}");
            
            return item;
        }

        public async Task<EscolaModel> ListarPorIp(string ip)
        {
            if(string.IsNullOrEmpty(ip))
            {
                throw new ArgumentException("O IP NÃO PODE SER NULO", nameof(ip));
            }


            var item = await _context.Escola.FirstOrDefaultAsync(x => x.Ip == ip) ?? throw new Exception("Nenhum registro");

            return item;
        }
    }
}