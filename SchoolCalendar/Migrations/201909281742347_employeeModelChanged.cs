namespace SchoolCalendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employeeModelChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "JobPositionId", c => c.Int(nullable: false));
            DropColumn("dbo.Employees", "RoleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "RoleId", c => c.Int(nullable: false));
            DropColumn("dbo.Employees", "JobPositionId");
        }
    }
}
