﻿using System.Collections.Generic;
using AutoMapper;
using SurveyApp.BLL.Models;
using SurveyApp.DAL.EntityModels;

namespace SurveyApp.BLL.Configs.AutoMapperResolvers
{
    public class DownPageListResolver : IValueResolver<DownloadSurveyServiceModel, SurveyBaseDataModel, ICollection<PageDataModel>>
    {
        public ICollection<PageDataModel> Resolve(DownloadSurveyServiceModel source, SurveyBaseDataModel destination, ICollection<PageDataModel> destMember,
            ResolutionContext context)
        {
            var pages = new List<PageDataModel>();
            foreach (var sourcePage in source.Pages)
            {
                var pageDataModel = Mapper.Map<PageDataModel>(sourcePage);
                pageDataModel.Survey = destination;
                pages.Add(pageDataModel);          
            }

            return pages;
        }
    }
}