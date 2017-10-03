namespace SurveyApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeEntityodelsWereRenamed : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AnswerOptions", newName: "AnswerDataModels");
            RenameTable(name: "dbo.Questions", newName: "QuestionDataModels");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.QuestionDataModels", newName: "Questions");
            RenameTable(name: "dbo.AnswerDataModels", newName: "AnswerOptions");
        }
    }
}
