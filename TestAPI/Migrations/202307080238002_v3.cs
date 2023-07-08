namespace TestAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tasks", "IDparent", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tasks", "IDparent", c => c.Int(nullable: false));
        }
    }
}
