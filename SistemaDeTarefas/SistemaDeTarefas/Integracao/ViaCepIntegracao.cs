using SistemaDeTarefas.Integracao.Interfaces;
using SistemaDeTarefas.Integracao.Refit;
using SistemaDeTarefas.Integracao.Response;

namespace SistemaDeTarefas.Integracao
{
    public class ViaCepIntegracao : IViaCepIntegracao
    {
        private readonly IViaCepIntregacaoRefit _viaCepIntregacaoRefit;

        public ViaCepIntegracao(IViaCepIntregacaoRefit viaCepIntregacaoRefit)
        {
            _viaCepIntregacaoRefit = viaCepIntregacaoRefit; 
        }

        public async Task<ViaCepResponse> ObterDadosViaCep(string cep)
        {
            var responseData = await _viaCepIntregacaoRefit.ObterDadosViaCep(cep);

            if (responseData != null && responseData.IsSuccessStatusCode) 
            {
                return responseData.Content;
            }

            return null;
        }
    }
}
