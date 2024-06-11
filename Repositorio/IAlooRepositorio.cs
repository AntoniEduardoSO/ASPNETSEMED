using ASPNETSEMED.Models;

namespace ASPNETSEMED.Repositorio
{
    public interface IAlooRepositorio
    {
        
        AlooModel ListarPorId(Guid id);
        List<AlooModel> ListaAloo();

        void ListarPorConnectionNotFound();

    }
}