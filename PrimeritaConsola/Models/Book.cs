using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeritaConsola.Models
{
    internal class Book
    {
        public Book()
        {
        }

        public Book(string? autor, string? iSBN, string? titulo, int numPages)
        {
            Autor = autor;
            ISBN = iSBN;
            Titulo = titulo;
            NumPages = numPages;
        }

        public string? Autor {  get; set; }
        public string? ISBN { get; set; }
        public string? Titulo { get; set; }
        public int NumPages { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Book book &&
                   Autor == book.Autor &&
                   ISBN == book.ISBN &&
                   Titulo == book.Titulo &&
                   NumPages == book.NumPages;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Autor, ISBN, Titulo, NumPages);
        }
    }
}
