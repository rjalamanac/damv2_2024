﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Galaxy.Constants
{
    internal class Constantes
    {
        internal const string BASE_URL = "http://localhost:5000/";
        internal const string PLANET_RESOURCE = "Planeta";
        internal const string RESOURCES_PATH = "/Resources/";
        internal const string IMAGES_EXTENSION = ".jpg";
        internal const string PATH_IMAGE_NOT_FOUND = "Not_found.png";
        internal static List<string> PLANETAS_POSIBLES = new List<string>()
        {
            "Planet_1.jpg",
            "Planet_2.jpg"
        };

    }
}
