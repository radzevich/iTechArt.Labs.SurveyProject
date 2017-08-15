using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyApp.Models
{
    public class EditModel
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public DateTime Registrated { get; set; }
        public int SurveyCount { get; set; }
    }
}