namespace GoFinance_API_Sharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class novamodelagem3 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Contas", newName: "Conta");
            RenameTable(name: "dbo.Logins", newName: "Login");
            RenameTable(name: "dbo.Lancamentoes", newName: "Lancamento");
            RenameTable(name: "dbo.Recursoes", newName: "Recurso");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Recurso", newName: "Recursoes");
            RenameTable(name: "dbo.Lancamento", newName: "Lancamentoes");
            RenameTable(name: "dbo.Login", newName: "Logins");
            RenameTable(name: "dbo.Conta", newName: "Contas");
        }
    }
}
