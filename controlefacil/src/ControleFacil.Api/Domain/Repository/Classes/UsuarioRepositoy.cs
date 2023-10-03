using ControleFacil.Api.Data;
using ControleFacil.Api.Domain.Models;
using ControleFacil.Api.Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleFacil.Api.Domain.Repository.Classes
{
    public class UsuarioRepositoy : IUsuarioRepository
    {

        private readonly ApplicationContext _context;

        public UsuarioRepositoy(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Usuario> Adicionar(Usuario entidade)
        {
            await _context.Usuario.AddAsync(entidade);
            await _context.SaveChangesAsync();

            return entidade;
        }

        public async Task<Usuario> Atualizar(Usuario entidade)
        {
            Usuario entidadeBanco = _context.Usuario
            .Where(u => u.Id == entidade.Id)
            .FirstOrDefault();

            _context.Entry(entidadeBanco).CurrentValues.SetValues(entidade);
            _context.Update<Usuario>(entidadeBanco);

            await _context.SaveChangesAsync();

            return entidadeBanco;
        }

        public async Task Deletar(Usuario entidade)
        {
            //Deleta fisiso, deleta no contexto e depois no banco
            _context.Entry(entidade).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Usuario>> Obter()
        {
            return await _context.Usuario.AsNoTracking()
            .OrderBy(u => u.Id)
            .ToListAsync();
        }

        public async Task<Usuario?> Obter(long id)
        {
            return await _context.Usuario.AsNoTracking()
            .Where(u => u.Id == id)
            .FirstOrDefaultAsync();
        }

        public async Task<Usuario> Obter(string email)
        {
            return await _context.Usuario.AsNoTracking()
            .Where(u => u.Email == email)
            .FirstOrDefaultAsync();
        }

    }
}