namespace SchoolCalendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CalendarEventTableUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CalendarEvents", "Teacher", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CalendarEvents", "Teacher");
        }
    }
}
