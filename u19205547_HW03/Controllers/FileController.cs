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
            //access directory to get file and their paths
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/App_Data/Media/Documents/"));

            //create list
            List<FileModel> myFiles = new List<FileModel>();

            foreach (string filePath in filePaths)
            {
                myFiles.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }
            return View(myFiles);
        }

        //file result = sends binary file content
        public FileResult DownloadFile(string _fileName)//receive the file name(destination)
        {
            //access file path
            string fPath = Server.MapPath("~/App_Data/Media/Documents/") + _fileName;

            //read file contents into binary array
            byte[] fileByteArr = System.IO.File.ReadAllBytes(fPath);

            //return file (file content, content type, file destination)
            return File(fileByteArr, "application/octet-stream", _fileName);       
        }

        public ActionResult DeleteFile(string _fileName) //receive file name/destination
        {
            //create path
            string path = Server.MapPath("~/App_Data/Media/Documents/") + _fileName;

            //open and read byte array ??
            //byte[] bytesArr = System.IO.File.ReadAllBytes(path);

            //delete file
            System.IO.File.Delete(path);

            return RedirectToAction("Files");

        }
    }
}