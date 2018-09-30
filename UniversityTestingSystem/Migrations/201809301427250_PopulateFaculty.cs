namespace UniversityTestingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateFaculty : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Faculties (Code, Name) VALUES ('JOU', N'������������')");
            Sql("INSERT INTO Faculties (Code, Name) VALUES ('TRA', N'������������� ����')");
            Sql("INSERT INTO Faculties (Code, Name) VALUES ('PSY', N'����������')");
            Sql("INSERT INTO Faculties (Code, Name) VALUES ('TOU', N'������')");
        }
        
        public override void Down()
        {
        }
    }
}
