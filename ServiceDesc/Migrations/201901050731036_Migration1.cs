namespace ServiceDesc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TechnicalTasks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        Cabinet = c.String(),
                        Comment = c.String(),
                        IsComplete = c.Boolean(nullable: false),
                        TaskCreator_Id = c.String(maxLength: 128),
                        TaskPerformer_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.TaskCreator_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.TaskPerformer_Id)
                .Index(t => t.TaskCreator_Id)
                .Index(t => t.TaskPerformer_Id);
            
            AddColumn("dbo.AspNetUsers", "IsTechnicalDepartmentUser", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TechnicalTasks", "TaskPerformer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.TechnicalTasks", "TaskCreator_Id", "dbo.AspNetUsers");
            DropIndex("dbo.TechnicalTasks", new[] { "TaskPerformer_Id" });
            DropIndex("dbo.TechnicalTasks", new[] { "TaskCreator_Id" });
            DropColumn("dbo.AspNetUsers", "IsTechnicalDepartmentUser");
            DropTable("dbo.TechnicalTasks");
        }
    }
}
