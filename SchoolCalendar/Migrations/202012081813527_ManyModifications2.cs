namespace SchoolCalendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyModifications2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Children", "Group_ID", c => c.Int());
            CreateIndex("dbo.Children", "Group_ID");
            AddForeignKey("dbo.Children", "Group_ID", "dbo.Groups", "ID");
            DropColumn("dbo.Children", "Group");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Children", "Group", c => c.String());
            DropForeignKey("dbo.Children", "Group_ID", "dbo.Groups");
            DropIndex("dbo.Children", new[] { "Group_ID" });
            DropColumn("dbo.Children", "Group_ID");
        }
    }
}
