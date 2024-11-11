using Microsoft.AspNetCore.Mvc;
using webapi.domainpizza;

namespace webapi.features.ingredients{

    public readonly record struct Request(string name,decimal cost){}
    public readonly record struct Response(Guid id, string name,decimal cost){}

    [ApiController]
    [Route("/ingredients")]
    public class AddIngredient:ControllerBase{
        

        [HttpPost]
        public Response Add([FromBody]Request request){
            var ingredient = Ingredient.Create(request.name,request.cost);
            return new Response(ingredient.Id, ingredient.Name, ingredient.Cost);
        }
    }
}