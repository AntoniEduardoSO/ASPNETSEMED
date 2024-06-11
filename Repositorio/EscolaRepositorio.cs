using ASPNETSEMED.Data;
using ASPNETSEMED.Models;

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

            var item = _context.Escola.FirstOrDefault(x => x.Escola == nome) ?? throw new Exception($"Nenhum registro encontrado com o ID {nome}");
            return item;
        }

        public EscolaModel ListarPorIp(string ip)
        {
            var item = _context.Escola.FirstOrDefault(x => x.Ip == ip) ?? throw new Exception($"Nenhum registro encontrado com o ID {ip}");
            return item;
        }
    }
}