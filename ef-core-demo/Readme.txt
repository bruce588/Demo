--先建立類別

(已經建好了)

--套件安裝
https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/
dotnet add package Microsoft.EntityFrameworkCore.SqlServer 
dotnet add package Microsoft.EntityFrameworkCore.Design 
dotnet add package Microsoft.EntityFrameworkCore.Tools 


--Step 1 :建立資料庫
   到專案目錄下執行下列指令建立初始化DB的類別
   dotnet ef migrations add init    (依據Models中的類別產生db migration class)
   dotnet ef migrations script  0 init -o output.sql    (建議:產生SQL指令)
   dotnet ef database update -v                         (直截更新DB:不要再正式環境使用)
-------------------------------------------------------------------------------
--Step2 :修改資料庫
   2.1:在類別 Post 加上下列屬性
        public DateTime? UpdateTime { get; set; }
        public int? Counter { get; set; }

   2.2:到專案目錄下執行下列指令建立產生資料轉移(Migration)的類別    
       dotnet ef migrations add AddPostColumn

   2.3:手動調整 migrations 檔案,加入資料
       migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] {"BlogId", "Url" },
                values: new object[] { 1,"https://blog.darkthread.net/blog/ef-core-notes-5/" });
   2.4:產生 sql script
    dotnet ef migrations script  Init AddPostColumn -o Sql\Addcolumn.sql
---------------------------------------------------------------------------------
--Step 3:退版
    dotnet ef migrations script AddPostColumn init -o Sql\RemoveColumn.sql

