using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace u19205547_HW03.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase File)//receive file and radio button choice
        {
            if (File != null && File.ContentLength > 0) //ensure a file has been uploaded
            {
                //get file name  
                var _fileName = Path.GetFileName(File.FileName);

                //4.1 retrieve the option
               string myFileType = Request.Form["fileType"];
                //4.2 determine which radio button has been checked
                if (myFileType == "doc")
                {
                    //4.3 save option to correct folder on server - create path and combine with file name
                    var _path = Path.Combine(Server.MapPath("~/App_Data/Media/Documents"), _fileName);
                    //save created file
                    File.SaveAs(_path);
                }
                else if (myFileType == "img")
                {
                    //4.3 save option to correct folder on server - create path and combine with file name
                    var _path = Path.Combine(Server.MapPath("~/App_Data/Media/Images"), _fileName);
                    //save created file
                    File.SaveAs(_path);
                }
                else
                {
                    //4.3 save option to correct folder on server - create path and combine with file name
                    var _path = Path.Combine(Server.MapPath("~/App_Data/Media/Videos"), _fileName);
                    //save created file
                    File.SaveAs(_path);
                }
  
            }
           
            //redirect to get action = back to view
            return RedirectToAction("Index");
        }      
        public ActionResult About()
        {
            return View();
        }

    }
}