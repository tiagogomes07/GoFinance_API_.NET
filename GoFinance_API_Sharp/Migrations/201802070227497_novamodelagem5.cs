namespace GoFinance_API_Sharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class novamodelagem5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Login", "UserName", c => c.String());
            DropColumn("dbo.Login", "Senha");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Login", "Senha", c => c.String());
            DropColumn("dbo.Login", "UserName");
        }
    }
}
