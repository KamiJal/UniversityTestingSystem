namespace UniversityTestingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateFaculty : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Faculties (Code, Name) VALUES ('JOU', '������������')");
            Sql("INSERT INTO Faculties (Code, Name) VALUES ('TRA', '������������� ����')");
            Sql("INSERT INTO Faculties (Code, Name) VALUES ('PSY', '����������')");
            Sql("INSERT INTO Faculties (Code, Name) VALUES ('TOU', '������')");
        }
        
        public override void Down()
        {
        }
    }
}
