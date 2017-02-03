using System;

namespace MICCookBook.Web.Models
{
    public interface IBaseModel
    {
        int Id { get; set; }
        DateTime CreatedOn { get; set; }
        DateTime ModifiedOn { get; set; }
    }
}