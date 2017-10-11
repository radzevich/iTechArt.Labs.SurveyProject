namespace SurveyApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifierDependencyWasRemovedFromSurveyBaseDataModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SurveyBaseDataModels", "ModifierId", "dbo.UserProfiles");
            DropIndex("dbo.SurveyBaseDataModels", new[] { "ModifierId" });
            DropColumn("dbo.SurveyBaseDataModels", "ModifierId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SurveyBaseDataModels", "ModifierId", c => c.String(maxLength: 128));
            CreateIndex("dbo.SurveyBaseDataModels", "ModifierId");
            AddForeignKey("dbo.SurveyBaseDataModels", "ModifierId", "dbo.UserProfiles", "Id");
        }
    }
}
