namespace SurveyApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TypeOfIdInSurveyTableChangedToInt : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Surveys", newName: "SurveyDataModels");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.SurveyDataModels", newName: "Surveys");
        }
    }
}
