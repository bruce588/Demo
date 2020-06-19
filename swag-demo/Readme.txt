
Step1:安裝NSwag套件
	dotnet add  package NSwag.AspNetCore

Step2:
    到  Startup.ConfigureServices 加入下列程式碼 
           services.AddSwaggerDocument();//(將SwaggerDocument 注入DI容器中)

Step3:

    到  Startup.Configure 將 Swagger generator 與 Swagger UI 註冊到Middleware
    app.UseOpenApi();// Register the Swagger generator and the Swagger UI middlewares
    app.UseSwaggerUi3();