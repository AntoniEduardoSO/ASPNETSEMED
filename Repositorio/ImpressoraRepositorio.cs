using ASPNETSEMED.Data;
using ASPNETSEMED.Models;

namespace ASPNETSEMED.Repositorio
{
    public class ImpressoraRepositorio(BancoContext bancoContext) : IImpressoraRepositorio
    {
        private readonly BancoContext _context = bancoContext;

        public List<ImpressoraModel> ListaImpressora()
        {
            return _context.Impressora.ToList();
        }


        public ImpressoraModel ListarPorId(string id)
        {
             if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("O ID não pode ser nulo ou vazio", nameof(id));
            }

            var item = _context.Impressora.FirstOrDefault(x => x.Id == id) ?? throw new Exception($"Nenhum registro encontrado com o ID {id}");
            return item;
        }





    }
}
