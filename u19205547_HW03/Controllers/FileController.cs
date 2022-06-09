using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using u19205547_HW03.Models;

namespace u19205547_HW03.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Files()
        {
            //retrieve files
            string docFile = Server.MapPath("~/App_Data/Media/Documents/");
            //create array
            string[] FilePath = Directory.GetFiles(docFile);

            //create list
            List<FileModel> myFiles = new List<FileModel>();

            foreach (string file in FilePath)
            {
                myFiles.Add(new FileModel { FileName = Path.GetFileName(file) });
            }

            //return list
            return View(myFiles);
        }

        //file result = sends binary file content
        public FileResult DownloadFile(string _fileName)//receive the file name
        {
            //access file path
            string docPath = Server.MapPath("~/App_Data/Media/Documents/") + _fileName;

            //read file contents into binary array
            byte[] fileByteArr = System.IO.File.ReadAllBytes(docPath);

            //return file (file content, content type, file destination)
            return File(fileByteArr, "application/octet-stream", _fileName);       
        }

        public ActionResult DeleteFile(string _fileName) //receive file name/destination
        {
            //access path
            string path = Server.MapPath("~/App_Data/Media/Documents/") + _fileName;

            //delete file
            System.IO.File.Delete(path);

            return RedirectToAction("Files");

        }
    }
}