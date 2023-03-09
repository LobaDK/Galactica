namespace Galactica
{
    internal abstract class SpaceObject
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual (int, int) Position { get; set; }

        public override string ToString()
        {
            return $"({Position.Item1},{Position.Item2})";
        }

    }
}
