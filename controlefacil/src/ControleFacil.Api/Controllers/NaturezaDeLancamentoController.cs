using ControleFacil.Api.Contract.NaturezaDeLancamento;
using ControleFacil.Api.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleFacil.Api.Controllers
{
    [ApiController]
    [Route("naturezas-de-lancamento")]
    public class NaturezaDeLancamentoController : BaseController
    {
        private readonly IService<NaturezaDeLancamentoRequestContract, NaturezaDeLancamentoResponseContract, long> _naturezaDeLancamentoService;


        public NaturezaDeLancamentoController(
            IService<NaturezaDeLancamentoRequestContract, NaturezaDeLancamentoResponseContract, long> NaturezaDeLancamentoService)
        {
            _naturezaDeLancamentoService = NaturezaDeLancamentoService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Adicionar(NaturezaDeLancamentoRequestContract contrato)
        {
            try
            {
                long idUsuario = ObterIdUsuarioLogado();
                return Created("", await _naturezaDeLancamentoService.Adicionar(contrato, idUsuario));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Obter()
        {
            try
            {
                long idUsuario = ObterIdUsuarioLogado();
                return Ok(await _naturezaDeLancamentoService.Obter(idUsuario));
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Obter(long id)
        {
            try
            {
                long idUsuario = ObterIdUsuarioLogado();
                return Ok(await _naturezaDeLancamentoService.Obter(id, idUsuario));
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Atualizar(long id, NaturezaDeLancamentoRequestContract contrato)
        {
            try
            {
                long idUsuario = ObterIdUsuarioLogado();
                return Ok(await _naturezaDeLancamentoService.Atualizar(id, contrato, idUsuario));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Deletar(long id)
        {
            try
            {
                long idUsuario = ObterIdUsuarioLogado();
                await _naturezaDeLancamentoService.Inativar(id, idUsuario);
                return NoContent();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }
    }
}