namespace DesignPatterns.CLI.Strategy;

/// <summary>
/// 打折收費子類別
/// </summary>
public class CashRebate : CashSuper
{
    private readonly double _moneyRebate = 1d;

    /// <summary>
    /// 建構子，傳入折扣率 (例如: 0.8 代表打八折)
    /// </summary>
    public CashRebate(double moneyRebate)
    {
        _moneyRebate = moneyRebate;
    }

    public override double AcceptCash(double money)
    {
        return money * _moneyRebate;
    }
}
