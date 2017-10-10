using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurveyApp.DAL.EntityModels
{
    public class SurveyTemplateDataModel : SurveyBaseDataModel
    {
        public override int Id { get; set; }
    }
}