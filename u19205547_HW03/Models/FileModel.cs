using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u19205547_HW03.Models
{
    public class FileModel
    {
        public string FileName { get; set; }

        //the httpPostedfilebase allows views to communicated and post the data from the view to the server
        //define enctype = "multipart/form-data" in form action otherwise file value will be null in controller 
        public HttpPostedFileBase File { get; set; }

       
    }
}