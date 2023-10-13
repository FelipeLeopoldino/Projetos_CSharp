using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tarefas.Data;
using Tarefas.Models;

namespace Tarefas.Controllers
{
    [Route("Tarefas")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TarefaController(ApplicationDbContext context)
        {
            _context = context;
            
        }

        [HttpPost]
        public async Task<ActionResult> Create(TarefaModel tarefa)
        {
            if (tarefa == null)
            {
                return BadRequest(new Dictionary<string, string> { { "error", "Dados inválidos" } });
            }

            if (ModelState.IsValid)
            {
                tarefa.DataDeConclusao = DateTime.Now;
                _context.Tarefas.Add(tarefa);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetTarefa), new { id = tarefa.Id }, tarefa);
            }

            return BadRequest(ModelState);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TarefaModel>>> GetAll()
        {
            var tarefas = await _context.Tarefas.ToListAsync();
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaModel>> GetTarefa(long id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);

            if (tarefa is null)
            {
                return NotFound();
            }

            return Ok(tarefa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] TarefaModel tarefa)
        {
            var tarefaExistente = await _context.Tarefas.FindAsync(id);

            if (tarefaExistente is null)
            {
                return NotFound();
            }

            tarefaExistente.Nome = tarefa.Nome;
            tarefaExistente.Descricao = tarefa.Descricao;
            tarefaExistente.DataDeConclusao = tarefa.DataDeConclusao;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var tarefaExistente = await _context.Tarefas.FindAsync(id);

            if (tarefaExistente is null)
            {
                return NotFound();
            }

            _context.Tarefas.Remove(tarefaExistente);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
