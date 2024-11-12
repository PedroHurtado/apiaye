using Microsoft.AspNetCore.Mvc;

namespace webapi.features.ingredients{

    public readonly record struct UpdateIngredientRequest(string name, decimal cost) { }
    [ApiController]
    public class UpdateIngredient:ControllerBase{
        private readonly IRepositoryIngredient repositoryIngredient;


        public UpdateIngredient(IRepositoryIngredient repositoryIngredient){
            this.repositoryIngredient = repositoryIngredient;
        }

        [HttpPut("/ingredients/{id}")]
        public IActionResult Update(Guid id, [FromBody]UpdateIngredientRequest request) { 
            var ingredient = repositoryIngredient.Get(id);
            if(ingredient == null){
                return NotFound();
            }
            ingredient.Update(request.name, request.cost);
            return NoContent();
        }
    }
}
