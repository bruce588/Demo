step1:安裝Jwt套件
  dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 3.1.5

Step2:將 JwtHelper類別加到專案中

Step3:Startup.ConfigureServices JwtHelper,AuthenticationScheme 注入DI容器中
 
        services.AddSingleton<JwtHelper>();//身分驗證的物件註冊
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)

Step4: Startup.Configure 到Middleware中加入驗證
        app.UseAuthentication();//(要加入驗證的Middleware)

Step4:加入驗證的controller
        TokenController.cs

step5:jwt私鑰 放到 appsettings.json 檔案中
    "JwtSettings": {
    "Issuer": "JwtAuthDemo",
    "SignKey": "1Zl4h9701234563IzROikK3@uK&&OEb"
    },
--------------------------------------------------
step5:測試 https://localhost:5001/api/demo
step6:Login https://localhost:5001/signin
            帶入帳密
            {
            "Username":"bruce",
            "Password":"123456"
            }
  