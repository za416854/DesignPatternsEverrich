using System;
using DesignPatterns.CLI.SimpleFactory;
using DesignPatterns.CLI.Strategy;
using DesignPatterns.CLI.SingleResponsibility;

namespace DesignPatterns.CLI;

internal class Program
{
    private static void Main(string[] args)
    {
        // 設定主控台編碼，避免中文字元出現亂碼
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("==================================================");
            Console.WriteLine("      🌟  大話設計模式 .NET 9 實作展示專案  🌟      ");
            Console.WriteLine("==================================================");
            Console.ResetColor();

            Console.WriteLine("\n請選擇您想要執行的設計模式示範：\n");
            
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  [1] 簡單工廠模式 (第一章 - 計算機)");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("  [2] 策略模式 + 簡單工廠 (第二章 - 商場收銀)");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("  [3] 單一職責原則 (SRP - 發票結帳)");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("  ----------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  [Q] 離開程式");
            Console.ResetColor();

            Console.Write("\n👉 請輸入選項 (1、2、3 或 Q): ");
            string? choice = Console.ReadLine()?.Trim().ToLower();

            if (choice == "q")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n感謝您的使用，祝您學習愉快！再見！");
                Console.ResetColor();
                break;
            }

            switch (choice)
            {
                case "1":
                    SimpleFactoryDemo.Run();
                    break;
                case "2":
                    StrategyDemo.Run();
                    break;
                case "3":
                    SingleResponsibilityDemo.Run();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n[錯誤] 無效的選項，請按任意鍵重新輸入...");
                    Console.ResetColor();
                    Console.ReadKey();
                    break;
            }
        }
    }
}
