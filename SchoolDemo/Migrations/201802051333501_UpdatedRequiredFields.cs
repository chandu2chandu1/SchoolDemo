namespace SchoolDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedRequiredFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Schools", "Schoolname", c => c.String(nullable: false));
            AlterColumn("dbo.Schools", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "FirstName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "FirstName", c => c.String());
            AlterColumn("dbo.Schools", "Address", c => c.String());
            AlterColumn("dbo.Schools", "Schoolname", c => c.String());
        }
    }
}
