namespace SurveyApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OneToManyDependencyWasEstablishedBetweenSurveyAndPageEntities : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PageDataModels", "SurveId", c => c.Int(nullable: false));
            AddColumn("dbo.PageDataModels", "Survey_Id", c => c.Int());
            CreateIndex("dbo.PageDataModels", "Survey_Id");
            AddForeignKey("dbo.PageDataModels", "Survey_Id", "dbo.SurveyDataModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PageDataModels", "Survey_Id", "dbo.SurveyDataModels");
            DropIndex("dbo.PageDataModels", new[] { "Survey_Id" });
            DropColumn("dbo.PageDataModels", "Survey_Id");
            DropColumn("dbo.PageDataModels", "SurveId");
        }
    }
}
