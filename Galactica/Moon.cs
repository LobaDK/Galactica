using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galactica
{
    internal sealed class Moon : Planet
    {
        public Planet? Orbiting { get; set; }
        public double Distance(Planet planet)
        {
            return Math.Sqrt((Position.Item1 - planet.Position.Item1) ^ 2 + (Position.Item2 - planet.Position.Item2) ^ 2);
        }
    }
}
