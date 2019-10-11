namespace SchoolCalendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class CalendarEvenTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CalendarEvents",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Subject = c.String(),
                    Description = c.String(),
                    Start = c.DateTime(nullable: false),
                    End = c.DateTime(nullable: false),
                    Color = c.String(),
                    IsFullDay = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.CalendarEvents");
        }
    }
}