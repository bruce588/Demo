step1:安裝serilog
		dotnet add package serilog.aspnetcore

		dotnet add package Serilog.Sinks.Console
		dotnet add package Serilog.Sinks.File
        dotnet add package Serilog.Sinks.Seq
	 
1. 初始化Serilog 紀錄器


2. 在Program.Main 加入Serilog組態設定
	       
		  Log.Logger = new LoggerConfiguration()
              .MinimumLevel.Debug()
              .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
              .Enrich.FromLogContext()
              .WriteTo.Console()
              .WriteTo.File(@"G:\serial.log")  
              .WriteTo.Seq("http://localhost:5341") 
              .CreateLogger();

            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            finally
            {
                Log.CloseAndFlush();//當應用程式有錯誤要將最後的錯誤寫入Log
            }

 3. 在Program.CreateHostBuilder 中宣告改使用Serilog
            Host.UseSerilog();


 