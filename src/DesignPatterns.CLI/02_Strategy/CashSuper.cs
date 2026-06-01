namespace DesignPatterns.CLI.Strategy;

/// <summary>
/// 收費抽象類別 (大話設計模式：第二章)
/// </summary>
public abstract class CashSuper
{
    /// <summary>
    /// 根據原價計算實際收費金額
    /// </summary>
    /// <param name="money">原價金額</param>
    /// <returns>實際應收金額</returns>
    public abstract double AcceptCash(double money);
}
