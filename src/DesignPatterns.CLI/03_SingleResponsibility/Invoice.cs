using System.Collections.Generic;

namespace DesignPatterns.CLI.SingleResponsibility;

/// <summary>
/// 符合單一職責原則的發票類別。
/// 職責：僅負責發票資料模型與數值計算 (業務邏輯)
/// </summary>
public class Invoice
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
}
