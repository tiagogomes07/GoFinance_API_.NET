namespace GoFinance_API_Sharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class novamodelagem1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Login_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Logins", t => t.Login_Id)
                .Index(t => t.Login_Id);
            
            AddColumn("dbo.Lancamentoes", "Conta_Id", c => c.Int());
            CreateIndex("dbo.Lancamentoes", "Conta_Id");
            AddForeignKey("dbo.Lancamentoes", "Conta_Id", "dbo.Contas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lancamentoes", "Conta_Id", "dbo.Contas");
            DropForeignKey("dbo.Contas", "Login_Id", "dbo.Logins");
            DropIndex("dbo.Lancamentoes", new[] { "Conta_Id" });
            DropIndex("dbo.Contas", new[] { "Login_Id" });
            DropColumn("dbo.Lancamentoes", "Conta_Id");
            DropTable("dbo.Contas");
        }
    }
}
