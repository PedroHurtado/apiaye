using webapi.domainpizza;

public interface IRepositoryIngredient{
    Ingredient? Get(Guid id);
    void Add(Ingredient ingredient);
    void Update(Ingredient ingredient);
    void Delete(Ingredient ingredient);
    IEnumerable<Ingredient> GetAll();
}