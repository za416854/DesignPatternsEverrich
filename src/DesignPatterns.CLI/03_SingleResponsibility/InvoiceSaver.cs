using System.IO;

namespace DesignPatterns.CLI.SingleResponsibility;

/// <summary>
/// 符合單一職責原則的發票儲存類別。
/// 職責：僅負責將發票資料寫入外部儲存媒體 (持久化邏輯)
/// </summary>
public class InvoiceSaver
{
    public void SaveToFile(Invoice invoice, string filePath)
    {
        using var writer = new StreamWriter(filePath);
        writer.WriteLine($"[符合 SRP 設計] 發票儲存備份");
        writer.WriteLine($"發票編號: {invoice.InvoiceId}");
        writer.WriteLine("----------------------------------------");
        foreach (var item in invoice.Items)
        {
            writer.WriteLine($"{item.Name} - {item.Price:C} x {item.Quantity} = {item.Price * item.Quantity:C}");
        }
        writer.WriteLine("----------------------------------------");
        writer.WriteLine($"銷售金額: {invoice.CalculateSubTotal():C}");
        writer.WriteLine($"營業稅額 ({(invoice.TaxRate * 100)}%): {invoice.CalculateTax():C}");
        writer.WriteLine($"總計金額: {invoice.CalculateTotal():C}");
    }
}
