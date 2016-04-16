namespace OdeToFood.Entities
{
    public enum CuisineType
    {
        None = 0,
        Italian,
        French,
        American   
    }

    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }

        public override string ToString()
        {
            return string.Format("Welcome to " + Name);
        }
    }
}
