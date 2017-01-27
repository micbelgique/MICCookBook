using System;
using System.IO;
using System.Web;

namespace MICCookBook.Web.Services
{
    public class LocalFileStorageService : IFileStorageService
    {
        private readonly HttpServerUtilityBase _httpServerUtilityBase;

        public LocalFileStorageService(HttpServerUtilityBase httpServerUtilityBase)
        {
            _httpServerUtilityBase = httpServerUtilityBase;
        }

        public string StoreFile(HttpPostedFileBase file)
        {
            var partialPath = "/content/img/recipes/";
            var filerName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var folderPath = Path.Combine(partialPath, filerName);
            var fullPath = _httpServerUtilityBase.MapPath("~" + folderPath);
            file.SaveAs(fullPath);
            return folderPath;
        }
    }
}