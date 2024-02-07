namespace RepairService.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        SerialNumber = c.String(nullable: false),
                        EquipmentTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EquipmentTypes", t => t.EquipmentTypeId, cascadeDelete: true)
                .Index(t => t.EquipmentTypeId);
            
            CreateTable(
                "dbo.EquipmentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        ClientId = c.Int(nullable: false),
                        EquipmentId = c.Int(nullable: false),
                        TypeBrokenId = c.Int(nullable: false),
                        Description = c.String(),
                        Priority = c.Int(),
                        Status_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Equipments", t => t.EquipmentId, cascadeDelete: true)
                .ForeignKey("dbo.TypeBrokens", t => t.TypeBrokenId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.Status_Id)
                .Index(t => t.ClientId)
                .Index(t => t.EquipmentId)
                .Index(t => t.TypeBrokenId)
                .Index(t => t.Status_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Patronymic = c.String(),
                        RoleId = c.Int(nullable: false),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        CompletionTime = c.DateTimeOffset(nullable: false, precision: 7),
                        Reason = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.SparesCounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Count = c.Int(nullable: false),
                        SparesTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SparesTypes", t => t.SparesTypeId, cascadeDelete: true)
                .Index(t => t.SparesTypeId);
            
            CreateTable(
                "dbo.SparesTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TypeBrokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SparesCountReports",
                c => new
                    {
                        SparesCount_Id = c.Int(nullable: false),
                        Report_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SparesCount_Id, t.Report_Id })
                .ForeignKey("dbo.SparesCounts", t => t.SparesCount_Id, cascadeDelete: true)
                .ForeignKey("dbo.Reports", t => t.Report_Id, cascadeDelete: true)
                .Index(t => t.SparesCount_Id)
                .Index(t => t.Report_Id);
            
            CreateTable(
                "dbo.OrderUsers",
                c => new
                    {
                        Order_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_Id, t.User_Id })
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Order_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Status_Id", "dbo.Status");
            DropForeignKey("dbo.OrderUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.OrderUsers", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "TypeBrokenId", "dbo.TypeBrokens");
            DropForeignKey("dbo.SparesCounts", "SparesTypeId", "dbo.SparesTypes");
            DropForeignKey("dbo.SparesCountReports", "Report_Id", "dbo.Reports");
            DropForeignKey("dbo.SparesCountReports", "SparesCount_Id", "dbo.SparesCounts");
            DropForeignKey("dbo.Reports", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "EquipmentId", "dbo.Equipments");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Orders", "ClientId", "dbo.Users");
            DropForeignKey("dbo.Equipments", "EquipmentTypeId", "dbo.EquipmentTypes");
            DropIndex("dbo.OrderUsers", new[] { "User_Id" });
            DropIndex("dbo.OrderUsers", new[] { "Order_Id" });
            DropIndex("dbo.SparesCountReports", new[] { "Report_Id" });
            DropIndex("dbo.SparesCountReports", new[] { "SparesCount_Id" });
            DropIndex("dbo.SparesCounts", new[] { "SparesTypeId" });
            DropIndex("dbo.Reports", new[] { "OrderId" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Orders", new[] { "Status_Id" });
            DropIndex("dbo.Orders", new[] { "TypeBrokenId" });
            DropIndex("dbo.Orders", new[] { "EquipmentId" });
            DropIndex("dbo.Orders", new[] { "ClientId" });
            DropIndex("dbo.Equipments", new[] { "EquipmentTypeId" });
            DropTable("dbo.OrderUsers");
            DropTable("dbo.SparesCountReports");
            DropTable("dbo.Status");
            DropTable("dbo.TypeBrokens");
            DropTable("dbo.SparesTypes");
            DropTable("dbo.SparesCounts");
            DropTable("dbo.Reports");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.EquipmentTypes");
            DropTable("dbo.Equipments");
        }
    }
}
