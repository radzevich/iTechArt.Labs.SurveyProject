namespace SurveyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoleIdremoved : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "RoleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "RoleId", c => c.Int(nullable: false));
        }
    }
}
