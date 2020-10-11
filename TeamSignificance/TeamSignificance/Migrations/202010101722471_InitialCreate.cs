namespace TeamSignificance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Double(nullable: false),
                        To_Id = c.Int(),
                        UserReport_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.To_Id)
                .ForeignKey("dbo.UserReports", t => t.UserReport_Id)
                .Index(t => t.To_Id)
                .Index(t => t.UserReport_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nickname = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.UserReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        From_Id = c.Int(),
                        Room_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.From_Id)
                .ForeignKey("dbo.Rooms", t => t.Room_Id)
                .Index(t => t.From_Id)
                .Index(t => t.Room_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reports", "UserReport_Id", "dbo.UserReports");
            DropForeignKey("dbo.UserReports", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.UserReports", "From_Id", "dbo.Users");
            DropForeignKey("dbo.Reports", "To_Id", "dbo.Users");
            DropForeignKey("dbo.Rooms", "Id", "dbo.Users");
            DropIndex("dbo.UserReports", new[] { "Room_Id" });
            DropIndex("dbo.UserReports", new[] { "From_Id" });
            DropIndex("dbo.Rooms", new[] { "Id" });
            DropIndex("dbo.Reports", new[] { "UserReport_Id" });
            DropIndex("dbo.Reports", new[] { "To_Id" });
            DropTable("dbo.UserReports");
            DropTable("dbo.Rooms");
            DropTable("dbo.Users");
            DropTable("dbo.Reports");
        }
    }
}
