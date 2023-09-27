namespace OrangesAndChocolateB.Models
{
    
    public class Recipe
    {
        public int ID { get; }
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public string Directions { get; set; }
        public bool isActive { get; set; }
        public string CreatorUsername { get; set; }

        public Recipe()
        {
            Ingredients = new List<Ingredient>();
        }

    }
}
