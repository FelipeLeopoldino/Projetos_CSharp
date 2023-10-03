using ControleFacil.Api.Data;
using ControleFacil.Api.Domain.Models;
using ControleFacil.Api.Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleFacil.Api.Domain.Repository.Classes
{
    public class ApagarRepository : IApagarRepository
    {

        private readonly ApplicationContext _context;

        public ApagarRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Apagar> Adicionar(Apagar entidade)
        {
            await _context.Apagar.AddAsync(entidade);
            await _context.SaveChangesAsync();

            return entidade;
        }

        public async Task<Apagar> Atualizar(Apagar entidade)
        {
            Apagar entidadeBanco = _context.Apagar
            .Where(n => n.Id == entidade.Id)
            .FirstOrDefault();

            _context.Entry(entidadeBanco).CurrentValues.SetValues(entidade);
            _context.Update<Apagar>(entidadeBanco);

            await _context.SaveChangesAsync();

            return entidadeBanco;
        }

        public async Task Deletar(Apagar entidade)
        {
            //Deletar logico, só altero a data de inativação
            entidade.DataInativacao = DateTime.Now;
            await Atualizar(entidade);
        }

        public async Task<IEnumerable<Apagar>> Obter()
        {
            return await _context.Apagar
            .AsNoTracking()
            .OrderBy(n => n.Id)
            .ToListAsync();
        }

        public async Task<Apagar> Obter(long id)
        {
            return await _context.Apagar
            .AsNoTracking()
            .Where(n => n.Id == id)
            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Apagar>> ObterPeloIdUsuario(long idUsuario)
        {
            return await _context.Apagar
            .AsNoTracking()
            .Where(n => n.IdUsuario == idUsuario)
            .OrderBy(n => n.Id)
            .ToListAsync();
        }
    }
}