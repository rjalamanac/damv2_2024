using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CambioDivisa.Interfaces
{
    public interface IHistoricoDivisaProvider
    {
        Task<IEnumerable<string>> GetHistorico();

        Task<bool> GuardarHistorico(decimal amount_origin, decimal amount_exchange, string from_currency, string to_currency);
    }
}
