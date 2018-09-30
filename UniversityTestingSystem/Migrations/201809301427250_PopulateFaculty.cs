namespace UniversityTestingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateFaculty : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Faculties (Code, Name) VALUES ('JOU', 'Журналистика')");
            Sql("INSERT INTO Faculties (Code, Name) VALUES ('TRA', 'Переводческое дело')");
            Sql("INSERT INTO Faculties (Code, Name) VALUES ('PSY', 'Психология')");
            Sql("INSERT INTO Faculties (Code, Name) VALUES ('TOU', 'Туризм')");
        }
        
        public override void Down()
        {
        }
    }
}
