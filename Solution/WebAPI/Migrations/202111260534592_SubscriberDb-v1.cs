namespace WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubscriberDbv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subscribers",
                c => new
                    {
                        SubscriberID = c.Int(nullable: false, identity: true),
                        SubscriberName = c.String(nullable: false),
                        SubscriberEmail = c.String(nullable: false),
                        SubscriberAge = c.String(),
                        SubscriberUsername = c.String(nullable: false),
                        SubscriberPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SubscriberID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Subscribers");
        }
    }
}
