using BarramentoBusiness.LeituraArquivo;
using BarramentoDomain.Domain;
using BarramentoRepository.Repositories.ApiDogsFacts;
using ExcelDataReader;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarramentoBusiness.Services
{
    public class ApiFactsService : IApiFactsService
    {
        private readonly IRegraArquivos _iRegraArquivos;
        private readonly IApiDogFactsRepository _iApiDogFactsRepository;

        public ApiFactsService(IRegraArquivos iRegraArquivos, IApiDogFactsRepository iApiDogFactsRepository)
        {
            _iRegraArquivos = iRegraArquivos;
            _iApiDogFactsRepository = iApiDogFactsRepository;
        }

        public async Task<bool> GerandoArquivoOutput(Barramentos barramento)
        {
            var retorno = false;
            var listaConsultas = _iRegraArquivos.ValoreArquivoLeitura(barramento.caminhoArquivoInput).Result;

            if (listaConsultas.Any())
            {
                var result = _iApiDogFactsRepository.GetFactsApi(barramento.url, listaConsultas).Result;
                var contador = 0;

                if (result.Any())
                {
                   retorno = _iRegraArquivos.GerarArquivo(barramento.caminhoArquivoOutput, result).Result;
                }               
                
            }
           return retorno;
        }
    }
}
