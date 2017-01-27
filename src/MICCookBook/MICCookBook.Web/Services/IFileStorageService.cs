using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MICCookBook.Web.Services
{
    public interface IFileStorageService
    {
        string StoreFile(HttpPostedFileBase file);
    }
}