1.CMD下輸入(安裝全域工具:前端函式庫管理)
   dotnet tool install -g Microsoft.Web.LibraryManager.Cli
2.上述工具安裝完後就可使用下列指令下載前端signalR包
 libman install @microsoft/signalr@latest -p unpkg -d wwwroot/js/signalr --files dist/browser/signalr.js --files dist/browser/signalr.min.js