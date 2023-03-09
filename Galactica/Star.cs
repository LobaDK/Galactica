namespace Galactica
{
    enum Startype { YellowDwarf, White, BlueNeutron, RedGiant }
    internal class Star : SpaceObject
    {
        public Startype Type { get; set; }
        public double TemperatureInKelvin { get; set; }
        public List<Planet> Planets { get; set; } = new List<Planet>();

        public override (int, int) Position { get; set; } = new (0, 0);
    }
}
