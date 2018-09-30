namespace UniversityTestingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGroups : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Groups (Name, FacultyId) VALUES ('101', 1);");
            Sql("INSERT INTO Groups (Name, FacultyId) VALUES ('102', 1);");
            Sql("INSERT INTO Groups (Name, FacultyId) VALUES ('103', 1);");
            Sql("INSERT INTO Groups (Name, FacultyId) VALUES ('104', 1);");
            Sql("INSERT INTO Groups (Name, FacultyId) VALUES ('105', 1);");
            Sql("INSERT INTO Groups (Name, FacultyId) VALUES ('101', 2);");
            Sql("INSERT INTO Groups (Name, FacultyId) VALUES ('102', 2);");
            Sql("INSERT INTO Groups (Name, FacultyId) VALUES ('103', 2);");
            Sql("INSERT INTO Groups (Name, FacultyId) VALUES ('104', 2);");
            Sql("INSERT INTO Groups (Name, FacultyId) VALUES ('105', 2);");
            Sql("INSERT INTO Groups (Name, FacultyId) VALUES ('101', 3);");
            Sql("INSERT INTO Groups (Name, FacultyId) VALUES ('102', 3);");
            Sql("INSERT INTO Groups (Name, FacultyId) VALUES ('103', 3);");
            Sql("INSERT INTO Groups (Name, FacultyId) VALUES ('104', 3);");
            Sql("INSERT INTO Groups (Name, FacultyId) VALUES ('105', 3);");
            Sql("INSERT INTO Groups (Name, FacultyId) VALUES ('101', 4);");
            Sql("INSERT INTO Groups (Name, FacultyId) VALUES ('102', 4);");
            Sql("INSERT INTO Groups (Name, FacultyId) VALUES ('103', 4);");
            Sql("INSERT INTO Groups (Name, FacultyId) VALUES ('104', 4);");
            Sql("INSERT INTO Groups (Name, FacultyId) VALUES ('105', 4);");
        }
        
        public override void Down()
        {
        }
    }
}
