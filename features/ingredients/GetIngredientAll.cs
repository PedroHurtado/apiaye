using Microsoft.AspNetCore.Mvc;

namespace webapi.features.ingredients{

    public readonly record struct ReposeIngredintAll(Guid id, string name, decimal cost) { }
    public class Query{
        public required string Name {get;set;}
        public int Page {get;set;}
        public int Size {get;set;}
    }
    
    //[Route("/ingredients")]
    [ApiController]
    public class GetIngredientAll: ControllerBase{
        private readonly IRepositoryIngredient repositoryIngredient;
        public GetIngredientAll(IRepositoryIngredient repositoryIngredient){
            this.repositoryIngredient = repositoryIngredient;
        }
        [HttpGet("/ingredients")]
        public IActionResult getAll([FromQuery] Query query, [FromHeader(Name = "X-Dni")] string dni ){            
            
            Console.WriteLine(query);
            Console.WriteLine(dni);
            return Ok(
                repositoryIngredient.GetAll().Select(i=>new ReposeIngredintAll(
                    i.Id,i.Name,i.Cost
                ))
            );
        }
    }
}