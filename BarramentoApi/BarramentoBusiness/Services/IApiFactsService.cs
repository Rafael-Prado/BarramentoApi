using BarramentoDomain.Domain;
using System.Threading.Tasks;

namespace BarramentoBusiness.Services
{
    public interface IApiFactsService
    {
        Task<bool> GerandoArquivoOutput(Barramentos barramento);
    }
}
