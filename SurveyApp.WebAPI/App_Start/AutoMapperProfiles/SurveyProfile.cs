using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using SurveyApp.BLL.Models;
using SurveyApp.WebAPI.Models;

namespace SurveyApp.WebAPI.AutoMapperProfiles
{
    public class SurveyProfile : Profile
    {
        public SurveyProfile()
        {
            CreateMap<CreatedSurveyViewModel, CreatedSurveyServiceModel>();
            CreateMap<SurveyViewModel, UpdatedSurveyServiceModel>();
            CreateMap<UpdatedSurveyServiceModel, SurveyViewModel>();
        }
    }
}