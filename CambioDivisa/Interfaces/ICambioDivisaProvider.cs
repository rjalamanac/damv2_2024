using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CambioDivisa.Interfaces
{
    public interface ICambioDivisaService
    {
        Task<IEnumerable<string>> GetDivisas();

        Task<decimal> GetExchange(decimal amount, string from_currency, string to_currency);
    }
}
