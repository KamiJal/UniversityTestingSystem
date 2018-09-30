namespace UniversityTestingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDictionaries : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Faculties (Code, Name) VALUES ('JOU', N'Журналистика')");
            Sql("INSERT INTO Faculties (Code, Name) VALUES ('TRA', N'Переводческое дело')");
            Sql("INSERT INTO Faculties (Code, Name) VALUES ('PSY', N'Психология')");
            Sql("INSERT INTO Faculties (Code, Name) VALUES ('TOU', N'Туризм')");

            Sql("INSERT INTO Groups (Name) VALUES ('101')");
            Sql("INSERT INTO Groups (Name) VALUES ('102')");
            Sql("INSERT INTO Groups (Name) VALUES ('103')");
            Sql("INSERT INTO Groups (Name) VALUES ('104')");
            Sql("INSERT INTO Groups (Name) VALUES ('105')");

            Sql("INSERT INTO Subjects (Name) VALUES (N'История')");
            Sql("INSERT INTO Subjects (Name) VALUES (N'Математика')");
            Sql("INSERT INTO Subjects (Name) VALUES (N'Физика')");
            Sql("INSERT INTO Subjects (Name) VALUES (N'Информатика')");

        }
        
        public override void Down()
        {
        }
    }
}
