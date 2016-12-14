using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kundbolaget.Models.ViewModels
{
    public class JsonFileUploadViewModel
    {
        [Required, FileExtensions(Extensions = "json", ErrorMessage = "Filen måste vara av JSON-format")]
        public HttpPostedFileBase File { get; set; }
    }
}