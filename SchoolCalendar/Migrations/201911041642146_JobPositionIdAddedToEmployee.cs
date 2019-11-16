namespace SchoolCalendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobPositionIdAddedToEmployee : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "JobPosition_Id", "dbo.JobPositions");
            DropIndex("dbo.Employees", new[] { "JobPosition_Id" });
            RenameColumn(table: "dbo.Employees", name: "JobPosition_Id", newName: "JobPositionId");
            AlterColumn("dbo.Employees", "JobPositionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "JobPositionId");
            AddForeignKey("dbo.Employees", "JobPositionId", "dbo.JobPositions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "JobPositionId", "dbo.JobPositions");
            DropIndex("dbo.Employees", new[] { "JobPositionId" });
            AlterColumn("dbo.Employees", "JobPositionId", c => c.Int());
            RenameColumn(table: "dbo.Employees", name: "JobPositionId", newName: "JobPosition_Id");
            CreateIndex("dbo.Employees", "JobPosition_Id");
            AddForeignKey("dbo.Employees", "JobPosition_Id", "dbo.JobPositions", "Id");
        }
    }
}
