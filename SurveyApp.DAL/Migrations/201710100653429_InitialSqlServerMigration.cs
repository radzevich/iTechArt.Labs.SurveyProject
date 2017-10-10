namespace SurveyApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSqlServerMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SurveyDataModels", "IsAnonymous", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyDataModels", "IsRandomQuestionOrder", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyDataModels", "ShowPagesNumbers", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyDataModels", "ShowQuestionsNumbers", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyDataModels", "ShowProgressBar", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyDataModels", "MarkRequiredFields", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyTemplateDataModels", "IsAnonymous", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyTemplateDataModels", "IsRandomQuestionOrder", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyTemplateDataModels", "ShowPagesNumbers", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyTemplateDataModels", "ShowQuestionsNumbers", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyTemplateDataModels", "ShowProgressBar", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyTemplateDataModels", "MarkRequiredFields", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SurveyTemplateDataModels", "MarkRequiredFields");
            DropColumn("dbo.SurveyTemplateDataModels", "ShowProgressBar");
            DropColumn("dbo.SurveyTemplateDataModels", "ShowQuestionsNumbers");
            DropColumn("dbo.SurveyTemplateDataModels", "ShowPagesNumbers");
            DropColumn("dbo.SurveyTemplateDataModels", "IsRandomQuestionOrder");
            DropColumn("dbo.SurveyTemplateDataModels", "IsAnonymous");
            DropColumn("dbo.SurveyDataModels", "MarkRequiredFields");
            DropColumn("dbo.SurveyDataModels", "ShowProgressBar");
            DropColumn("dbo.SurveyDataModels", "ShowQuestionsNumbers");
            DropColumn("dbo.SurveyDataModels", "ShowPagesNumbers");
            DropColumn("dbo.SurveyDataModels", "IsRandomQuestionOrder");
            DropColumn("dbo.SurveyDataModels", "IsAnonymous");
        }
    }
}
