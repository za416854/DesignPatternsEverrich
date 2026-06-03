using System;
using System.Collections.Generic;
using System.IO;

namespace DesignPatterns.CLI.SingleResponsibility;

/// <summary>
/// 單一職責原則示範器
/// </summary>
public static class SingleResponsibilityDemo
{
    public static void Run()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("========================================");
        Console.WriteLine("      設計原則：單一職責原則 (SRP) ");
        Console.WriteLine("      Single Responsibility Principle");
        Console.WriteLine("========================================");
        Console.ResetColor();

        // 準備測試資料
        var items = new List<InvoiceItem>
        {
            new() { Name = "大話設計模式", Price = 580, Quantity = 1 },
            new() { Name = ".NET 9 核心開發", Price = 650, Quantity = 2 },
            new() { Name = "極速滑鼠墊", Price = 120, Quantity = 3 }
        };

        string invoiceId = "INV-2026-0001";
        string violatedFile = "ViolatedInvoice_Backup.txt";
        string srpFile = "SrpInvoice_Backup.txt";

        Console.WriteLine("\n[1] 執行【違反 SRP】的發票物件模式：");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("--> ViolatedInvoice 類別除了計算，還包攬了 Console 列印與檔案寫入責任。");
        Console.ResetColor();

        var violatedInvoice = new ViolatedInvoice
        {
            InvoiceId = invoiceId,
            Items = items
        };

        // 呼叫違反 SRP 物件的方法
        violatedInvoice.PrintInvoice();
        violatedInvoice.SaveToFile(violatedFile);
        Console.WriteLine($"[完成] 檔案已備份至: {Path.GetFullPath(violatedFile)}");

        Console.WriteLine("\n========================================\n");

        Console.WriteLine("[2] 執行【符合 SRP】的發票物件模式：");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("--> 將職責分離成 Invoice (業務/資料)、InvoicePrinter (呈現)、InvoiceSaver (儲存) 三個獨立類別。");
        Console.ResetColor();

        // 職責 1: 業務模型與計算
        var invoice = new Invoice
        {
            InvoiceId = invoiceId,
            Items = items
        };

        // 職責 2: 負責列印 (呈現)
        var printer = new InvoicePrinter();
        printer.Print(invoice);

        // 職責 3: 負責儲存 (持久化)
        var saver = new InvoiceSaver();
        saver.SaveToFile(invoice, srpFile);
        Console.WriteLine($"[完成] 檔案已備份至: {Path.GetFullPath(srpFile)}");

        Console.WriteLine("\n========================================");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("💡 【大話設計模式觀念解析】");
        Console.WriteLine("Q: 為什麼要將列印與儲存職責抽離？");
        Console.WriteLine("A: 假設明天客戶提出新要求：");
        Console.WriteLine("   1. 「我們要把發票輸出成 HTML 格式，而不是 Console 纯文字。」");
        Console.WriteLine("   2. 「我們希望把發票儲存至 SQL Database，而不是 TXT 文字檔。」");
        Console.WriteLine();
        Console.ResetColor();
        Console.WriteLine("👉 違反 SRP 的情況：");
        Console.WriteLine("   你必須修改 ViolatedInvoice 類別。任何對該類別的修改，都可能不小心破壞原本正確的『金額計算』邏輯。");
        Console.WriteLine();
        Console.WriteLine("👉 符合 SRP 的情況：");
        Console.WriteLine("   你完全不需要修改 Invoice 類別！");
        Console.WriteLine("   你只需要新建一個 InvoiceHtmlPrinter 類別，或新建一個 InvoiceDbSaver 類別。");
        Console.WriteLine("   核心計算邏輯 Invoice.cs 被完美保護，不受外界變化影響！");
        Console.WriteLine("========================================");

        // 清理暫存檔
        try
        {
            if (File.Exists(violatedFile)) File.Delete(violatedFile);
            if (File.Exists(srpFile)) File.Delete(srpFile);
        }
        catch { /* 忽略清理錯誤 */ }

        Console.WriteLine("\n按任意鍵返回主選單...");
        Console.ReadKey();
    }
}
