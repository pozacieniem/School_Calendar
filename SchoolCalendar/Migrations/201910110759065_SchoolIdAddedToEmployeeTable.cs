namespace SchoolCalendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SchoolIdAddedToEmployeeTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "School_Id", "dbo.Schools");
            DropIndex("dbo.Employees", new[] { "School_Id" });
            RenameColumn(table: "dbo.Employees", name: "School_Id", newName: "SchoolId");
            AlterColumn("dbo.Employees", "SchoolId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "SchoolId");
            AddForeignKey("dbo.Employees", "SchoolId", "dbo.Schools", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "SchoolId", "dbo.Schools");
            DropIndex("dbo.Employees", new[] { "SchoolId" });
            AlterColumn("dbo.Employees", "SchoolId", c => c.Int());
            RenameColumn(table: "dbo.Employees", name: "SchoolId", newName: "School_Id");
            CreateIndex("dbo.Employees", "School_Id");
            AddForeignKey("dbo.Employees", "School_Id", "dbo.Schools", "Id");
        }
    }
}
