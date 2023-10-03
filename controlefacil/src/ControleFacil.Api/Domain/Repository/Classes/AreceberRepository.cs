using ControleFacil.Api.Data;
using ControleFacil.Api.Domain.Models;
using ControleFacil.Api.Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleFacil.Api.Domain.Repository.Classes
{
    public class AreceberRepository : IAreceberRepository
    {

        private readonly ApplicationContext _context;

        public AreceberRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Areceber> Adicionar(Areceber entidade)
        {
            await _context.Areceber.AddAsync(entidade);
            await _context.SaveChangesAsync();

            return entidade;
        }

        public async Task<Areceber> Atualizar(Areceber entidade)
        {
            Areceber entidadeBanco = _context.Areceber
            .Where(n => n.Id == entidade.Id)
            .FirstOrDefault();

            _context.Entry(entidadeBanco).CurrentValues.SetValues(entidade);
            _context.Update<Areceber>(entidadeBanco);

            await _context.SaveChangesAsync();

            return entidadeBanco;
        }

        public async Task Deletar(Areceber entidade)
        {
            //Deletar logico, só altero a data de inativação
            entidade.DataInativacao = DateTime.Now;
            await Atualizar(entidade);
        }

        public async Task<IEnumerable<Areceber>> Obter()
        {
            return await _context.Areceber
            .AsNoTracking()
            .OrderBy(n => n.Id)
            .ToListAsync();
        }

        public async Task<Areceber> Obter(long id)
        {
            return await _context.Areceber
            .AsNoTracking()
            .Where(n => n.Id == id)
            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Areceber>> ObterPeloIdUsuario(long idUsuario)
        {
            return await _context.Areceber
            .AsNoTracking()
            .Where(n => n.IdUsuario == idUsuario)
            .OrderBy(n => n.Id)
            .ToListAsync();
        }
    }
}