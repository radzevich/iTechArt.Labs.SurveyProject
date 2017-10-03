namespace SurveyApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PageIdColumnWasAddedInQuestionTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Pages", newName: "PageDataModels");
            RenameColumn(table: "dbo.QuestionDataModels", name: "Page_Id", newName: "PageId");
            RenameIndex(table: "dbo.QuestionDataModels", name: "IX_Page_Id", newName: "IX_PageId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.QuestionDataModels", name: "IX_PageId", newName: "IX_Page_Id");
            RenameColumn(table: "dbo.QuestionDataModels", name: "PageId", newName: "Page_Id");
            RenameTable(name: "dbo.PageDataModels", newName: "Pages");
        }
    }
}
