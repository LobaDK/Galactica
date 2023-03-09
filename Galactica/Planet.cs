namespace Galactica
{
    enum PlanetType{ Terrestial, Giant, Dwarf, Gas_Giant }
    internal class Planet : SpaceObject
    {
        public PlanetType Type { get; set; }
        public int DiameterInMeters { get; set; }
        public int RotationalPeriodInHours { get; set; }
        public int OrbitalPeriodInDays { get; set; }
        public List<Moon> Moons { get; set; } = new List<Moon>();

        public double Distance()
        {
            return Math.Sqrt((Position.Item1 ^ 2) + (Position.Item2 ^ 2));
        }
    }
}
