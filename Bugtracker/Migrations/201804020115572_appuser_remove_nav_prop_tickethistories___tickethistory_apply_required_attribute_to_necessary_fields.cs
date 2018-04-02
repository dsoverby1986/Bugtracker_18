namespace Bugtracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appuser_remove_nav_prop_tickethistories___tickethistory_apply_required_attribute_to_necessary_fields : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TicketHistories", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.TicketHistories", new[] { "UserId" });
            AlterColumn("dbo.TicketHistories", "Property", c => c.String(nullable: false));
            AlterColumn("dbo.TicketHistories", "DisplayProperty", c => c.String(nullable: false));
            AlterColumn("dbo.TicketHistories", "NewValue", c => c.String(nullable: false));
            AlterColumn("dbo.TicketHistories", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.TicketHistories", "UserId");
            AddForeignKey("dbo.TicketHistories", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TicketHistories", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.TicketHistories", new[] { "UserId" });
            AlterColumn("dbo.TicketHistories", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.TicketHistories", "NewValue", c => c.String());
            AlterColumn("dbo.TicketHistories", "DisplayProperty", c => c.String());
            AlterColumn("dbo.TicketHistories", "Property", c => c.String());
            CreateIndex("dbo.TicketHistories", "UserId");
            AddForeignKey("dbo.TicketHistories", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
