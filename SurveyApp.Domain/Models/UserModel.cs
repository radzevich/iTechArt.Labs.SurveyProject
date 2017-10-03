﻿using Microsoft.AspNet.Identity.EntityFramework;

namespace SurveyApp.BLL.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }

        public CreateSurveyServiceModel[] CreatedSurveys { get; set; }
    }
}
