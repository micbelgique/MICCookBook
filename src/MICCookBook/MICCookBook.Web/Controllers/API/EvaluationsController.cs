using MICCookBook.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace MICCookBook.Web.Controllers.API
{
    public class EvaluationsController : BaseApiController
    {
        // GET api/<controller>
        public async Task<IEnumerable<Evaluation>> Get()
        {
            return await UnitOfWork.Evaluations.GetAllAsync();
        }

        // GET api/<controller>/5
        public async Task<Evaluation> Get(int id)
        {
            return await UnitOfWork.Evaluations.GetById(id);
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