using webapi.domainpizza;

public interface IRepositoryIngredient{
    Ingredient? Get(Guid id);
    void Add(Ingredient ingredient);
}