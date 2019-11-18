namespace SchoolCalendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropAddedToChildTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Children", "DecisionNumber", c => c.String());
            AddColumn("dbo.Children", "OpinionNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Children", "OpinionNumber");
            DropColumn("dbo.Children", "DecisionNumber");
        }
    }
}
