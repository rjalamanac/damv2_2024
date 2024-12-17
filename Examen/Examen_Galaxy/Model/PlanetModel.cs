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

        internal static PlanetModel CreateModelFromDTO(PlanetaDTO planeta)
        {
            return new PlanetModel
            {
                Id = planeta.Id,
                PlanetName = planeta.Nombre,
                ImagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources",
                Constantes.PLANETAS_POSIBLES.Find(x => (planeta.ImageName + Constantes.IMAGES_EXTENSION) == x) ?? Constantes.PATH_IMAGE_NOT_FOUND),
            };
        }
    }

}
