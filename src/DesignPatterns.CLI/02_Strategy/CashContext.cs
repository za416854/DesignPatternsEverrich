using System;

namespace DesignPatterns.CLI.Strategy;

/// <summary>
/// 策略與簡單工廠結合的 Context 類別
/// </summary>
public class CashContext
{
    // 聲明一個 CashSuper 策略物件
    private readonly CashSuper _cashSuper;

    /// <summary>
    /// 關鍵：結合簡單工廠模式。
    /// 將實例化具體策略的邏輯封裝在 Context 的建構子中，
    /// 這樣用戶端只需認識 CashContext 即可，完全與具體的收費演算法解耦。
    /// </summary>
    /// <param name="type">收費類型 (例如: "正常收費", "滿300送100", "打8折")</param>
    public CashContext(string type)
    {
        _cashSuper = type.Trim() switch
        {
            "正常收費" => new CashNormal(),
            "滿300送100" => new CashReturn(300, 100),
            "打8折" => new CashRebate(0.8),
            _ => throw new NotSupportedException($"不支援的收費類型: '{type}'")
        };
    }

    /// <summary>
    /// 根據收費類型計算實際收費金額
    /// </summary>
    /// <param name="money">原價金額</param>
    /// <returns>應付金額</returns>
    public double GetResult(double money)
    {
        return _cashSuper.AcceptCash(money);
    }
}
