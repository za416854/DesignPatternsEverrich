using System;

namespace DesignPatterns.CLI.SimpleFactory;

/// <summary>
/// 簡單工廠模式示範器
/// </summary>
public static class SimpleFactoryDemo
{
    public static void Run()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("========================================");
        Console.WriteLine("       設計模式：簡單工廠 (Simple Factory) ");
        Console.WriteLine("       情境：大話設計模式第一章 - 計算機");
        Console.WriteLine("========================================");
        Console.ResetColor();

        try
        {
            Console.Write("請輸入數字 A: ");
            if (!double.TryParse(Console.ReadLine(), out double numberA))
            {
                throw new ArgumentException("數字 A 輸入格式錯誤！");
            }

            Console.Write("請輸入運算子 (+、-、*、/): ");
            string? operate = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(operate))
            {
                throw new ArgumentException("運算子不能為空！");
            }

            Console.Write("請輸入數字 B: ");
            if (!double.TryParse(Console.ReadLine(), out double numberB))
            {
                throw new ArgumentException("數字 B 輸入格式錯誤！");
            }

            // 使用簡單工廠建立具體的運算物件
            Operation oper = OperationFactory.CreateOperate(operate);
            oper.NumberA = numberA;
            oper.NumberB = numberB;

            double result = oper.GetResult();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"計算結果: {numberA} {operate} {numberB} = {result}");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[錯誤] 發生異常: {ex.Message}");
            Console.ResetColor();
        }

        Console.WriteLine("\n按任意鍵返回主選單...");
        Console.ReadKey();
    }
}
