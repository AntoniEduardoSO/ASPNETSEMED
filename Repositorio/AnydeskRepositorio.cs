using ASPNETSEMED.Data;
using ASPNETSEMED.Models;

namespace ASPNETSEMED.Repositorio
{
    public class AnydeskRepositorio : IAnydeskRepositorio
    {
        private readonly BancoContext _context;

        public AnydeskRepositorio(BancoContext bancoContext)
        {
            _context = bancoContext;
        }

        public bool Apagar(string id)
        {
            AnydeskModel anydeskDB = ListarPorId(id) ?? throw new System.Exception("Erro no ID, ele não existe");


            _context.Anydesk.Remove(anydeskDB);

            _context.SaveChanges();

            return true;
        }

        public AnydeskModel Atualizar(AnydeskModel model)
        {
            if(model.Id != null)
            {
               

                AnydeskModel anydeskDB = ListarPorId(model.Id);


                anydeskDB.Id = model.Id;
                anydeskDB.Escola = model.Escola;
                anydeskDB.Patrimonio = model.Patrimonio;

                _context.Anydesk.Update(anydeskDB);
                _context.SaveChanges();

                return anydeskDB; 
            }
            
            throw new System.Exception("Erro na alteração, id está vazio");
        }

        public AnydeskModel ListarPorId(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("O ID não pode ser nulo ou vazio", nameof(id));
            }

            var item = _context.Anydesk.FirstOrDefault(x => x.Id == id) ?? throw new Exception($"Nenhum registro encontrado com o ID {id}");
            return item;
        }

        public List<AnydeskModel> ListaAnydesk()
        {
            return _context.Anydesk.ToList();
        }

        public AnydeskModel Adicionar(AnydeskModel anydesk)
        {
            List<EscolaModel> escolas = _context.Escola.ToList();
            string nomeEscola = escolas.FirstOrDefault(x => x.Id == anydesk.Escola)?.Escola ?? throw new Exception($"Nenhum registro encontrado com o ID");

            anydesk.Escola = nomeEscola;
            _context.Anydesk.Add(anydesk);
            _context.SaveChanges();
            return anydesk;
        }


    }
}
