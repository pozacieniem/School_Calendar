namespace SchoolCalendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChildTableUpdated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Children", "BirthDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Children", "BirthDate", c => c.DateTime());
        }
    }
}
