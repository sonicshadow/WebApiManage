namespace WebApiManage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProject : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Apis",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProjectID = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Group = c.String(nullable: false),
                        Url = c.String(nullable: false),
                        Type = c.Int(nullable: false),
                        Parameters = c.String(),
                        Info = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Apis", "ProjectID", "dbo.Projects");
            DropIndex("dbo.Apis", new[] { "ProjectID" });
            DropTable("dbo.Projects");
            DropTable("dbo.Apis");
        }
    }
}
