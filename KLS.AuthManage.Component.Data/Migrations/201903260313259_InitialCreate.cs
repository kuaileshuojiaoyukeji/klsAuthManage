namespace KLS.AuthManage.Component.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        CourseGuid = c.String(maxLength: 50),
                        CourseName = c.String(maxLength: 100),
                        Sort = c.Int(),
                        CreateTime = c.DateTime(),
                        Disabled = c.Boolean(),
                        SubjectID = c.Int(),
                        Remark = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.CourseID);
            
            CreateTable(
                "dbo.CourseItem",
                c => new
                    {
                        CourseItemID = c.Int(nullable: false, identity: true),
                        CourseItemName = c.String(nullable: false, maxLength: 100),
                        Sort = c.Int(nullable: false),
                        Year = c.Int(),
                        Area = c.String(maxLength: 20),
                        OriginalPrice = c.Decimal(storeType: "money"),
                        DiscountPrice = c.Decimal(storeType: "money"),
                        CoursePrice = c.Decimal(storeType: "money"),
                        ServiceTimeStart = c.DateTime(),
                        ServiceTimeEnd = c.DateTime(),
                        Disabled = c.Boolean(),
                        CourseID = c.Int(),
                        CreateTime = c.DateTime(),
                        Remark = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.CourseItemID);
            
            CreateTable(
                "dbo.CourseItemChapter",
                c => new
                    {
                        ChapterID = c.Int(nullable: false, identity: true),
                        ChapterName = c.String(nullable: false, maxLength: 200),
                        Sort = c.Int(),
                        CourseItemID = c.Int(),
                        Payment = c.Int(),
                        ItemCount = c.Int(),
                        ParentID = c.Int(),
                        CreateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.ChapterID);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        SubjectID = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(nullable: false, maxLength: 100),
                        Sort = c.Int(),
                        CreateTime = c.DateTime(),
                        Remark = c.String(maxLength: 200),
                        IsShow = c.Boolean(),
                        Type = c.String(maxLength: 50),
                        IsProxy = c.Boolean(),
                        SubjectClass = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.SubjectID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Subject");
            DropTable("dbo.CourseItemChapter");
            DropTable("dbo.CourseItem");
            DropTable("dbo.Course");
        }
    }
}
