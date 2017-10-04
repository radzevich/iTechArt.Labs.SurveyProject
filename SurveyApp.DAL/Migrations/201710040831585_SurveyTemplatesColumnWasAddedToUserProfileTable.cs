namespace SurveyApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SurveyTemplatesColumnWasAddedToUserProfileTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SurveyTemplateDataModels", "UserProfile_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.SurveyTemplateDataModels", "UserProfile_Id");
            AddForeignKey("dbo.SurveyTemplateDataModels", "UserProfile_Id", "dbo.UserProfiles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SurveyTemplateDataModels", "UserProfile_Id", "dbo.UserProfiles");
            DropIndex("dbo.SurveyTemplateDataModels", new[] { "UserProfile_Id" });
            DropColumn("dbo.SurveyTemplateDataModels", "UserProfile_Id");
        }
    }
}
