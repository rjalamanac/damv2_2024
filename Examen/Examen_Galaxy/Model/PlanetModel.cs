using Examen_Galaxy.Constants;
using Examen_Galaxy.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Galaxy.Model
{
    public class PlanetModel
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public string PlanetName { get; set; }

        public static List<string> PlanetasPosibles = new List<string>()
        {
            $"{Constantes.RESOURCES_PATH}Planet_1{Constantes.IMAGES_EXTENSION}",
            $"{Constantes.RESOURCES_PATH}Planet_2{Constantes.IMAGES_EXTENSION}",
        };


        internal static PlanetModel CreateModelFromDTO(PlanetaDTO planeta)
        {
            string imagePlaneta = Constantes.RESOURCES_PATH + planeta.Nombre + Constantes.IMAGES_EXTENSION;
            return new PlanetModel
            {
                Id= planeta.Id,
                PlanetName = planeta.Nombre,
                ImagePath = PlanetasPosibles.FirstOrDefault(x=>planeta.ImageName==x) ?? Constantes.PATH_IMAGE_NOT_FOUND
            };
        }
    }

}
