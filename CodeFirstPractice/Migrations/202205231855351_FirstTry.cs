namespace CodeFirstPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstTry : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PodState = c.Int(nullable: false),
                        PodMode = c.Int(nullable: false),
                        Name = c.String(),
                        Color = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        Size = c.Int(nullable: false),
                        PodTemp = c.Double(nullable: false),
                        Qty = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FamilyKey = c.Guid(nullable: false),
                        Weight = c.Int(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pods");
        }
    }
}
