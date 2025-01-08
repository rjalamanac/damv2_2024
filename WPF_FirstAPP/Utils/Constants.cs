using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_FirstAPP.Utils
{
    public static class Constants
    {
        #region Math
        public const string Mas = "+";
        public const string Menos = "-";
        public const string Por = "x";
        public const string Division = "÷";
        public const string Resultado = "Resultado";
        public const string Pi = "π";
        #endregion

        #region WPF_Views
        public const int MAX_NUMBER_ITEMS_STACK_PANEL = 15;
        public const int MIN_NUMBER_ITEMS_STACK_PANEL = 5;
        public const string HALLOWEEN_URL_PATH = "/Resources/Halloween.png";
        public const string JSON_FILTER = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
        #endregion

        #region API Url
        public const string BASE_URL = "http://localhost:5072/api/";
        public const string LOGIN_PATH = "users";
        public const string LIBROS_PATH = "libro";
        #endregion




    }
}
