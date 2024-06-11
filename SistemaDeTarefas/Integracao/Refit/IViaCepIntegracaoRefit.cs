using Refit;
using SistemaDeTarefas.Integracao.Response;
using System.Threading.Tasks;

namespace SistemaDeTarefas.Integracao.Refit
{
    public interface IViaCepIntegracaoRefit
    {
        // Método que vai buscar no ViaCEP
        [Get("/ws/{cep}/json")]
        Task<ApiResponse<ViaCepResponse>> ObterDadosViaCep(string cep);
    }
}
