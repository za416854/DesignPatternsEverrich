using System;

namespace DesignPatterns.CLI.Strategy;

/// <summary>
/// 返利收費子類別 (例如: 滿300送100)
/// </summary>
public class CashReturn : CashSuper
{
    private readonly double _moneyCondition = 0d;
    private readonly double _moneyReturn = 0d;

    /// <summary>
    /// 建構子，傳入滿減條件與返還金額
    /// </summary>
    /// <param name="moneyCondition">滿額門檻</param>
    /// <param name="moneyReturn">返還金額</param>
    public CashReturn(double moneyCondition, double moneyReturn)
    {
        _moneyCondition = moneyCondition;
        _moneyReturn = moneyReturn;
    }

    public override double AcceptCash(double money)
    {
        double result = money;
        if (money >= _moneyCondition && _moneyCondition > 0)
        {
            result = money - Math.Floor(money / _moneyCondition) * _moneyReturn;
        }
        return result;
    }
}
