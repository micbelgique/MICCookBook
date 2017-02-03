using MICCookBook.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace MICCookBook.Web.Controllers.API
{
    public class RecipesController : BaseApiController
    {

        // GET api/<controller>
        public async Task<List<Recipe>> Get()
        {
            return await UnitOfWork.Recipes.GetAllAsync();
        }

        // GET api/<controller>/5
        public async Task<Recipe> Get(int id)
        {
            return await UnitOfWork.Recipes.GetById(id);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}