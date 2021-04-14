namespace Employee_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlockIPAddress",
                c => new
                    {
                        IPAddress = c.String(nullable: false, maxLength: 15, unicode: false),
                    })
                .PrimaryKey(t => t.IPAddress);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        ID = c.Long(nullable: false),
                        Username = c.String(nullable: false, maxLength: 15),
                        Password = c.String(nullable: false, maxLength: 15),
                        Email = c.String(nullable: false, maxLength: 100),
                        FullName = c.String(maxLength: 20),
                        JoinedDate = c.DateTime(nullable: false),
                        SecurityPhase = c.String(nullable: false, maxLength: 40),
                        LoginAttempt = c.Byte(nullable: false),
                        IPAddress = c.String(maxLength: 15, unicode: false),
                        PositionID = c.Long(nullable: false),
                        TeamID = c.Long(nullable: false),
                        StatusID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Position", t => t.PositionID, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusID, cascadeDelete: true)
                .ForeignKey("dbo.Team", t => t.TeamID, cascadeDelete: true)
                .Index(t => t.PositionID)
                .Index(t => t.TeamID)
                .Index(t => t.StatusID);
            
            CreateTable(
                "dbo.Position",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        PositionName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        StatusName = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        TeamName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "TeamID", "dbo.Team");
            DropForeignKey("dbo.Employee", "StatusID", "dbo.Status");
            DropForeignKey("dbo.Employee", "PositionID", "dbo.Position");
            DropIndex("dbo.Employee", new[] { "StatusID" });
            DropIndex("dbo.Employee", new[] { "TeamID" });
            DropIndex("dbo.Employee", new[] { "PositionID" });
            DropTable("dbo.Team");
            DropTable("dbo.Status");
            DropTable("dbo.Position");
            DropTable("dbo.Employee");
            DropTable("dbo.BlockIPAddress");
        }
    }
}
