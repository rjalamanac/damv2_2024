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
    public class CambioDivisaService : ICambioDivisaService
    {
        public Task<IEnumerable<string>> GetDivisas()
        {
            return Task.FromResult<IEnumerable<string>>(
            [
                Constants.DIVISA_EUROS,
                Constants.DIVISA_LIBRAS,
                Constants.DIVISA_DOLARES
            ]);
        }

        public Task<decimal> GetExchange(decimal amount, string from_currency, string to_currency)
        {
            if (from_currency == to_currency)
            {
                return Task.FromResult(amount);
            }

            switch (from_currency)
            {
                case Constants.DIVISA_LIBRAS:
                    return Task.FromResult(to_currency == Constants.DIVISA_EUROS ?
                        amount * Constants.LIBRA_TO_DOLAR * (1 / Constants.EURO_TO_DOLAR) :
                        amount * Constants.LIBRA_TO_DOLAR);
                case Constants.DIVISA_DOLARES:
                    return Task.FromResult(to_currency == Constants.DIVISA_EUROS ?
                        amount * (1 / Constants.EURO_TO_DOLAR) :
                        amount * (1 / Constants.LIBRA_TO_DOLAR));
                case Constants.DIVISA_EUROS:
                    return Task.FromResult(to_currency == Constants.DIVISA_LIBRAS ?
                        amount * Constants.EURO_TO_DOLAR * (1 / Constants.LIBRA_TO_DOLAR) :
                        amount * Constants.EURO_TO_DOLAR);
                default:
                    return Task.FromResult(amount);
            }
        }
    }
}
