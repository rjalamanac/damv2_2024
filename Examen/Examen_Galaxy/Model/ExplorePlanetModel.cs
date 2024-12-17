using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Controls;
using Examen_Galaxy.Constants;
using Examen_Galaxy.DTO;

namespace Examen_Galaxy.Model
{
    public class ExplorePlanetModel
    {
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Distance { get; set; }
        public string Atmosphere { get; set; }
        public string Temperature { get; set; }

        internal static ExplorePlanetModel CreateModelFromDTO(PlanetaDTO planeta)
        {
            return new ExplorePlanetModel
            {
                ImagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources",
                Constantes.PLANETAS_POSIBLES.Find(x => (planeta.ImageName + Constantes.IMAGES_EXTENSION) == x) ?? Constantes.PATH_IMAGE_NOT_FOUND),
                Name = planeta.Nombre,
                Type = planeta.Tipo,
                Distance = $"{planeta.Distancia} light years",
                Atmosphere = planeta.Atmosfera,
                Temperature = $"{planeta.Temperatura}ºC"
            };
        }
    }
}
