using System;
using System.Collections.Generic;

namespace DesignPatterns.CLI.Strategy;

/// <summary>
/// 策略模式示範器 (商場收銀系統)
/// </summary>
public static class StrategyDemo
{
    public static void Run()
    {
        double total = 0d;
        var items = new List<string>();

        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("========================================");
            Console.WriteLine("    設計模式：策略模式 + 簡單工廠 (Strategy) ");
            Console.WriteLine("    情境：大話設計模式第二章 - 商場收銀系統");
            Console.WriteLine("========================================");
            Console.ResetColor();

            // 顯示購物籃中的品項
            if (items.Count > 0)
            {
                Console.WriteLine("【當前購物籃清單】");
                foreach (var item in items)
                {
                    Console.WriteLine(item);
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"累計應付總金額: NT$ {total:F2}");
                Console.ResetColor();
                Console.WriteLine("----------------------------------------");
            }

            Console.WriteLine("請輸入商品資訊 (或輸入 'q' 結束本次結帳並返回選單)：");
            
            Console.Write("👉 商品單價: ");
            string? priceInput = Console.ReadLine();
            if (priceInput?.Trim().ToLower() == "q") break;
            
            if (!double.TryParse(priceInput, out double price) || price < 0)
            {
                ShowError("單價格式錯誤，請輸入大於等於 0 的數字！");
                continue;
            }

            Console.Write("👉 商品數量: ");
            string? qtyInput = Console.ReadLine();
            if (qtyInput?.Trim().ToLower() == "q") break;
            
            if (!int.TryParse(qtyInput, out int qty) || qty <= 0)
            {
                ShowError("數量格式錯誤，請輸入大於 0 的整數！");
                continue;
            }

            Console.WriteLine("👉 選擇收費促銷策略:");
            Console.WriteLine("  [1] 正常收費");
            Console.WriteLine("  [2] 滿 300 送 100");
            Console.WriteLine("  [3] 打 8 折");
            Console.Write("請輸入編號 (預設為 1): ");
            string? choice = Console.ReadLine();

            string strategyType = choice?.Trim() switch
            {
                "2" => "滿300送100",
                "3" => "打8折",
                _ => "正常收費"
            };

            try
            {
                // 使用 Strategy + Simple Factory 封裝的 Context
                CashContext cc = new CashContext(strategyType);
                
                double rawTotal = price * qty;
                double finalTotal = cc.GetResult(rawTotal);

                total += finalTotal;
                
                string itemRecord = $"- 單價 {price:C} x 數量 {qty} = 原價 {rawTotal:C} ({strategyType} -> 實收 {finalTotal:C})";
                items.Add(itemRecord);
            }
            catch (Exception ex)
            {
                ShowError($"計算出錯: {ex.Message}");
            }
        }

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("================結帳清單=================");
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"總應付金額 (含折扣返利): NT$ {total:F2}");
        Console.WriteLine("========================================");
        Console.ResetColor();

        Console.WriteLine("\n按任意鍵返回主選單...");
        Console.ReadKey();
    }

    private static void ShowError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n[錯誤] {message}");
        Console.ResetColor();
        Console.WriteLine("按任意鍵重新輸入...");
        Console.ReadKey();
    }
}
