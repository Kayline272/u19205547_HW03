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
        //receive images and return them as a list to the view
        public ActionResult Images()
        {
            //retrieve images
            string imgFile = Server.MapPath("~/App_Data/Media/Images/");
            //store in array
            string[] ImgPath = Directory.GetFiles(imgFile);
            //create and store as list 
            List<FileModel> myImages = new List<FileModel>();

            foreach (string image in ImgPath)
            {
                myImages.Add(new FileModel { FileName = Path.GetFileName(image) });
            }

           // ViewBag.ImgPath = ImgPath;

            //return list to view
            return View(myImages);
        }

        //public ActionResult TestImg()
        //{

        //    return View();
        //}

        //file result = sends binary file content
        public FileResult DownloadFile(string _fileName)//receive the file name(destination)
        {
            //access file path
            string imgFile = Server.MapPath("~/App_Data/Media/Images/") + _fileName;

            //read file contents into binary array
            byte[] ImgByte = System.IO.File.ReadAllBytes(imgFile);

            //return file (file content, content type, file destination)
            return File(ImgByte, "application/octet-stream", _fileName);
        }

        public ActionResult DeleteFile(string _fileName) //receive file name/destination
        {
            //create path
            string imgFile = Server.MapPath("~/App_Data/Media/Images/") + _fileName;

            //delete file
            System.IO.File.Delete(imgFile);

            return RedirectToAction("Images");

        }
    }
}