using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeritaConsola.Models
{
    internal class LibrarySingleton
    {
        private static LibrarySingleton library;
        private List<Book> books;
        private LibrarySingleton() {
            books = new List<Book>();

            books.Add(new Book ()
            {
                ISBN = "121233214",
                Autor = "Rafa"
            }
            );
            books.Add(new Book()
            {
                ISBN = "12FD",
                Autor = "jORGE",
                NumPages= 10
            });
        }

        public static LibrarySingleton GetInstance() 
        {
            if (library == null)
            {
                library= new LibrarySingleton();
            }
            return library;
        }

    }
}
