namespace webapi.domainpizza{
    public class Ingredient{
        public Guid Id {get;private set;}
        public string Name {get;private set;}
        public decimal Cost {get;private set;}

        protected Ingredient(Guid id, string name, decimal cost){
            Id = id;
            Name = name;
            Cost = cost;
        }
        public void Update(string name, decimal cost){
            Name = name;
            Cost = cost;
        }
        public static Ingredient Create(string name, decimal cost){
            return new Ingredient(Guid.NewGuid(), name,cost);            
        }
    }

    
}