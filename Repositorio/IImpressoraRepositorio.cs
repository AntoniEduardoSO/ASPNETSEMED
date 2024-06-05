using ASPNETSEMED.Models;

namespace ASPNETSEMED.Repositorio
{
    public interface IImpressoraRepositorio
    {
        
        ImpressoraModel ListarPorId(string id);
        List<ImpressoraModel> ListaImpressora();

    }
}