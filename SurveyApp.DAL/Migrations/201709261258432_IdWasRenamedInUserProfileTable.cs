namespace SurveyApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdWasRenamedInUserProfileTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "Id1", c => c.String());
            DropColumn("dbo.UserProfiles", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfiles", "Id", c => c.String());
            DropColumn("dbo.UserProfiles", "Id1");
        }
    }
}
