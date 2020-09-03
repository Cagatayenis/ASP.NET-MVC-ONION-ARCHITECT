using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YemekSepeti.WebUI.Models
{
    public enum FolderPath
    {
        Meal,
        User,
        Restaurant
    }
    public static class FxFunction
    {
        public static string ImageUpload(HttpPostedFileBase resim, FolderPath folderPath, out bool isCompleted)
        {
            string errorText = null;
            if (resim != null)
            {
                if (resim.ContentLength <= 2097152)
                {
                    if (resim.ContentType.Contains("image"))
                    {
                        string uploadPath = $"~/Content/uploads/{ folderPath.ToString()}/{Guid.NewGuid().ToString().Replace('-', '_').ToLower()}.{resim.ContentType.Split('/')[1]}";
                        resim.SaveAs(HttpContext.Current.Server.MapPath(uploadPath));
                        isCompleted = true;
                        return uploadPath;
                    }
                    else
                    {
                        errorText = "Lütfen sadece resim giriniz.";
                    }
                }
                else
                {
                    errorText = "Seçtiğiniz resim 2MBı geçmesin.";
                }
            }
            else
            {
                errorText = "Bir resim seçin.";
            }

            isCompleted = false;
            return errorText;
        }
    }
}