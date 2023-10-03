using AutoMapper;
using ControleFacil.Api.Contract.NaturezaDeLancamento;
using ControleFacil.Api.Domain.Models;
using ControleFacil.Api.Domain.Repository.Interfaces;
using ControleFacil.Api.Domain.Services.Interfaces;
using ControleFacil.Api.Exceptions;

namespace ControleFacil.Api.Domain.Services.Classes
{
    public class NaturezaDeLancamentoService : IService<NaturezaDeLancamentoRequestContract, NaturezaDeLancamentoResponseContract, long>
    {
        private readonly INaturezaDeLancamentoRepository _naturezaDeLancamentoRepository;
        private readonly IMapper _mapper;

        public NaturezaDeLancamentoService(INaturezaDeLancamentoRepository naturezaDeLancamentoRepository, IMapper mapper)
        {
            _naturezaDeLancamentoRepository = naturezaDeLancamentoRepository;
            _mapper = mapper;
        }

        public async Task<NaturezaDeLancamentoResponseContract> Adicionar(NaturezaDeLancamentoRequestContract entidade, long idUsuario)
        {
            var naturezaDeLancamento = _mapper.Map<NaturezaDeLancamento>(entidade);

            naturezaDeLancamento.DataCadastro = DateTime.Now;
            naturezaDeLancamento.IdUsuario = idUsuario;
            naturezaDeLancamento = await _naturezaDeLancamentoRepository.Adicionar(naturezaDeLancamento);

            return _mapper.Map<NaturezaDeLancamentoResponseContract>(naturezaDeLancamento);
        }

        public async Task<NaturezaDeLancamentoResponseContract> Atualizar(long id, NaturezaDeLancamentoRequestContract entidade, long idUsuario)
        {
            var naturezaDeLancamento = await ObterPorIdVinculadoAoIdUsuario(id, idUsuario);

            naturezaDeLancamento.Descricao = entidade.Descricao;
            naturezaDeLancamento.Observacao = entidade.Observacao;

            naturezaDeLancamento = await _naturezaDeLancamentoRepository.Atualizar(naturezaDeLancamento);

            return _mapper.Map<NaturezaDeLancamentoResponseContract>(naturezaDeLancamento);
        }

        public async Task Inativar(long id, long idUsuario)
        {
            var naturezaDeLancamento = await ObterPorIdVinculadoAoIdUsuario(id, idUsuario);
            await _naturezaDeLancamentoRepository.Deletar(naturezaDeLancamento);
        }

        public async Task<IEnumerable<NaturezaDeLancamentoResponseContract>> Obter(long idUsuario)
        {
            var naturezaDeLancamento = await _naturezaDeLancamentoRepository.ObterPeloIdUsuario(idUsuario);
            return naturezaDeLancamento.Select(n => _mapper.Map<NaturezaDeLancamentoResponseContract>(n));
        }

        public async Task<NaturezaDeLancamentoResponseContract> Obter(long id, long idUsuario)
        {
            var naturezaDeLancamento = await ObterPorIdVinculadoAoIdUsuario(id, idUsuario);

            return _mapper.Map<NaturezaDeLancamentoResponseContract>(naturezaDeLancamento);
        }

        private async Task<NaturezaDeLancamento> ObterPorIdVinculadoAoIdUsuario(long id, long idUsuario)
        {
            var naturezaDeLancamento = await _naturezaDeLancamentoRepository.Obter(id);

            if (naturezaDeLancamento is null || naturezaDeLancamento.IdUsuario != idUsuario)
            {
                throw new NotFoundException ($"Não foi encontrada nenhuma natureza de lançamento pelo id: {id}");
            }

            return naturezaDeLancamento;
        }
    }


}