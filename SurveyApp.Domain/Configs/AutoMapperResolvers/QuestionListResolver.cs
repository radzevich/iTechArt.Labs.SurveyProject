using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SurveyApp.BLL.Models;
using SurveyApp.DAL.EntityModels;

namespace SurveyApp.BLL.Configs.AutoMapperResolvers
{
    public class QuestionListResolver : IValueResolver<CreatedSurveyServiceModel, SurveyDataModel, ICollection<QuestionDataModel>>
    {
        public ICollection<QuestionDataModel> Resolve(CreatedSurveyServiceModel source, SurveyDataModel destination, ICollection<QuestionDataModel> destMember,
            ResolutionContext context)
        {
            List<QuestionDataModel> questions = (from question in
                                                    from page in source.Pages
                                                    select page.Questions
                                                 select context.Mapper.Map<QuestionDataModel>(question))
                                                 .ToList();

            foreach (var question in questions)
            {
                question.Survey = destination;
            }
            
            return questions;
        }
    }
}