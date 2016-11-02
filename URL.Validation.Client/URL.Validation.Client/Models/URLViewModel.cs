using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace URL.Validation.Client.Models
{
    public class URLViewModel
    {
        [Required]
        public string URL { get; set; }

        [Required]
        public string RecaptchaResponse { get; set; }
    }
}