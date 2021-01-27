namespace SchoolCalendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GroupsTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                        SchoolId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Schools", t => t.SchoolId, cascadeDelete: true)
                .Index(t => t.SchoolId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Groups", "SchoolId", "dbo.Schools");
            DropIndex("dbo.Groups", new[] { "SchoolId" });
            DropTable("dbo.Groups");
        }
    }
}
