namespace SchoolCalendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CalendarEventTableFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CalendarEvents", "Teacher_Id", c => c.Int());
            CreateIndex("dbo.CalendarEvents", "Teacher_Id");
            AddForeignKey("dbo.CalendarEvents", "Teacher_Id", "dbo.Employees", "Id");
            DropColumn("dbo.CalendarEvents", "Teacher");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CalendarEvents", "Teacher", c => c.String());
            DropForeignKey("dbo.CalendarEvents", "Teacher_Id", "dbo.Employees");
            DropIndex("dbo.CalendarEvents", new[] { "Teacher_Id" });
            DropColumn("dbo.CalendarEvents", "Teacher_Id");
        }
    }
}
