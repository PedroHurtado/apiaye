using webapi.core;

namespace webapi.domainpizza
{
    public class Pizza : EntityBase
    {

        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Url { get; private set; }
        private readonly ISet<Ingredient> ingredients = new HashSet<Ingredient>();

        protected Pizza(Guid id, string name, string description, string url) : base(id)
        {
            Name = name;
            Description = description;
            Url = url;
        }

        public void Update(string name, string description, string url)
        {
            Name = name;
            Description = description;
            Url = url;
        }
        public void AddIngredient(Ingredient ingredient)
        {
            ingredients.Add(ingredient);
        }
        public void RemoveIngredient(Ingredient ingredient)
        {
            ingredients.Remove(ingredient);
        }

        public decimal Price
        {
            get
            {
                //return ingredients.Select(i=>i.Cost).Aggregate(0M,(a,v)=>a+v) * 1.2M;
                var total = 0M;
                foreach (var ingredient in ingredients)
                {
                    total += ingredient.Cost;
                }
                return total * 1.2M;

            }
        }

        public List<Ingredient> Ingredients => ingredients.ToList();
        public static Pizza Create(string name, string description, string url, IEnumerable<Ingredient> ingredients)
        {
            var pizza = new Pizza(Guid.NewGuid(), name, description, url);
            foreach (var ingredient in ingredients)
            {
                pizza.ingredients.Add(ingredient);
            }
            return pizza;
        }

    }
}