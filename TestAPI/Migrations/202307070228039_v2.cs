namespace TestAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        ShortName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StaffInTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StaffId = c.Int(nullable: false),
                        TaskId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Staffs", t => t.StaffId, cascadeDelete: true)
                .ForeignKey("dbo.Tasks", t => t.TaskId, cascadeDelete: true)
                .Index(t => t.StaffId)
                .Index(t => t.TaskId);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IDparent = c.Int(nullable: false),
                        Label = c.String(),
                        Type = c.String(),
                        Name = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        Duration = c.Int(nullable: false),
                        Progress = c.Int(nullable: false),
                        IsUnscheduled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StaffInTasks", "TaskId", "dbo.Tasks");
            DropForeignKey("dbo.StaffInTasks", "StaffId", "dbo.Staffs");
            DropIndex("dbo.StaffInTasks", new[] { "TaskId" });
            DropIndex("dbo.StaffInTasks", new[] { "StaffId" });
            DropTable("dbo.Tasks");
            DropTable("dbo.StaffInTasks");
            DropTable("dbo.Staffs");
        }
    }
}
