namespace SchoolCalendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyModifications3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Groups", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.Children", "Group_ID", "dbo.Groups");
            DropIndex("dbo.Children", new[] { "Group_ID" });
            DropIndex("dbo.Groups", new[] { "SchoolId" });
            RenameColumn(table: "dbo.Groups", name: "SchoolId", newName: "School_Id");
            RenameColumn(table: "dbo.Children", name: "Group_ID", newName: "GroupId");
            AlterColumn("dbo.Children", "GroupId", c => c.Int(nullable: false));
            AlterColumn("dbo.Groups", "School_Id", c => c.Int());
            CreateIndex("dbo.Children", "GroupId");
            CreateIndex("dbo.Groups", "School_Id");
            AddForeignKey("dbo.Groups", "School_Id", "dbo.Schools", "Id");
            AddForeignKey("dbo.Children", "GroupId", "dbo.Groups", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Children", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Groups", "School_Id", "dbo.Schools");
            DropIndex("dbo.Groups", new[] { "School_Id" });
            DropIndex("dbo.Children", new[] { "GroupId" });
            AlterColumn("dbo.Groups", "School_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Children", "GroupId", c => c.Int());
            RenameColumn(table: "dbo.Children", name: "GroupId", newName: "Group_ID");
            RenameColumn(table: "dbo.Groups", name: "School_Id", newName: "SchoolId");
            CreateIndex("dbo.Groups", "SchoolId");
            CreateIndex("dbo.Children", "Group_ID");
            AddForeignKey("dbo.Children", "Group_ID", "dbo.Groups", "ID");
            AddForeignKey("dbo.Groups", "SchoolId", "dbo.Schools", "Id", cascadeDelete: true);
        }
    }
}
