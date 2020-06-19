--將連線字串加入



Step1:連線字串放到設定檔中=> 到appsetting.json 將連線字串加到json中
          "ConnectionStrings": {
              "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=BlogDB;Trusted_Connection=True;MultipleActiveResultSets=true"
          },

Step2:到 Startup.ConfigureServices  (將DBContext 注入DI容器中)
                    services.AddDbContext<MyDBContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                    );

Step3:controllers 右鍵=>加入控制器
                Blugs
                Post

Step4:啟動API測試:
      4.1   dotnet watch run  (到CMD輸入)
      4.2   開啟Postman 做測試
            查詢(GET):https://localhost:5001/api/blogs
            新增(POST):https://localhost:5001/api/posts
                    {
                    "postId": 1,
                    "title": "Core 3.0",
                    "content": "New features in Entity Framework Core 3.0",
                    "blogId": 1,
                    "counter": 1,
                    "updateTime": null,
                    "blog": null
                  }
           修改(PUT):https://localhost:5001/api/posts/2
           刪除(Delete):https://localhost:5001/api/posts/1

 

Step4:分析器加入:
      4.1 查詢(GET):https://localhost:5001/api/blogs/2
      4.2 安裝分析器(在專案檔中加入):
      <PropertyGroup>
        <IncludeOpenAPIAnalyzers>true</IncludeOpenAPIAnalyzers> 
      </PropertyGroup>
