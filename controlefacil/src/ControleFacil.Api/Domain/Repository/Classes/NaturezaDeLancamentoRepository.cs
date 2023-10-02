using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleFacil.Api.Data;
using ControleFacil.Api.Domain.Models;
using ControleFacil.Api.Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleFacil.Api.Domain.Repository.Classes
{
    public class NaturezaDeLancamentoRepository : INaturezaDeLancamentoRepository
    {

        private readonly ApplicationContext _context;

        public NaturezaDeLancamentoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<NaturezaDeLancamento> Adicionar(NaturezaDeLancamento entidade)
        {
            await _context.NaturezaDeLancamentos.AddAsync(entidade);
            await _context.SaveChangesAsync();

            return entidade;
        }

        public async Task<NaturezaDeLancamento> Atualizar(NaturezaDeLancamento entidade)
        {
            NaturezaDeLancamento entidadeBanco = _context.NaturezaDeLancamentos
            .Where(n => n.Id == entidade.Id)
            .FirstOrDefault();

            _context.Entry(entidadeBanco).CurrentValues.SetValues(entidade);
            _context.Update<NaturezaDeLancamento>(entidadeBanco);

            await _context.SaveChangesAsync();

            return entidadeBanco;
        }

        public async Task Deletar(NaturezaDeLancamento entidade)
        {
            //Deletar logico, só altero a data de inativação
            entidade.DataInativacao = DateTime.Now;
            await Atualizar(entidade);
        }

        public async Task<IEnumerable<NaturezaDeLancamento>> Obter()
        {
            return await _context.NaturezaDeLancamentos
            .AsNoTracking()
            .OrderBy(n => n.Id)
            .ToListAsync();
        }

        public async Task<NaturezaDeLancamento> Obter(long id)
        {
            return await _context.NaturezaDeLancamentos
            .AsNoTracking()
            .Where(n => n.Id == id)
            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<NaturezaDeLancamento>> ObterPeloIdUsuario(long idUsuario)
        {
            return await _context.NaturezaDeLancamentos
            .AsNoTracking()
            .Where(n => n.IdUsuario == idUsuario)
            .OrderBy(n => n.Id)
            .ToListAsync();
        }
    }
}