namespace SurveyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rolesadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Role_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "RoleId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "Role_Id");
            AddForeignKey("dbo.AspNetUsers", "Role_Id", "dbo.AspNetRoles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Role_Id", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUsers", new[] { "Role_Id" });
            DropColumn("dbo.AspNetUsers", "RoleId");
            DropColumn("dbo.AspNetUsers", "Role_Id");
        }
    }
}
