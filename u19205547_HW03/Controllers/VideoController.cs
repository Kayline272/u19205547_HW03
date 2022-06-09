using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using u19205547_HW03.Models;

namespace u19205547_HW03.Controllers
{
    public class VideoController : Controller
    {
        // GET: Video
        public ActionResult Videos()
        {
            string[] vidPaths = Directory.GetFiles(Server.MapPath("~/App_Data/Media/Videos/"));

            //create list
            List<FileModel> myVideos = new List<FileModel>();

            foreach (string vidPath in vidPaths)
            {
                myVideos.Add(new FileModel { FileName = Path.GetFileName(vidPath) });
            }
            return View(myVideos);
        }

        //file result = sends binary file content
        public FileResult DownloadFile(string _fileName)//receive the file name(destination)
        {
            //access file path
            string vPath = Server.MapPath("~/App_Data/Media/Videos/") + _fileName;

            //read file contents into binary array
            byte[] vidByteArr = System.IO.File.ReadAllBytes(vPath);

            //return file (file content, content type, file destination)
            return File(vidByteArr, "application/octet-stream", _fileName);
        }

        public ActionResult DeleteFile(string _fileName) //receive file name/destination
        {
            //create path
            string path = Server.MapPath("~/App_Data/Media/Videos/") + _fileName;


            //delete file
            System.IO.File.Delete(path);

            return RedirectToAction("Videos");
        }
    }
}