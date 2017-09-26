namespace SurveyApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TempId1WasRenamedToNameInUserProfileTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "Name", c => c.String());
            DropColumn("dbo.UserProfiles", "Id1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfiles", "Id1", c => c.String());
            DropColumn("dbo.UserProfiles", "Name");
        }
    }
}
