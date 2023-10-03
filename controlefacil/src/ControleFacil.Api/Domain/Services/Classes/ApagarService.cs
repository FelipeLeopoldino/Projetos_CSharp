using AutoMapper;
using ControleFacil.Api.Contract.Apagar;
using ControleFacil.Api.Domain.Models;
using ControleFacil.Api.Domain.Repository.Interfaces;
using ControleFacil.Api.Domain.Services.Interfaces;

namespace ControleFacil.Api.Domain.Services.Classes
{
    public class ApagarService : IService<ApagarRequestContract, ApagarResponseContract, long>
    {
        private readonly IApagarRepository _apagarRepository;
        private readonly IMapper _mapper;

        public ApagarService(IApagarRepository ApagarRepository, IMapper mapper)
        {
            _apagarRepository = ApagarRepository;
            _mapper = mapper;
        }

        public async Task<ApagarResponseContract> Adicionar(ApagarRequestContract entidade, long idUsuario)
        {
            var Apagar = _mapper.Map<Apagar>(entidade);

            Apagar.DataCadastro = DateTime.Now;
            Apagar.IdUsuario = idUsuario;

            Apagar = await _apagarRepository.Adicionar(Apagar);

            return _mapper.Map<ApagarResponseContract>(Apagar);
        }

        public async Task<ApagarResponseContract> Atualizar(long id, ApagarRequestContract entidade, long idUsuario)
        {
            var apagar = await ObterPorIdVinculadoAoIdUsuario(id, idUsuario);

            var contrato = _mapper.Map<Apagar>(entidade);
            contrato.IdUsuario = apagar.IdUsuario;
            contrato.Id = apagar.Id;
            contrato.DataCadastro = apagar.DataCadastro;

            contrato = await _apagarRepository.Atualizar(contrato);

            return _mapper.Map<ApagarResponseContract>(contrato);
        }

        public async Task Inativar(long id, long idUsuario)
        {
            var apagar = await ObterPorIdVinculadoAoIdUsuario(id, idUsuario);
            await _apagarRepository.Deletar(apagar);
        }

        public async Task<IEnumerable<ApagarResponseContract>> Obter(long idUsuario)
        {
            var titulosApagar = await _apagarRepository.ObterPeloIdUsuario(idUsuario);
            return titulosApagar.Select(titulo => _mapper.Map<ApagarResponseContract>(titulo));
        }

        public async Task<ApagarResponseContract> Obter(long id, long idUsuario)
        {
            var apagar = await ObterPorIdVinculadoAoIdUsuario(id, idUsuario);

            return _mapper.Map<ApagarResponseContract>(apagar);
        }

        private async Task<Apagar> ObterPorIdVinculadoAoIdUsuario(long id, long idUsuario)
        {
            var apagar = await _apagarRepository.Obter(id);

            if (apagar is null || apagar.IdUsuario != idUsuario)
            {
                throw new Exception($"Não foi encontrado nenhum titulo apagar pelo id: {id}");
            }

            return apagar;
        }
    }


}