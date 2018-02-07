namespace GoFinance_API_Sharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class novamodelagem4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Login", "PrimeiroNome", c => c.String());
            AddColumn("dbo.Login", "SobreNome", c => c.String());
            DropColumn("dbo.Login", "Nome");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Login", "Nome", c => c.String());
            DropColumn("dbo.Login", "SobreNome");
            DropColumn("dbo.Login", "PrimeiroNome");
        }
    }
}
