namespace Varsity_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmvp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerID = c.Int(nullable: false, identity: true),
                        PlayerName = c.String(),
                        PlayerBio = c.String(),
                        TeamID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerID)
                .ForeignKey("dbo.Teams", t => t.TeamID, cascadeDelete: true)
                .Index(t => t.TeamID);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamID = c.Int(nullable: false, identity: true),
                        TeamName = c.String(),
                        TeamBio = c.String(),
                    })
                .PrimaryKey(t => t.TeamID);
            
            CreateTable(
                "dbo.Sponsors",
                c => new
                    {
                        SponsorID = c.Int(nullable: false, identity: true),
                        SponsorName = c.String(),
                    })
                .PrimaryKey(t => t.SponsorID);
            
            CreateTable(
                "dbo.SponsorTeams",
                c => new
                    {
                        Sponsor_SponsorID = c.Int(nullable: false),
                        Team_TeamID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Sponsor_SponsorID, t.Team_TeamID })
                .ForeignKey("dbo.Sponsors", t => t.Sponsor_SponsorID, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.Team_TeamID, cascadeDelete: true)
                .Index(t => t.Sponsor_SponsorID)
                .Index(t => t.Team_TeamID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Players", "TeamID", "dbo.Teams");
            DropForeignKey("dbo.SponsorTeams", "Team_TeamID", "dbo.Teams");
            DropForeignKey("dbo.SponsorTeams", "Sponsor_SponsorID", "dbo.Sponsors");
            DropIndex("dbo.SponsorTeams", new[] { "Team_TeamID" });
            DropIndex("dbo.SponsorTeams", new[] { "Sponsor_SponsorID" });
            DropIndex("dbo.Players", new[] { "TeamID" });
            DropTable("dbo.SponsorTeams");
            DropTable("dbo.Sponsors");
            DropTable("dbo.Teams");
            DropTable("dbo.Players");
        }
    }
}
