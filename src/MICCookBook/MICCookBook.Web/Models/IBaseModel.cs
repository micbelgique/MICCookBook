using System;

namespace MICCookBook.Web.Models
{
    public interface IBaseModel : IIdentifiable<int>
    {
        DateTime CreatedOn { get; set; }
        DateTime ModifiedOn { get; set; }
    }
}