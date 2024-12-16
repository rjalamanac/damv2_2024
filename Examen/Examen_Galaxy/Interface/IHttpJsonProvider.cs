using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Galaxy.Interface
{
    public interface IHttpJsonProvider<T> where T : class
    {
        Task<IEnumerable<T>> GetAsync(string api_url);
        Task<T> PostAsync(T data,string api_url);
        Task<bool> RemoveAsync(T data, string api_url, int id);
    }
}
