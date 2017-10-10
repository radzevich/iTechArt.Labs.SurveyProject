namespace SurveyApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SurveyAndSurveyTemplateEntitiesWereInheretedFromSurveyBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnswerDataModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(maxLength: 512),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuestionDataModels", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.QuestionDataModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeId = c.Int(nullable: false),
                        IsRequired = c.Boolean(nullable: false),
                        Text = c.String(maxLength: 1024),
                        SurveyId = c.Int(),
                        PageId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PageDataModels", t => t.PageId)
                .ForeignKey("dbo.SurveyBaseDataModels", t => t.SurveyId)
                .Index(t => t.SurveyId)
                .Index(t => t.PageId);
            
            CreateTable(
                "dbo.PageDataModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 256),
                        SurveyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SurveyBaseDataModels", t => t.SurveyId, cascadeDelete: true)
                .Index(t => t.SurveyId);
            
            CreateTable(
                "dbo.SurveyBaseDataModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 256),
                        CreatorId = c.String(maxLength: 128),
                        CreationTime = c.DateTime(nullable: false),
                        ModifierId = c.String(maxLength: 128),
                        ModificationTime = c.DateTime(nullable: false),
                        IsAnonymous = c.Boolean(nullable: false),
                        IsRandomQuestionOrder = c.Boolean(nullable: false),
                        ShowPagesNumbers = c.Boolean(nullable: false),
                        ShowQuestionsNumbers = c.Boolean(nullable: false),
                        ShowProgressBar = c.Boolean(nullable: false),
                        MarkRequiredFields = c.Boolean(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        UserProfile_Id = c.String(maxLength: 128),
                        UserProfile_Id1 = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_Id)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_Id1)
                .ForeignKey("dbo.UserProfiles", t => t.CreatorId)
                .ForeignKey("dbo.UserProfiles", t => t.ModifierId)
                .Index(t => t.CreatorId)
                .Index(t => t.ModifierId)
                .Index(t => t.UserProfile_Id)
                .Index(t => t.UserProfile_Id1);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.CompletedSurveys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SurveyId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SurveyBaseDataModels", t => t.SurveyId, cascadeDelete: true)
                .ForeignKey("dbo.UserProfiles", t => t.User_Id)
                .Index(t => t.SurveyId)
                .Index(t => t.User_Id);
            
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
                .ForeignKey("dbo.QuestionDataModels", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.CompletedSurveyId)
                .Index(t => t.QuestionId);
            
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
            DropForeignKey("dbo.QuestionDataModels", "SurveyId", "dbo.SurveyBaseDataModels");
            DropForeignKey("dbo.PageDataModels", "SurveyId", "dbo.SurveyBaseDataModels");
            DropForeignKey("dbo.SurveyBaseDataModels", "ModifierId", "dbo.UserProfiles");
            DropForeignKey("dbo.SurveyBaseDataModels", "CreatorId", "dbo.UserProfiles");
            DropForeignKey("dbo.SurveyBaseDataModels", "UserProfile_Id1", "dbo.UserProfiles");
            DropForeignKey("dbo.SurveyBaseDataModels", "UserProfile_Id", "dbo.UserProfiles");
            DropForeignKey("dbo.CompletedSurveys", "User_Id", "dbo.UserProfiles");
            DropForeignKey("dbo.CompletedSurveys", "SurveyId", "dbo.SurveyBaseDataModels");
            DropForeignKey("dbo.ReceivedAnswers", "QuestionId", "dbo.QuestionDataModels");
            DropForeignKey("dbo.ReceivedAnswers", "CompletedSurveyId", "dbo.CompletedSurveys");
            DropForeignKey("dbo.UserProfiles", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.QuestionDataModels", "PageId", "dbo.PageDataModels");
            DropForeignKey("dbo.AnswerDataModels", "QuestionId", "dbo.QuestionDataModels");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ReceivedAnswers", new[] { "QuestionId" });
            DropIndex("dbo.ReceivedAnswers", new[] { "CompletedSurveyId" });
            DropIndex("dbo.CompletedSurveys", new[] { "User_Id" });
            DropIndex("dbo.CompletedSurveys", new[] { "SurveyId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.UserProfiles", new[] { "Id" });
            DropIndex("dbo.SurveyBaseDataModels", new[] { "UserProfile_Id1" });
            DropIndex("dbo.SurveyBaseDataModels", new[] { "UserProfile_Id" });
            DropIndex("dbo.SurveyBaseDataModels", new[] { "ModifierId" });
            DropIndex("dbo.SurveyBaseDataModels", new[] { "CreatorId" });
            DropIndex("dbo.PageDataModels", new[] { "SurveyId" });
            DropIndex("dbo.QuestionDataModels", new[] { "PageId" });
            DropIndex("dbo.QuestionDataModels", new[] { "SurveyId" });
            DropIndex("dbo.AnswerDataModels", new[] { "QuestionId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ReceivedAnswers");
            DropTable("dbo.CompletedSurveys");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UserProfiles");
            DropTable("dbo.SurveyBaseDataModels");
            DropTable("dbo.PageDataModels");
            DropTable("dbo.QuestionDataModels");
            DropTable("dbo.AnswerDataModels");
        }
    }
}
