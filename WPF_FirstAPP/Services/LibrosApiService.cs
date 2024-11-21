using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_FirstAPP.DTO;
using WPF_FirstAPP.Interfaces;
using WPF_FirstAPP.Utils;

namespace WPF_FirstAPP.Services
{
    public class LibrosApiService : ILibrosProvider
    {
        public async Task<List<LibroDTO>> GetAsync()
        {
            return await HttpJsonClient<List<LibroDTO>>.Get(Constants.LIBROS_PATH);
        }
    }
}
