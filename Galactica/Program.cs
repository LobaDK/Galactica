using System.Reflection;
namespace Galactica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> planetList = new() { "Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune", "Urmom" };
            Star star = new();

            GenerateStar(star);
            GeneratePlanetsAndMoons(planetList, star);

            ShowPlanets(star);
            Console.ReadKey();

        }

        private static void ShowPlanets(Star star)
        {
            //Loop through each saved planet object
            foreach (object planet in star.Planets)
            {
                //Loop through each property in the planet object
                foreach (PropertyInfo property in planet.GetType().GetProperties())
                {
                    if (property.Name != "Position") Console.WriteLine($"{property.Name}: {property.GetValue(planet)}");
                    else Console.WriteLine($"Planetary position: {planet.ToString()}");

                }
                //Write empty line on each planet object for easier reading
                Console.WriteLine();
            }
        }

        private static void GenerateStar(Star star)
        {
            star.Name = "Sun";
            star.Id = 1;
            star.TemperatureInKelvin = 5.778;
        }

        private static void GeneratePlanetsAndMoons(List<string> planetList, Star star)
        {
            Random random = new();

            //Clear list if items are already present; Technically redundant since there's no loop option, and this is only ever run once
            if (star.Planets.Count != 0) star.Planets.Clear();

            //Loop through each string in the planet list
            foreach (string planet in planetList)
            {
                //Generate planetary data using randomization
                Planet planetObj = new()
                {
                    Id = planetList.IndexOf(planet) +1,
                    Name = planet,
                    DiameterInMeters = random.Next(10_000_000, 50_000_000),
                    OrbitalPeriodInDays = random.Next(69, 690_000),
                    RotationalPeriodInHours = random.Next(9, 6000),
                    Position = (random.Next(5, 100), random.Next(5, 100))
                };

                if (planet == "Earth") planetObj.Moons = new()
                {
                    new Moon
                    {
                        Name = "Luna",
                        Orbiting = planetObj,
                        Position = (random.Next(1, 3), 
                        random.Next(1, 3)),
                        DiameterInMeters = random.Next(1_500, 6_000),
                        OrbitalPeriodInDays = random.Next(1, 8),
                        RotationalPeriodInHours = random.Next(0, 16)
                    } 
                };
                //Add the rest of the moons

                //Check planet name and apply correct PlanetType enum
                if (planet is "Mercury" or "Venus" or "Earth" or "Mars") planetObj.Type = PlanetType.Terrestial;
                else if (planet is "Jupiter" or "Saturn" or "Uranus" or "Neptune") planetObj.Type = PlanetType.Gas_Giant;
                else if (planet == "Urmom") planetObj.Type = PlanetType.Giant;
                star.Planets.Add(planetObj);
            }
        }
    }
}