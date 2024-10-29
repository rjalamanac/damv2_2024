using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_FirstAPP.Interfaces;

namespace WPF_FirstAPP.Services
{
    internal class PrimeNumberService : IPrimeNumberProvider
    {
        public  bool IsNumberPrime(int val)
        {
            for (int i = 2; i < val; i++)
            {
                if (val % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
