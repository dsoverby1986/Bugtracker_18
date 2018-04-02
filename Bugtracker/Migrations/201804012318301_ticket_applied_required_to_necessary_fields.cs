namespace Bugtracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ticket_applied_required_to_necessary_fields : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "AssignedUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Tickets", new[] { "AssignedUserId" });
            AlterColumn("dbo.Tickets", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Tickets", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Tickets", "AssignedUserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Tickets", "AssignedUserId");
            AddForeignKey("dbo.Tickets", "AssignedUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "AssignedUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Tickets", new[] { "AssignedUserId" });
            AlterColumn("dbo.Tickets", "AssignedUserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Tickets", "Description", c => c.String());
            AlterColumn("dbo.Tickets", "Title", c => c.String());
            CreateIndex("dbo.Tickets", "AssignedUserId");
            AddForeignKey("dbo.Tickets", "AssignedUserId", "dbo.AspNetUsers", "Id");
        }
    }
}
