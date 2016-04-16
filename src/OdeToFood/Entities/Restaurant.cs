namespace OdeToFood.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format("Welcome to " + Name);
        }
    }
}
