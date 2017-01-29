using MICCookBook.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MICCookBook.Web.Controllers.API
{
    public class EvaluationsController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Evaluation> Get()
        {
            var context = new ApplicationDbContext();

            var evaluations = context.Evaluations;

            return evaluations.ToList();
        }

        // GET api/<controller>/5
        public Evaluation Get(int id)
        {
            var context = new ApplicationDbContext();

            var evaluation = context.Evaluations.Find(id);

            return evaluation;
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