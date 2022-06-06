using BarramentoDomain.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarramentoRepository.Repositories.ApiDogsFacts
{
    public interface IApiDogFactsRepository
    {
        Task<IList<Dogsfact>> GetFactsApi(string url, List<int> quantidades);
    }
}
