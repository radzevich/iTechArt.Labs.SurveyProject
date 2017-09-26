namespace SurveyApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdFieldWassAddedToUserProfileTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUserClaims", "UserProfile_Name", "dbo.UserProfiles");
            DropForeignKey("dbo.AspNetUserLogins", "UserProfile_Name", "dbo.UserProfiles");
            DropForeignKey("dbo.AspNetUserRoles", "UserProfile_Name", "dbo.UserProfiles");
            DropIndex("dbo.AspNetUserClaims", new[] { "UserProfile_Name" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserProfile_Name" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserProfile_Name" });
            DropColumn("dbo.UserProfiles", "Email");
            DropColumn("dbo.UserProfiles", "EmailConfirmed");
            DropColumn("dbo.UserProfiles", "PasswordHash");
            DropColumn("dbo.UserProfiles", "SecurityStamp");
            DropColumn("dbo.UserProfiles", "PhoneNumber");
            DropColumn("dbo.UserProfiles", "PhoneNumberConfirmed");
            DropColumn("dbo.UserProfiles", "TwoFactorEnabled");
            DropColumn("dbo.UserProfiles", "LockoutEndDateUtc");
            DropColumn("dbo.UserProfiles", "LockoutEnabled");
            DropColumn("dbo.UserProfiles", "AccessFailedCount");
            DropColumn("dbo.UserProfiles", "UserName");
            DropColumn("dbo.AspNetUserClaims", "UserProfile_Name");
            DropColumn("dbo.AspNetUserLogins", "UserProfile_Name");
            DropColumn("dbo.AspNetUserRoles", "UserProfile_Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUserRoles", "UserProfile_Name", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserLogins", "UserProfile_Name", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserClaims", "UserProfile_Name", c => c.String(maxLength: 128));
            AddColumn("dbo.UserProfiles", "UserName", c => c.String());
            AddColumn("dbo.UserProfiles", "AccessFailedCount", c => c.Int(nullable: false));
            AddColumn("dbo.UserProfiles", "LockoutEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserProfiles", "LockoutEndDateUtc", c => c.DateTime());
            AddColumn("dbo.UserProfiles", "TwoFactorEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserProfiles", "PhoneNumberConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserProfiles", "PhoneNumber", c => c.String());
            AddColumn("dbo.UserProfiles", "SecurityStamp", c => c.String());
            AddColumn("dbo.UserProfiles", "PasswordHash", c => c.String());
            AddColumn("dbo.UserProfiles", "EmailConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserProfiles", "Email", c => c.String());
            CreateIndex("dbo.AspNetUserRoles", "UserProfile_Name");
            CreateIndex("dbo.AspNetUserLogins", "UserProfile_Name");
            CreateIndex("dbo.AspNetUserClaims", "UserProfile_Name");
            AddForeignKey("dbo.AspNetUserRoles", "UserProfile_Name", "dbo.UserProfiles", "Name");
            AddForeignKey("dbo.AspNetUserLogins", "UserProfile_Name", "dbo.UserProfiles", "Name");
            AddForeignKey("dbo.AspNetUserClaims", "UserProfile_Name", "dbo.UserProfiles", "Name");
        }
    }
}
