namespace DesignPatterns.CLI.Strategy;

/// <summary>
/// 正常收費子類別
/// </summary>
public class CashNormal : CashSuper
{
    public override double AcceptCash(double money)
    {
        return money;
    }
}
