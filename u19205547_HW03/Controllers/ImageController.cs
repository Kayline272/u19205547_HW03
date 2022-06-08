using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using u19205547_HW03.Models;

namespace u19205547_HW03.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public ActionResult Images()
        {
            //receive images and return them as a list to the view

            //access directory to get file and their paths
            string[] imagePaths = Directory.GetFiles(Server.MapPath("~/App_Data/Media/Images/"));

            //create list
            List<FileModel> myImages = new List<FileModel>();

            foreach (string image in imagePaths)
            {
                myImages.Add(new FileModel { FileName = Path.GetFileName(image) });
            }
            //return the list
            return View(myImages);
        }

        //file result = sends binary file content
        public FileResult DownloadFile(string _fileName)//receive the file name(destination)
        {
            //access file path
            string vPath = Server.MapPath("~/App_Data/Media/Images/") + _fileName;

            //read file contents into binary array
            byte[] imgByteArr = System.IO.File.ReadAllBytes(vPath);

            //return file (file content, content type, file destination)
            return File(imgByteArr, "application/octet-stream", _fileName);
        }

        public ActionResult DeleteFile(string _fileName) //receive file name/destination
        {
            //create path
            string path = Server.MapPath("~/App_Data/Media/Images/") + _fileName;

            //open and read byte array ??
            //byte[] bytesArr = System.IO.File.ReadAllBytes(path);

            //delete file
            System.IO.File.Delete(path);

            return RedirectToAction("Images");

        }
    }
}