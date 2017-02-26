namespace eShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsersAndRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c0f14f4c-781d-47c2-a6d4-a07cb6e8d7a5', N'BreakdownManager@eShop.com', 0, N'ABjDd+zwJZsn9pbNldQZYSwpQrDCSrMLlaQLyh+iBy70vMiT4xcKoXN1ThPEXwW3Hg==', N'9c495517-28b3-4be2-a9ac-2df57218a368', NULL, 0, 0, NULL, 1, 0, N'BreakdownManager')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'fa1eecd6-b0db-4d50-a327-495cd2736c94', N'BreakdownViewer@eShop.com', 0, N'AOEiQLMXp8pq2yDSQuFakDedCrTde70ZgEI0PZj6TSMDmk6q6cOFscYV4oQ1he4ADA==', N'abc302aa-7523-475e-9889-35b297f5bb98', NULL, 0, 0, NULL, 1, 0, N'BreakdownViewer')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'0453da98-6bd6-4429-8b1b-c585698b2389', N'CanManageBreakdowns')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'5f850f68-62c2-4f74-a1f2-a32ef717fe9d', N'CanViewBreakdowns')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c0f14f4c-781d-47c2-a6d4-a07cb6e8d7a5', N'0453da98-6bd6-4429-8b1b-c585698b2389')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fa1eecd6-b0db-4d50-a327-495cd2736c94', N'5f850f68-62c2-4f74-a1f2-a32ef717fe9d')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
