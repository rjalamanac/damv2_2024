using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_FirstAPP.DTO;
using WPF_FirstAPP.Utils;


namespace WPF_FirstAPP.Models
{
    public class StackPanelItemModel
    {
        public string ImagePath { get; set; }
        public string Text { get; set; }

        public static StackPanelItemModel CreateModelFromDTO(LibroDTO libroDTO)
        {
            return new StackPanelItemModel
            {
                ImagePath = Constants.HALLOWEEN_URL_PATH,
                Text = $"{libroDTO.Titulo}: {libroDTO.NumPaginas}"
            };
        }
    }
}
