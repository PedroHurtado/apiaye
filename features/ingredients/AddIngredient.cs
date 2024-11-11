using Microsoft.AspNetCore.Mvc;
using webapi.domainpizza;

namespace webapi.features.ingredients
{

    public readonly record struct Request(string name, decimal cost) { }
    public readonly record struct Response(Guid id, string name, decimal cost) { }

    [ApiController]
    [Route("/ingredients")]
    public class AddIngredient : ControllerBase
    {
        private readonly IRepositoryIngredient repositoryIngredient;

        public AddIngredient(IRepositoryIngredient repositoryIngredient){
            this.repositoryIngredient = repositoryIngredient;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Add([FromBody] Request request)
        {
            var ingredient = Ingredient.Create(request.name, request.cost);
            this.repositoryIngredient.Add(ingredient);
            var response = new Response(ingredient.Id, ingredient.Name, ingredient.Cost);
            return StatusCode(StatusCodes.Status201Created, response);
        }
    }
}