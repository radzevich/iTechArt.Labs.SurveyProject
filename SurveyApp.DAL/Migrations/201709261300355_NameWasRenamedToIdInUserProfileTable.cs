namespace SurveyApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameWasRenamedToIdInUserProfileTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CompletedSurveys", name: "User_Name", newName: "User_Id");
            RenameColumn(table: "dbo.Surveys", name: "Creator_Name", newName: "Creator_Id");
            RenameColumn(table: "dbo.Surveys", name: "Modifier_Name", newName: "Modifier_Id");
            RenameColumn(table: "dbo.UserProfiles", name: "Name", newName: "Id");
            RenameColumn(table: "dbo.Surveys", name: "UserProfile_Name", newName: "UserProfile_Id");
            RenameIndex(table: "dbo.CompletedSurveys", name: "IX_User_Name", newName: "IX_User_Id");
            RenameIndex(table: "dbo.Surveys", name: "IX_UserProfile_Name", newName: "IX_UserProfile_Id");
            RenameIndex(table: "dbo.Surveys", name: "IX_Creator_Name", newName: "IX_Creator_Id");
            RenameIndex(table: "dbo.Surveys", name: "IX_Modifier_Name", newName: "IX_Modifier_Id");
            RenameIndex(table: "dbo.UserProfiles", name: "IX_Name", newName: "IX_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.UserProfiles", name: "IX_Id", newName: "IX_Name");
            RenameIndex(table: "dbo.Surveys", name: "IX_Modifier_Id", newName: "IX_Modifier_Name");
            RenameIndex(table: "dbo.Surveys", name: "IX_Creator_Id", newName: "IX_Creator_Name");
            RenameIndex(table: "dbo.Surveys", name: "IX_UserProfile_Id", newName: "IX_UserProfile_Name");
            RenameIndex(table: "dbo.CompletedSurveys", name: "IX_User_Id", newName: "IX_User_Name");
            RenameColumn(table: "dbo.Surveys", name: "UserProfile_Id", newName: "UserProfile_Name");
            RenameColumn(table: "dbo.UserProfiles", name: "Id", newName: "Name");
            RenameColumn(table: "dbo.Surveys", name: "Modifier_Id", newName: "Modifier_Name");
            RenameColumn(table: "dbo.Surveys", name: "Creator_Id", newName: "Creator_Name");
            RenameColumn(table: "dbo.CompletedSurveys", name: "User_Id", newName: "User_Name");
        }
    }
}
