namespace SchoolCalendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewVersionOfDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Children", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.Employees", "SchoolId", "dbo.Schools");
            DropIndex("dbo.Children", new[] { "SchoolId" });
            DropIndex("dbo.Employees", new[] { "SchoolId" });
            RenameColumn(table: "dbo.Children", name: "SchoolId", newName: "School_Id");
            RenameColumn(table: "dbo.Employees", name: "SchoolId", newName: "School_Id");
            AlterColumn("dbo.Children", "School_Id", c => c.Int());
            AlterColumn("dbo.Employees", "School_Id", c => c.Int());
            CreateIndex("dbo.Children", "School_Id");
            CreateIndex("dbo.Employees", "School_Id");
            AddForeignKey("dbo.Children", "School_Id", "dbo.Schools", "Id");
            AddForeignKey("dbo.Employees", "School_Id", "dbo.Schools", "Id");
            DropColumn("dbo.Employees", "BirthDate");
            DropColumn("dbo.Employees", "EmploymentDate");
            DropColumn("dbo.Employees", "JobPositionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "JobPositionId", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "EmploymentDate", c => c.DateTime());
            AddColumn("dbo.Employees", "BirthDate", c => c.DateTime());
            DropForeignKey("dbo.Employees", "School_Id", "dbo.Schools");
            DropForeignKey("dbo.Children", "School_Id", "dbo.Schools");
            DropIndex("dbo.Employees", new[] { "School_Id" });
            DropIndex("dbo.Children", new[] { "School_Id" });
            AlterColumn("dbo.Employees", "School_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Children", "School_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Employees", name: "School_Id", newName: "SchoolId");
            RenameColumn(table: "dbo.Children", name: "School_Id", newName: "SchoolId");
            CreateIndex("dbo.Employees", "SchoolId");
            CreateIndex("dbo.Children", "SchoolId");
            AddForeignKey("dbo.Employees", "SchoolId", "dbo.Schools", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Children", "SchoolId", "dbo.Schools", "Id", cascadeDelete: true);
        }
    }
}
