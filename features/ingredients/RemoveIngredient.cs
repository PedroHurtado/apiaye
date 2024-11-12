using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace webapi.features.ingredients
{
    [ApiController]
    public class RemoveIngredient :ControllerBase{
        public readonly IRepositoryIngredient repositoryIngredient;
        public RemoveIngredient(IRepositoryIngredient repositoryIngredient){
            this.repositoryIngredient = repositoryIngredient;
        }
        [HttpDelete("/ingredients/{id}")]
        public ActionResult Delete(Guid id){
            var ingredient = repositoryIngredient.Get(id);
            if (ingredient == null){
                return NotFound();
            }
            repositoryIngredient.Delete(ingredient);
            return NoContent();
        }
    }
}