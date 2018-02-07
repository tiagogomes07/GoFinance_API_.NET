namespace GoFinance_API_Sharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class novamodelagem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Senha = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Recursoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Saldo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Login_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Logins", t => t.Login_Id)
                .Index(t => t.Login_Id);
            
            AddColumn("dbo.Lancamentoes", "Descricao", c => c.String());
            AddColumn("dbo.Lancamentoes", "Login_Id", c => c.Int());
            AddColumn("dbo.Lancamentoes", "Recurso_Id", c => c.Int());
            CreateIndex("dbo.Lancamentoes", "Login_Id");
            CreateIndex("dbo.Lancamentoes", "Recurso_Id");
            AddForeignKey("dbo.Lancamentoes", "Login_Id", "dbo.Logins", "Id");
            AddForeignKey("dbo.Lancamentoes", "Recurso_Id", "dbo.Recursoes", "Id");
            DropColumn("dbo.Lancamentoes", "Descrição");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lancamentoes", "Descrição", c => c.String());
            DropForeignKey("dbo.Lancamentoes", "Recurso_Id", "dbo.Recursoes");
            DropForeignKey("dbo.Recursoes", "Login_Id", "dbo.Logins");
            DropForeignKey("dbo.Lancamentoes", "Login_Id", "dbo.Logins");
            DropIndex("dbo.Recursoes", new[] { "Login_Id" });
            DropIndex("dbo.Lancamentoes", new[] { "Recurso_Id" });
            DropIndex("dbo.Lancamentoes", new[] { "Login_Id" });
            DropColumn("dbo.Lancamentoes", "Recurso_Id");
            DropColumn("dbo.Lancamentoes", "Login_Id");
            DropColumn("dbo.Lancamentoes", "Descricao");
            DropTable("dbo.Recursoes");
            DropTable("dbo.Logins");
        }
    }
}
