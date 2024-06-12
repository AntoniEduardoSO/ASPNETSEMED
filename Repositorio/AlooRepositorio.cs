using ASPNETSEMED.Data;
using ASPNETSEMED.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

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

        public async Task<AlooModel> ListarPorId(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("O ID não pode ser nulo ou vazio", nameof(id));
            }

            var item = await _context.Aloo.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception($"Nenhum registro encontrado com o ID {id}");
            return item;
        }

        public List<AlooModel> ListaAloo()
        {
            return _context.Aloo.ToList();
        }

        public async Task<AlooModel> Adicionar(string ip)
        {
            EscolaModel escola = await _escolaRepositorio.ListarPorIp(ip) ?? throw new Exception("Escola com IP não encontrada");

            if (escola.Escola == null || escola.Ip == null || escola.Circuito == null)
            {
                throw new Exception("Uma ou mais propriedades da escola são nulas");
            }

            AlooModel aloo = new()
            {
                Id = Guid.NewGuid(),
                Criacao = DateTime.UtcNow,
                Escola = escola.Escola,
                Ip = escola.Ip,
                Circuito = escola.Circuito,
            };

            _context.Aloo.Add(aloo);
            await _context.SaveChangesAsync();
            return aloo;
        }
        public void ListarPorConnectionNotFound()
        {
            List<EscolaModel> escolas = _context.Escola.ToList();

            Parallel.ForEach(escolas, async escola =>
            {
                if (escola.Ip != null)
                {
                    PingHost(escola.Ip);
                }
            });
        }

        private async Task PingHost(string ip)
        {
            bool pingable = false;

            using (Ping pinger = new())
            {
                try
                {
                    PingReply reply = await pinger.SendPingAsync(ip);
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
            }

            if (!pingable)
            {
                if (await AlooAlreadyExist(ip))
                    await Adicionar(ip);
            }
        }

        private async Task<bool> AlooAlreadyExist(string ip)
        {
            return await _context.Aloo.FirstOrDefaultAsync(x => x.Ip == ip) != null;
        }
    }
}
