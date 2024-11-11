using Microsoft.Net.Http.Headers;
using webapi.domainpizza;

namespace webapi.infraestructure{
    public class RepositoryIngredient : IRepositoryIngredient
    {
        private static ISet<Ingredient> ingredients = new HashSet<Ingredient>();

        public void Add(Ingredient ingredient)
        {
            ingredients.Add(ingredient);
        }

        public Ingredient? Get(Guid id)
        {   
            return ingredients.Where(i=>i.Id == id).FirstOrDefault();

        }
    }
}
