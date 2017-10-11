using System.Collections.Generic;
using AutoMapper;
using SurveyApp.BLL.Models;
using SurveyApp.BLL.Models.common;
using SurveyApp.DAL.EntityModels;

namespace SurveyApp.BLL.Configs.AutoMapperResolvers
{
    public class UpPageListResolver : IValueResolver<SurveyBaseDataModel, UploadSurveyServiceModel, PageServiceModel[]>
    {
        public PageServiceModel[] Resolve(SurveyBaseDataModel source, UploadSurveyServiceModel destination, PageServiceModel[] destMember,
            ResolutionContext context)
        {
            PageServiceModel[] pages = Mapper.Map<PageServiceModel[]>(source.Pages);

            return pages;
        }
    }
}