using BarramentoDomain.Domain;
using ExcelDataReader;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarramentoBusiness.LeituraArquivo
{
    public class RegraArquivos : IRegraArquivos
    {
        

        public async Task<List<int>> ValoreArquivoLeitura(string path)
        {
            var listInt = new List<int>();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            if (!string.IsNullOrEmpty(path))
            {
                FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read);
                IExcelDataReader excelReader = null;
                try
                {
                    if (path.EndsWith(".xls"))
                    {
                        excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                    }
                    if (path.EndsWith(".xlsx"))
                    {
                        excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                while (excelReader.Read())
                {
                    for (int column = 0; column < excelReader.FieldCount; column++)
                    {
                        listInt.Add(Convert.ToInt32(excelReader.GetValue(column)));
                    }
                }
                while (excelReader.NextResult())
                    excelReader.Close();
            }
            return listInt;
        }

        public async Task<bool> GerarArquivo(string caminhoArquivoOutput, IList<Dogsfact> dogsFacts)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            FileInfo arquivo = new FileInfo(caminhoArquivoOutput);
            if (arquivo.Exists)
            {
                arquivo.Delete();
                arquivo = new FileInfo(caminhoArquivoOutput);
            }
            try
            {
                using var excelPackage = new ExcelPackage(arquivo);
                if (excelPackage.Workbook.Properties.Author == "")
                {
                    excelPackage.Workbook.Properties.Author = "Facts";
                    excelPackage.Workbook.Properties.Title = "Meus Facts";
                }
                var contador = 0;
                foreach (var item in dogsFacts)
                {
                    contador++;
                    var sheet = excelPackage.Workbook.Worksheets.Add($"Planilha {contador}");
                    sheet.Name = $"Facts {contador}";
                    var linha = 0;
                    for (int i = 0; i < item.facts.Count(); i++)
                    {
                        linha++;
                        sheet.Cells[linha, 1].Value = item.facts[i];
                    }
                }

                excelPackage.Save();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
           
        }
    }
}
