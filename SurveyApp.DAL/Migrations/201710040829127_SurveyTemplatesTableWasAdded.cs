namespace SurveyApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SurveyTemplatesTableWasAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SurveyTemplateDataModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 256),
                        CreatorId = c.String(maxLength: 128),
                        CreationTime = c.DateTime(nullable: false),
                        ModifierId = c.String(maxLength: 128),
                        ModificationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfiles", t => t.CreatorId)
                .ForeignKey("dbo.UserProfiles", t => t.ModifierId)
                .Index(t => t.CreatorId)
                .Index(t => t.ModifierId);
            
            AddColumn("dbo.QuestionDataModels", "SurveyTemplateDataModel_Id", c => c.Int());
            AddColumn("dbo.PageDataModels", "SurveyTemplateDataModel_Id", c => c.Int());
            CreateIndex("dbo.QuestionDataModels", "SurveyTemplateDataModel_Id");
            CreateIndex("dbo.PageDataModels", "SurveyTemplateDataModel_Id");
            AddForeignKey("dbo.PageDataModels", "SurveyTemplateDataModel_Id", "dbo.SurveyTemplateDataModels", "Id");
            AddForeignKey("dbo.QuestionDataModels", "SurveyTemplateDataModel_Id", "dbo.SurveyTemplateDataModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionDataModels", "SurveyTemplateDataModel_Id", "dbo.SurveyTemplateDataModels");
            DropForeignKey("dbo.PageDataModels", "SurveyTemplateDataModel_Id", "dbo.SurveyTemplateDataModels");
            DropForeignKey("dbo.SurveyTemplateDataModels", "ModifierId", "dbo.UserProfiles");
            DropForeignKey("dbo.SurveyTemplateDataModels", "CreatorId", "dbo.UserProfiles");
            DropIndex("dbo.SurveyTemplateDataModels", new[] { "ModifierId" });
            DropIndex("dbo.SurveyTemplateDataModels", new[] { "CreatorId" });
            DropIndex("dbo.PageDataModels", new[] { "SurveyTemplateDataModel_Id" });
            DropIndex("dbo.QuestionDataModels", new[] { "SurveyTemplateDataModel_Id" });
            DropColumn("dbo.PageDataModels", "SurveyTemplateDataModel_Id");
            DropColumn("dbo.QuestionDataModels", "SurveyTemplateDataModel_Id");
            DropTable("dbo.SurveyTemplateDataModels");
        }
    }
}
