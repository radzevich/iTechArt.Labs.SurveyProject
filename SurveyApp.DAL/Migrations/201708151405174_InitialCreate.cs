namespace SurveyApp.DAL.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Users",
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
                        UserId = c.String(maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
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
                .ForeignKey("dbo.Surveys", t => t.SurveyId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id)
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
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.CompletedSurveyId)
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
                "dbo.Pages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        User_Id = c.String(maxLength: 128),
                        Creator_Id = c.String(maxLength: 128),
                        Modifier_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Users", t => t.Creator_Id)
                .ForeignKey("dbo.Users", t => t.Modifier_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Creator_Id)
                .Index(t => t.Modifier_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Id", "dbo.Users");
            DropForeignKey("dbo.Questions", "SurveyId", "dbo.Surveys");
            DropForeignKey("dbo.Surveys", "Modifier_Id", "dbo.Users");
            DropForeignKey("dbo.Surveys", "Creator_Id", "dbo.Users");
            DropForeignKey("dbo.Surveys", "User_Id", "dbo.Users");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.CompletedSurveys", "User_Id", "dbo.Users");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.CompletedSurveys", "SurveyId", "dbo.Surveys");
            DropForeignKey("dbo.ReceivedAnswers", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Questions", "Page_Id", "dbo.Pages");
            DropForeignKey("dbo.AnswerOptions", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.ReceivedAnswers", "CompletedSurveyId", "dbo.CompletedSurveys");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUsers", new[] { "Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Surveys", new[] { "Modifier_Id" });
            DropIndex("dbo.Surveys", new[] { "Creator_Id" });
            DropIndex("dbo.Surveys", new[] { "User_Id" });
            DropIndex("dbo.AnswerOptions", new[] { "QuestionId" });
            DropIndex("dbo.Questions", new[] { "Page_Id" });
            DropIndex("dbo.Questions", new[] { "SurveyId" });
            DropIndex("dbo.ReceivedAnswers", new[] { "QuestionId" });
            DropIndex("dbo.ReceivedAnswers", new[] { "CompletedSurveyId" });
            DropIndex("dbo.CompletedSurveys", new[] { "User_Id" });
            DropIndex("dbo.CompletedSurveys", new[] { "SurveyId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.Users", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Surveys");
            DropTable("dbo.Pages");
            DropTable("dbo.AnswerOptions");
            DropTable("dbo.Questions");
            DropTable("dbo.ReceivedAnswers");
            DropTable("dbo.CompletedSurveys");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
