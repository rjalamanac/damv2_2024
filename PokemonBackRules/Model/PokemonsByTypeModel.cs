using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PokemonBackRules.Model
{
    public class PokemonsByTypeModel
    {
        public List<PokemonOuter> pokemon { get; set; }
    }
    public class PokemonOuter
    {
        public PokemonInner pokemon { get; set; }
        public int slot { get; set; }
       
    }

    public class PokemonInner
    {
        public string name { get; set; }
        public string url { get; set; }
    }


}
