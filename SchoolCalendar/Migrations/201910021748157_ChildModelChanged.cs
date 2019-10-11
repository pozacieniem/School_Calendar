namespace SchoolCalendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChildModelChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Children", "Disability", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Children", "Disability");
        }
    }
}
