namespace UniversityTestingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UniversityModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 3),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentFinishedTestAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        TestId = c.Int(nullable: false),
                        TestQuestionId = c.Int(nullable: false),
                        StudentAnswer = c.String(nullable: false, maxLength: 1),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Tests", t => t.TestId, cascadeDelete: true)
                .ForeignKey("dbo.TestQuestions", t => t.TestQuestionId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.TestId)
                .Index(t => t.TestQuestionId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 255),
                        LastName = c.String(nullable: false, maxLength: 255),
                        GroupId = c.Int(nullable: false),
                        FacultyId = c.Int(nullable: false),
                        IsFormFilled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Faculties", t => t.FacultyId, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.GroupId)
                .Index(t => t.FacultyId);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        AddedDate = c.DateTime(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TestQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TestId = c.Int(nullable: false),
                        Question = c.String(nullable: false, maxLength: 255),
                        AnswerA = c.String(nullable: false, maxLength: 255),
                        AnswerB = c.String(nullable: false, maxLength: 255),
                        AnswerC = c.String(nullable: false, maxLength: 255),
                        AnswerD = c.String(nullable: false, maxLength: 255),
                        CorrectAnswer = c.String(nullable: false, maxLength: 1),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tests", t => t.TestId, cascadeDelete: false)
                .Index(t => t.TestId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentFinishedTestAnswers", "TestQuestionId", "dbo.TestQuestions");
            DropForeignKey("dbo.TestQuestions", "TestId", "dbo.Tests");
            DropForeignKey("dbo.StudentFinishedTestAnswers", "TestId", "dbo.Tests");
            DropForeignKey("dbo.Tests", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.StudentFinishedTestAnswers", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Students", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Students", "FacultyId", "dbo.Faculties");
            DropIndex("dbo.TestQuestions", new[] { "TestId" });
            DropIndex("dbo.Tests", new[] { "SubjectId" });
            DropIndex("dbo.Students", new[] { "FacultyId" });
            DropIndex("dbo.Students", new[] { "GroupId" });
            DropIndex("dbo.Students", new[] { "UserId" });
            DropIndex("dbo.StudentFinishedTestAnswers", new[] { "TestQuestionId" });
            DropIndex("dbo.StudentFinishedTestAnswers", new[] { "TestId" });
            DropIndex("dbo.StudentFinishedTestAnswers", new[] { "StudentId" });
            DropTable("dbo.TestQuestions");
            DropTable("dbo.Subjects");
            DropTable("dbo.Tests");
            DropTable("dbo.Students");
            DropTable("dbo.StudentFinishedTestAnswers");
            DropTable("dbo.Groups");
            DropTable("dbo.Faculties");
        }
    }
}
