namespace DataTransferFromRESTApiToDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Railways",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Code = c.Short(nullable: false),
                        Name = c.String(),
                        ShortName = c.String(),
                        CountryID = c.Int(nullable: false),
                        TelegraphName = c.String(),
                        DateCreate = c.DateTime(nullable: false),
                        DateUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Stations",
                c => new
                    {
                        Code = c.Int(nullable: false),
                        ID = c.Int(nullable: false),
                        RailwayDepartmentID = c.Int(),
                        RailwayID = c.Int(),
                        CountryID = c.Int(),
                        Name12Char = c.String(maxLength: 12),
                        Name = c.String(maxLength: 40),
                        FreightSign = c.Boolean(nullable: false),
                        CodeOSGD = c.String(),
                        DateCreate = c.DateTime(nullable: false),
                        DateUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Code)
                .ForeignKey("dbo.Railways", t => t.RailwayID)
                .Index(t => t.RailwayID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stations", "RailwayID", "dbo.Railways");
            DropIndex("dbo.Stations", new[] { "RailwayID" });
            DropTable("dbo.Stations");
            DropTable("dbo.Railways");
        }
    }
}
