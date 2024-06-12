using ASPNETSEMED.Models;

namespace ASPNETSEMED.Repositorio
{
    public interface IAlooRepositorio
    {
        
        Task<AlooModel> ListarPorId(Guid id);
        List<AlooModel> ListaAloo();

        void ListarPorConnectionNotFound();

    }
}