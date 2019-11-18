namespace SchoolCalendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SchoolIdAddedToChildTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Children", "School_Id", "dbo.Schools");
            DropIndex("dbo.Children", new[] { "School_Id" });
            RenameColumn(table: "dbo.Children", name: "School_Id", newName: "SchoolId");
            AlterColumn("dbo.Children", "SchoolId", c => c.Int(nullable: false));
            CreateIndex("dbo.Children", "SchoolId");
            AddForeignKey("dbo.Children", "SchoolId", "dbo.Schools", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Children", "SchoolId", "dbo.Schools");
            DropIndex("dbo.Children", new[] { "SchoolId" });
            AlterColumn("dbo.Children", "SchoolId", c => c.Int());
            RenameColumn(table: "dbo.Children", name: "SchoolId", newName: "School_Id");
            CreateIndex("dbo.Children", "School_Id");
            AddForeignKey("dbo.Children", "School_Id", "dbo.Schools", "Id");
        }
    }
}
