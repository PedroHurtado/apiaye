using Microsoft.AspNetCore.Mvc;

namespace webapi.features.ingredients{

    
    //[Route("/ingredients")]
    [ApiController]
    public class GetIngredient: ControllerBase{
        private readonly IRepositoryIngredient repositoryIngredient;
        public GetIngredient(IRepositoryIngredient repositoryIngredient){
            this.repositoryIngredient = repositoryIngredient;
        }
        [HttpGet("ingredients/{id}")]
        public IActionResult get(Guid id){
            var ingredient = repositoryIngredient.Get(id);
            if(ingredient ==null){
                return NotFound();
            }            
            return Ok(ingredient);
        }
    }
}