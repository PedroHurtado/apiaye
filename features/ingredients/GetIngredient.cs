using Microsoft.AspNetCore.Mvc;

namespace webapi.features.ingredients{

    public readonly record struct ResponseIngredient(Guid id, string name, decimal cost) { }
    
    //[Route("/ingredients")]
    [ApiController]
    public class GetIngredient: ControllerBase{
        private readonly IRepositoryIngredient repositoryIngredient;
        public GetIngredient(IRepositoryIngredient repositoryIngredient){
            this.repositoryIngredient = repositoryIngredient;
        }
        [HttpGet("/ingredients/{id}")]
        public IActionResult get(Guid id){
            var ingredient = repositoryIngredient.Get(id);
            if(ingredient ==null){
                return NotFound();
            }            
            var response = new ResponseIngredient(ingredient.Id, ingredient.Name,ingredient.Cost);
            return Ok(response);
        }
    }
}