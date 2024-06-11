using ASPNETSEMED.Data;
using ASPNETSEMED.Models;
using System.Net.NetworkInformation;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;


namespace ASPNETSEMED.Repositorio
{
    public class AlooRepositorio : IAlooRepositorio
    {
        private readonly BancoContext _context;
        private readonly IEscolaRepositorio _escolaRepositorio;

        public AlooRepositorio(BancoContext bancoContext, IEscolaRepositorio escolaRepositorio)
        {
            _context = bancoContext;
            _escolaRepositorio = escolaRepositorio;
        }

        public AlooModel ListarPorId(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("O ID não pode ser nulo ou vazio", nameof(id));
            }

            var item = _context.Aloo.FirstOrDefault(x => x.Id == id) ?? throw new Exception($"Nenhum registro encontrado com o ID {id}");
            return item;
        }

        public List<AlooModel> ListaAloo()
        {
            using (var context = new BancoContext()) // Cria um novo contexto para esta operação
            {
                return context.Aloo.ToList();
            }
        }

        public AlooModel Adicionar(string ip)
        {
            EscolaModel escola = _escolaRepositorio.ListarPorIp(ip) ?? throw new Exception("Escola com ip nao encontrada");

            if (escola.Escola == null || escola.Ip == null || escola.Circuito == null)
            {
                throw new Exception("Uma ou mais propriedades da escola são nulas");
            }

            using (var context = new BancoContext())
            {
                AlooModel aloo = new()
                {
                    Id = Guid.NewGuid(),
                    Criacao = DateTime.UtcNow,
                    Escola = escola.Escola,
                    Ip = escola.Ip,
                    Circuito = escola.Circuito,
                };

                _context.Aloo.Add(aloo);
                _context.SaveChanges();
                return aloo;
            }
        }

        public void ListarPorConnectionNotFound()
        {
            List<EscolaModel> escolas = _context.Escola.ToList();

            Parallel.ForEach( escolas, escola => {
                if (escola.Ip != null)
                {
                    PingHost(escola.Ip);
                }
            });
           
        }

        private void PingHost(string ip)
        {
            bool pingable = false;

            Ping pinger = new();

            try
            {
                PingReply reply = pinger.Send(ip);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException ex)
            {
                Console.WriteLine($"PINGER: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex.Message);
            }

            if(!pingable){
                Console.WriteLine("dentro do pingable");
                AlooAlreadyExist(ip);
            }
        }

        private void AlooAlreadyExist(string ip)
        {
            if(_context.Aloo.FirstOrDefaultAsync(x => x.Ip == ip).Result == null){
                Adicionar(ip);
            }
        }

    }
}
