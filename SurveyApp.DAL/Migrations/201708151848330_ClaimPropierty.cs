namespace SurveyApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClaimPropierty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Registrated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Registrated");
        }
    }
}
