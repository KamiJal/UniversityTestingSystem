namespace UniversityTestingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateFaculty : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Faculties (Code, Name) VALUES ('JOU', N'Журналистика')");
            Sql("INSERT INTO Faculties (Code, Name) VALUES ('TRA', N'Переводческое дело')");
            Sql("INSERT INTO Faculties (Code, Name) VALUES ('PSY', N'Психология')");
            Sql("INSERT INTO Faculties (Code, Name) VALUES ('TOU', N'Туризм')");
        }
        
        public override void Down()
        {
        }
    }
}
