namespace SurveyApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OneToOneLinksInApplicationUserAndUserProfileMakedNotVirtual : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.SurveyDataModels", new[] { "Creator_Id" });
            DropIndex("dbo.SurveyDataModels", new[] { "Modifier_Id" });
            DropColumn("dbo.SurveyDataModels", "CreatorId");
            DropColumn("dbo.SurveyDataModels", "ModifierId");
            RenameColumn(table: "dbo.SurveyDataModels", name: "Creator_Id", newName: "CreatorId");
            RenameColumn(table: "dbo.SurveyDataModels", name: "Modifier_Id", newName: "ModifierId");
            AlterColumn("dbo.SurveyDataModels", "CreatorId", c => c.String(maxLength: 128));
            AlterColumn("dbo.SurveyDataModels", "ModifierId", c => c.String(maxLength: 128));
            CreateIndex("dbo.SurveyDataModels", "CreatorId");
            CreateIndex("dbo.SurveyDataModels", "ModifierId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.SurveyDataModels", new[] { "ModifierId" });
            DropIndex("dbo.SurveyDataModels", new[] { "CreatorId" });
            AlterColumn("dbo.SurveyDataModels", "ModifierId", c => c.Int(nullable: false));
            AlterColumn("dbo.SurveyDataModels", "CreatorId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.SurveyDataModels", name: "ModifierId", newName: "Modifier_Id");
            RenameColumn(table: "dbo.SurveyDataModels", name: "CreatorId", newName: "Creator_Id");
            AddColumn("dbo.SurveyDataModels", "ModifierId", c => c.Int(nullable: false));
            AddColumn("dbo.SurveyDataModels", "CreatorId", c => c.Int(nullable: false));
            CreateIndex("dbo.SurveyDataModels", "Modifier_Id");
            CreateIndex("dbo.SurveyDataModels", "Creator_Id");
        }
    }
}
