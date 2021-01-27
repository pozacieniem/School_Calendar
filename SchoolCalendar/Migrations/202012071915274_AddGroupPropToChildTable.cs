namespace SchoolCalendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGroupPropToChildTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Children", "Group", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Children", "Group");
        }
    }
}
