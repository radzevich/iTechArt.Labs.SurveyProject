namespace SurveyApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Identityuseranduserprofilearemixedtogether : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnswerOptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(maxLength: 512),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeId = c.Int(nullable: false),
                        IsRequired = c.Boolean(nullable: false),
                        Text = c.String(maxLength: 1024),
                        SurveyId = c.Int(),
                        Page_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pages", t => t.Page_Id)
                .ForeignKey("dbo.Surveys", t => t.SurveyId)
                .Index(t => t.SurveyId)
                .Index(t => t.Page_Id);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReceivedAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompletedSurveyId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CompletedSurveys", t => t.CompletedSurveyId, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.CompletedSurveyId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.CompletedSurveys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SurveyId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        User_Name = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Surveys", t => t.SurveyId, cascadeDelete: true)
                .ForeignKey("dbo.UserProfiles", t => t.User_Name)
                .Index(t => t.SurveyId)
                .Index(t => t.User_Name);
            
            CreateTable(
                "dbo.Surveys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 256),
                        CreatorId = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        ModifierId = c.Int(nullable: false),
                        ModificationTime = c.DateTime(nullable: false),
                        UserProfile_Name = c.String(maxLength: 128),
                        Creator_Name = c.String(maxLength: 128),
                        Modifier_Name = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_Name)
                .ForeignKey("dbo.UserProfiles", t => t.Creator_Name)
                .ForeignKey("dbo.UserProfiles", t => t.Modifier_Name)
                .Index(t => t.UserProfile_Name)
                .Index(t => t.Creator_Name)
                .Index(t => t.Modifier_Name);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        Id = c.String(),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Name)
                .ForeignKey("dbo.AspNetUsers", t => t.Name)
                .Index(t => t.Name);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        UserProfile_Name = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_Name)
                .Index(t => t.UserId)
                .Index(t => t.UserProfile_Name);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        UserProfile_Name = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_Name)
                .Index(t => t.UserId)
                .Index(t => t.UserProfile_Name);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserProfile_Name = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_Name)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId)
                .Index(t => t.UserProfile_Name);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ReceivedAnswers", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Questions", "SurveyId", "dbo.Surveys");
            DropForeignKey("dbo.Surveys", "Modifier_Name", "dbo.UserProfiles");
            DropForeignKey("dbo.Surveys", "Creator_Name", "dbo.UserProfiles");
            DropForeignKey("dbo.Surveys", "UserProfile_Name", "dbo.UserProfiles");
            DropForeignKey("dbo.AspNetUserRoles", "UserProfile_Name", "dbo.UserProfiles");
            DropForeignKey("dbo.AspNetUserLogins", "UserProfile_Name", "dbo.UserProfiles");
            DropForeignKey("dbo.CompletedSurveys", "User_Name", "dbo.UserProfiles");
            DropForeignKey("dbo.AspNetUserClaims", "UserProfile_Name", "dbo.UserProfiles");
            DropForeignKey("dbo.UserProfiles", "Name", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CompletedSurveys", "SurveyId", "dbo.Surveys");
            DropForeignKey("dbo.ReceivedAnswers", "CompletedSurveyId", "dbo.CompletedSurveys");
            DropForeignKey("dbo.Questions", "Page_Id", "dbo.Pages");
            DropForeignKey("dbo.AnswerOptions", "QuestionId", "dbo.Questions");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "UserProfile_Name" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserProfile_Name" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserProfile_Name" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.UserProfiles", new[] { "Name" });
            DropIndex("dbo.Surveys", new[] { "Modifier_Name" });
            DropIndex("dbo.Surveys", new[] { "Creator_Name" });
            DropIndex("dbo.Surveys", new[] { "UserProfile_Name" });
            DropIndex("dbo.CompletedSurveys", new[] { "User_Name" });
            DropIndex("dbo.CompletedSurveys", new[] { "SurveyId" });
            DropIndex("dbo.ReceivedAnswers", new[] { "QuestionId" });
            DropIndex("dbo.ReceivedAnswers", new[] { "CompletedSurveyId" });
            DropIndex("dbo.Questions", new[] { "Page_Id" });
            DropIndex("dbo.Questions", new[] { "SurveyId" });
            DropIndex("dbo.AnswerOptions", new[] { "QuestionId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UserProfiles");
            DropTable("dbo.Surveys");
            DropTable("dbo.CompletedSurveys");
            DropTable("dbo.ReceivedAnswers");
            DropTable("dbo.Pages");
            DropTable("dbo.Questions");
            DropTable("dbo.AnswerOptions");
        }
    }
}
