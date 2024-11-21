using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_FirstAPP.DTO;

namespace WPF_FirstAPP.Interfaces
{
    public interface ILibrosProvider
    {
        public Task<List<LibroDTO>> GetAsync();
    }
}
