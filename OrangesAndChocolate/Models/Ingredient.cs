namespace OrangesAndChocolateB.Models
{    
    public enum Unit
    {
        g,
        ml,
        pieces
    }

    public class Ingredient
    {
        public int Id { get; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public Unit Units { get; set; }
        public int RecipieID { get; set; }
        public Recipe Recipe { get; set; }
        public bool isActive { get; set; }

    }
}
