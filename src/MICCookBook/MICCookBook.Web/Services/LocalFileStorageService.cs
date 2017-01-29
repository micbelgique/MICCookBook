using System;
using System.IO;
using System.Web;

namespace MICCookBook.Web.Services
{
    public class LocalFileStorageService : IFileStorageService
    {
        public string StoreFile(HttpPostedFileBase file)
        {
            var partialPath = "/content/img/recipes/";
            var filerName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var folderPath = Path.Combine(partialPath, filerName);
            var fullPath = HttpRuntime.AppDomainAppPath + folderPath;
            file.SaveAs(fullPath);
            return folderPath;
        }
    }
}