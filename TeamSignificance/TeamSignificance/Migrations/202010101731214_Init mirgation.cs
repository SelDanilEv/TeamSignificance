namespace TeamSignificance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initmirgation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rooms", "Id", "dbo.Users");
            DropForeignKey("dbo.UserReports", "Room_Id", "dbo.Rooms");
            DropIndex("dbo.Rooms", new[] { "Id" });
            DropPrimaryKey("dbo.Rooms");
            AddColumn("dbo.Users", "Room_Id", c => c.Int());
            AddColumn("dbo.Rooms", "Admin_Id", c => c.Int());
            AlterColumn("dbo.Rooms", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Rooms", "Id");
            CreateIndex("dbo.Users", "Room_Id");
            CreateIndex("dbo.Rooms", "Admin_Id");
            AddForeignKey("dbo.Users", "Room_Id", "dbo.Rooms", "Id");
            AddForeignKey("dbo.Rooms", "Admin_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.UserReports", "Room_Id", "dbo.Rooms", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserReports", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "Admin_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Room_Id", "dbo.Rooms");
            DropIndex("dbo.Rooms", new[] { "Admin_Id" });
            DropIndex("dbo.Users", new[] { "Room_Id" });
            DropPrimaryKey("dbo.Rooms");
            AlterColumn("dbo.Rooms", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.Rooms", "Admin_Id");
            DropColumn("dbo.Users", "Room_Id");
            AddPrimaryKey("dbo.Rooms", "Id");
            CreateIndex("dbo.Rooms", "Id");
            AddForeignKey("dbo.UserReports", "Room_Id", "dbo.Rooms", "Id");
            AddForeignKey("dbo.Rooms", "Id", "dbo.Users", "Id");
        }
    }
}
