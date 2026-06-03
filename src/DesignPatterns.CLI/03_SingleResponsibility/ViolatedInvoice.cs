using System;
using System.Collections.Generic;
using System.IO;

namespace DesignPatterns.CLI.SingleResponsibility;

public class InvoiceItem
{
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public int Quantity { get; set; }
}

/// <summary>
/// 違反單一職責原則 (SRP) 的類別。
/// 此類別同時負責：
/// 1. 儲存與計算發票資料 (業務邏輯)
/// 2. 將發票內容格式化並輸出至螢幕 (呈現邏輯)
/// 3. 將發票儲存至外部檔案 (持久化邏輯)
/// </summary>
public class ViolatedInvoice
{
    public string InvoiceId { get; set; } = string.Empty;
    public List<InvoiceItem> Items { get; set; } = new();
    public double TaxRate { get; set; } = 0.05; // 5% 營業稅

    public double CalculateSubTotal()
    {
        double subtotal = 0;
        foreach (var item in Items)
        {
            subtotal += item.Price * item.Quantity;
        }
        return subtotal;
    }

    public double CalculateTax()
    {
        return CalculateSubTotal() * TaxRate;
    }

    public double CalculateTotal()
    {
        return CalculateSubTotal() + CalculateTax();
    }

    // 責任 2: 呈現邏輯 (與 Console 輸出強烈耦合)
    public void PrintInvoice()
    {
        Console.WriteLine($"發票編號: {InvoiceId}");
        Console.WriteLine("----------------------------------------");
        foreach (var item in Items)
        {
            Console.WriteLine($"{item.Name} - {item.Price:C} x {item.Quantity} = {item.Price * item.Quantity:C}");
        }
        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"銷售金額: {CalculateSubTotal():C}");
        Console.WriteLine($"營業稅額 (5%): {CalculateTax():C}");
        Console.WriteLine($"總計金額: {CalculateTotal():C}");
    }

    // 責任 3: 持久化邏輯 (與 檔案系統/IO 強烈耦合)
    public void SaveToFile(string filePath)
    {
        using var writer = new StreamWriter(filePath);
        writer.WriteLine($"發票編號: {InvoiceId}");
        writer.WriteLine("----------------------------------------");
        foreach (var item in Items)
        {
            writer.WriteLine($"{item.Name} - {item.Price:C} x {item.Quantity} = {item.Price * item.Quantity:C}");
        }
        writer.WriteLine("----------------------------------------");
        writer.WriteLine($"銷售金額: {CalculateSubTotal():C}");
        writer.WriteLine($"營業稅額: {CalculateTax():C}");
        writer.WriteLine($"總計金額: {CalculateTotal():C}");
    }
}
