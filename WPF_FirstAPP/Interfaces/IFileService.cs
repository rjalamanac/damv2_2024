using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_FirstAPP.Interfaces
{
    public interface IFileService<T> where T : class
    {
        IEnumerable<T> Load(string filePath);
        void Save(string filePath, IEnumerable<T> contacts);
    }
}
