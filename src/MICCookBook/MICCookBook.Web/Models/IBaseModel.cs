using System;

namespace MICCookBook.Web.Models
{
    public interface IBaseModel : IIdentifiable<int>
    {
        int Id { get; set; }
        DateTime CreatedOn { get; set; }
        DateTime ModifiedOn { get; set; }
    }
}