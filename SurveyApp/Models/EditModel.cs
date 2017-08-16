using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SurveyApp.Models
{
    public class EditModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Registrated { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Role { get; set; }
    }
}