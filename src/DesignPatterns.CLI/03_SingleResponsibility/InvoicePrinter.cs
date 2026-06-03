using System;

namespace DesignPatterns.CLI.SingleResponsibility;

/// <summary>
/// 符合單一職責原則的發票列印類別。
/// 職責：僅負責將發票資料格式化輸出至螢幕 (呈現邏輯)
/// </summary>
public class InvoicePrinter
{
    public void Print(Invoice invoice)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"發票編號: {invoice.InvoiceId}");
        Console.WriteLine("----------------------------------------");
        Console.ResetColor();

        foreach (var item in invoice.Items)
        {
            Console.WriteLine($"{item.Name,-15} - {item.Price,8:C} x {item.Quantity} = {(item.Price * item.Quantity),8:C}");
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"銷售金額: {invoice.CalculateSubTotal(),26:C}");
        Console.WriteLine($"營業稅額 ({(invoice.TaxRate * 100)}%): {invoice.CalculateTax(),20:C}");
        Console.WriteLine($"總計金額: {invoice.CalculateTotal(),26:C}");
        Console.ResetColor();
    }
}
