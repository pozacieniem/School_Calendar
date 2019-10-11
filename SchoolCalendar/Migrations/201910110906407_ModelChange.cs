namespace SchoolCalendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JobPositions", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.JobPositions", new[] { "Employee_Id" });
            AddColumn("dbo.Employees", "JobPosition_Id", c => c.Int());
            CreateIndex("dbo.Employees", "JobPosition_Id");
            AddForeignKey("dbo.Employees", "JobPosition_Id", "dbo.JobPositions", "Id");
            DropColumn("dbo.JobPositions", "Employee_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobPositions", "Employee_Id", c => c.Int());
            DropForeignKey("dbo.Employees", "JobPosition_Id", "dbo.JobPositions");
            DropIndex("dbo.Employees", new[] { "JobPosition_Id" });
            DropColumn("dbo.Employees", "JobPosition_Id");
            CreateIndex("dbo.JobPositions", "Employee_Id");
            AddForeignKey("dbo.JobPositions", "Employee_Id", "dbo.Employees", "Id");
        }
    }
}
