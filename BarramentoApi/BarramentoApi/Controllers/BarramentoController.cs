using BarramentoBusiness.Services;
using BarramentoDomain.Domain;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace BarramentoApi.Controllers
{
    [Route("api/v1/")]
    [ApiController]
    public class BarramentoController : ControllerBase
    {       
        private readonly IApiFactsService _apiFactsSevice;

        public BarramentoController(IApiFactsService apiFactsSevice)
        {
            _apiFactsSevice = apiFactsSevice;
        }

        [HttpPost]
        [Route("barramento")]
        public async Task<string> PostBarramento(Barramentos barramento)
        {
            
            var result = await _apiFactsSevice.GerandoArquivoOutput(barramento);
            if (result)
            {
                return barramento.caminhoArquivoOutput;
            }

            return "Erro na geração de arquivos!";
        }
    }
}
