namespace UniversityTestingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTestsTestQuestions : DbMigration
    {
        public override void Up()
        {
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
                .ForeignKey("dbo.Tests", t => t.TestId, cascadeDelete: true)
                .Index(t => t.TestId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestQuestions", "TestId", "dbo.Tests");
            DropForeignKey("dbo.Tests", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.Tests", new[] { "SubjectId" });
            DropIndex("dbo.TestQuestions", new[] { "TestId" });
            DropTable("dbo.Tests");
            DropTable("dbo.TestQuestions");
        }
    }
}
