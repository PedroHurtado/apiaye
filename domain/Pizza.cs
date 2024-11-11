using webapi.core;

namespace webapi.domainpizza {
    public class Pizza: EntityBase {
        
        public string Name {get;private set;}
        public string Description {get;private set;}
        public string Url {get;private set;}
        private readonly ISet<Ingredient> Ingredients =  new HashSet<Ingredient>();

        protected Pizza(Guid id, string name, string description, string url): base(id)            
        {            
            Name = name;
            Description = description;
            Url = url;
        }          
        
        public void Update(string name,string description,string url){
            Name = name;
            Description = description;
            Url = url;
        }
        public void AddIngredient(Ingredient ingredient){
            Ingredients.Add(ingredient);
        }
        public void RemoveIngredient(Ingredient ingredient){
            Ingredients.Remove(ingredient);
        }

        public decimal getPrice(){
            
            //return Ingredients.Select(i=>i.Cost).Aggregate(0M,(a,v)=>a+v) * 1.2M;
            
            var total = 0M;
            foreach (var ingredient in Ingredients){
                total += ingredient.Cost;
            }            
            return total * 1.2M;
        }
        public static Pizza Create(string name, string description,string url, IEnumerable<Ingredient> ingredients){
            var pizza = new Pizza(Guid.NewGuid(), name,description,url);
            foreach(var ingredient in ingredients){
                pizza.Ingredients.Add(ingredient);
            }
            return pizza;
        }

    }
}