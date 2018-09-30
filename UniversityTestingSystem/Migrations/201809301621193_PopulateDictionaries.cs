namespace UniversityTestingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDictionaries : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Faculties (Code, Name) VALUES ('JOU', N'������������')");
            Sql("INSERT INTO Faculties (Code, Name) VALUES ('TRA', N'������������� ����')");
            Sql("INSERT INTO Faculties (Code, Name) VALUES ('PSY', N'����������')");
            Sql("INSERT INTO Faculties (Code, Name) VALUES ('TOU', N'������')");

            Sql("INSERT INTO Groups (Name) VALUES ('101')");
            Sql("INSERT INTO Groups (Name) VALUES ('102')");
            Sql("INSERT INTO Groups (Name) VALUES ('103')");
            Sql("INSERT INTO Groups (Name) VALUES ('104')");
            Sql("INSERT INTO Groups (Name) VALUES ('105')");

            Sql("INSERT INTO Subjects (Name) VALUES (N'�������')");
            Sql("INSERT INTO Subjects (Name) VALUES (N'����������')");
            Sql("INSERT INTO Subjects (Name) VALUES (N'������')");
            Sql("INSERT INTO Subjects (Name) VALUES (N'�����������')");

        }
        
        public override void Down()
        {
        }
    }
}
