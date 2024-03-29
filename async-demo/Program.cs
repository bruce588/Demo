﻿//#define AsyncDemo
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
namespace async_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string content = "";
            Stopwatch sw = new Stopwatch();
            sw.Start();

            //使用同步 與 非同步差異--------------------------------------------------------------            
#if AsyncDemo //<---(非同步:Step1) 
            Task<string> task= DownloadDataAsync();  
#else
            content = DownloadData();//使用同步   
#endif
            Console.WriteLine("do main 1");
            Thread.Sleep(500);
            Console.WriteLine("do main 2");
#if AsyncDemo //(非同步:step2)等待資料,直到取得資料
            content = task.Result;//取得資料的code放的位置很重要
#endif
            Console.WriteLine($"DownloadData=>{content}");
            //-------------------------------------------------------------- 
            sw.Stop();
            Console.WriteLine($"Total=>{sw.ElapsedMilliseconds} Milliseconds");
            Console.ReadLine();
        }



        public static string DownloadData()
        {
            string rturnData = "";
            Console.WriteLine("do Sub 1");
            Thread.Sleep(1000);
            rturnData= "『I am Date』";
            Console.WriteLine("do Sub 2");
            return rturnData;
        }


        public static async Task<string> DownloadDataAsync()
        {
          
            Task<string> task = new Task<string>(() =>
            {
                Thread.Sleep(1000);
                return "『I am Async Date』";

            });
            task.Start();
            Console.WriteLine("do Sub 1");
            string rturnData = await task;
            Console.WriteLine("do Sub 2");

            return rturnData;

        }
    }
}
