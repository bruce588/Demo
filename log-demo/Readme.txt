 --可到appsettings.json 改變追中類別
 Trace, Debug, Information, Warning, Error, Critical, None
 --於Program.CreateHostBuilder 加入下方程式碼可變更log輸出選項
 webBuilder.ConfigureLogging(logger =>
                    {
                        logger.ClearProviders();
                        logger.AddConsole();
                        logger.AddEventLog();
                    });