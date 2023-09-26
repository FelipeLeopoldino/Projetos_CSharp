using Refit;
using SistemaDeTarefas.Integracao.Response;

namespace SistemaDeTarefas.Integracao.Refit
{
    public interface IViaCepIntregacaoRefit
    {
        [Get("/ws/{cep}/json")]
        Task<ApiResponse<ViaCepResponse>> ObterDadosViaCep(string cep);
    }
}
