using CambioDivisa.Interfaces;
using CambioDivisa.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CambioDivisa.Service
{
    public class HistoricoDivisaService : IHistoricoDivisaProvider
    {
        public async Task<IEnumerable<string>> GetHistorico()
        {
            return await FileUtils<string>.ReadFileLineByLine(Constants.HISTORIC_FILE_PATH);
        }

        public async Task<bool> GuardarHistorico(decimal amount_origin, decimal amount_exchange, string from_currency, string to_currency)
        {

            return await FileUtils<string>.AppendLineToFile(Constants.HISTORIC_FILE_PATH, $"{DateTime.Now:dd/MM/yyyy HH:mm} Importe" +
                $" {amount_origin} {from_currency} - {amount_exchange}  {to_currency}");
        }
    }
}
