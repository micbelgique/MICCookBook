using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MICCookBook.Web.Models
{
    public interface IIdentifiable<T>
    {
        T Id { get; }
    }
}