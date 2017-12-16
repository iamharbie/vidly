namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsSubsribedToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "AddIsSubscribedToNewsletter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "AddIsSubscribedToNewsletter");
        }
    }
}
