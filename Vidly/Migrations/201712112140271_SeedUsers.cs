namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'901f69ad-27f8-43b5-8fcd-403958344528', N'admin@vidly.com', 0, N'APqyN4LWUpni6AAQ7uoWmFp6gNP+cHuaeMgoYmMFg2ZAUmjD7L8UUUTrgItACpCZQQ==', N'7de82b78-f71a-4b1d-aa35-56ca800c599d', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'cf307371-6c25-4a5f-a181-67f3ba9b0a69', N'guest@vidly.com', 0, N'ACqtyLvcQdOR8jr0waSYR95guwpbwK9X7Z0v6qa/jJeAQz7HFN75D0IXUUmjiRAg8g==', N'426045c1-9ed0-436b-8962-980f0cf935b8', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'8e23eed6-70e1-42c9-b190-460568a15e39', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'901f69ad-27f8-43b5-8fcd-403958344528', N'8e23eed6-70e1-42c9-b190-460568a15e39')


");
        }
        
        public override void Down()
        {
        }
    }
}
