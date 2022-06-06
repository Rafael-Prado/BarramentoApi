using BarramentoDomain.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarramentoBusiness.LeituraArquivo
{
    public interface IRegraArquivos
    {
        Task<List<int>> ValoreArquivoLeitura(string path);
        Task<bool> GerarArquivo(string caminhoArquivoOutput, IList<Dogsfact> dogsFacts);
    }
}
