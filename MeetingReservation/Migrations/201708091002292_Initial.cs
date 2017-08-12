namespace MeetingReservation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attend",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Invitee_Id = c.Int(),
                        Meeting_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.Invitee_Id)
                .ForeignKey("dbo.Meeting", t => t.Meeting_Id)
                .Index(t => t.Invitee_Id)
                .Index(t => t.Meeting_Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        NationalCode = c.String(),
                        Discriminator = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Meeting",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Title = c.String(),
                        Initiator_Id = c.Int(),
                        Location_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomDateTime", t => t.Id)
                .ForeignKey("dbo.User", t => t.Initiator_Id)
                .ForeignKey("dbo.Location", t => t.Location_Id)
                .Index(t => t.Id)
                .Index(t => t.Initiator_Id)
                .Index(t => t.Location_Id);
            
            CreateTable(
                "dbo.CustomDateTime",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Capacity = c.Int(nullable: false),
                        Facilities = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Meeting", "Location_Id", "dbo.Location");
            DropForeignKey("dbo.Meeting", "Initiator_Id", "dbo.User");
            DropForeignKey("dbo.Meeting", "Id", "dbo.CustomDateTime");
            DropForeignKey("dbo.Attend", "Meeting_Id", "dbo.Meeting");
            DropForeignKey("dbo.Attend", "Invitee_Id", "dbo.User");
            DropIndex("dbo.Meeting", new[] { "Location_Id" });
            DropIndex("dbo.Meeting", new[] { "Initiator_Id" });
            DropIndex("dbo.Meeting", new[] { "Id" });
            DropIndex("dbo.Attend", new[] { "Meeting_Id" });
            DropIndex("dbo.Attend", new[] { "Invitee_Id" });
            DropTable("dbo.Location");
            DropTable("dbo.CustomDateTime");
            DropTable("dbo.Meeting");
            DropTable("dbo.User");
            DropTable("dbo.Attend");
        }
    }
}
