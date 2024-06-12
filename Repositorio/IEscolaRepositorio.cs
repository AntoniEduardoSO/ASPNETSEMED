using ASPNETSEMED.Models;

namespace ASPNETSEMED.Repositorio
{
    public interface IEscolaRepositorio
    {
        
        EscolaModel ListarPorId(string id);
        List<EscolaModel> ListaEscola();

        EscolaModel Atualizar(EscolaModel model);


        Task<EscolaModel> ListarPorIp(string ip);

    }
}