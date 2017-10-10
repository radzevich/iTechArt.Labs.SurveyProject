namespace SurveyApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SurveIdColumnWasRenamedToSurveyIdInPagesTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PageDataModels", "Survey_Id", "dbo.SurveyDataModels");
            DropIndex("dbo.PageDataModels", new[] { "Survey_Id" });
            RenameColumn(table: "dbo.PageDataModels", name: "Survey_Id", newName: "SurveyId");
            AlterColumn("dbo.PageDataModels", "SurveyId", c => c.Int(nullable: false));
            CreateIndex("dbo.PageDataModels", "SurveyId");
            AddForeignKey("dbo.PageDataModels", "SurveyId", "dbo.SurveyDataModels", "Id", cascadeDelete: true);
            DropColumn("dbo.PageDataModels", "SurveId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PageDataModels", "SurveId", c => c.Int(nullable: false));
            DropForeignKey("dbo.PageDataModels", "SurveyId", "dbo.SurveyDataModels");
            DropIndex("dbo.PageDataModels", new[] { "SurveyId" });
            AlterColumn("dbo.PageDataModels", "SurveyId", c => c.Int());
            RenameColumn(table: "dbo.PageDataModels", name: "SurveyId", newName: "Survey_Id");
            CreateIndex("dbo.PageDataModels", "Survey_Id");
            AddForeignKey("dbo.PageDataModels", "Survey_Id", "dbo.SurveyDataModels", "Id");
        }
    }
}
