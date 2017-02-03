using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MICCookBook.Web.Models;

namespace MICCookBook.Web.Repository
{
    public class EvaluationRepository : BaseModelRepository<Evaluation>
    {
        public EvaluationRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}