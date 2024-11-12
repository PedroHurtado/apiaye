using Microsoft.Net.Http.Headers;
using webapi.core;
using webapi.domainpizza;

namespace webapi.infraestructure{
    public class RepositoryIngredient : IRepositoryIngredient
    {
        private static ISet<Ingredient> ingredients = new HashSet<Ingredient>();

        public void Add(Ingredient ingredient)
        {
            ingredients.Add(ingredient);
        }

        public void Delete(Ingredient ingredient)
        {
             if(ingredients.Contains(ingredient)){
                ingredients.Remove(ingredient);
            }
        }

        public Ingredient Get(Guid id)
        {   
            return ingredients.Where(i=>i.Id == id).OrElseThrow(new NotFoundException());

        }
        public IEnumerable<Ingredient> GetAll()
        {
            return ingredients;
        }

        public void Update(Ingredient ingredient)
        {
            if(ingredients.Contains(ingredient)){
                ingredients.UnionWith([ingredient]);
            }
        }
    }
}
