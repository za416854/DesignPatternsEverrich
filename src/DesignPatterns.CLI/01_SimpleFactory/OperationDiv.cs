using System;

namespace DesignPatterns.CLI.SimpleFactory;

/// <summary>
/// 除法類別
/// </summary>
public class OperationDiv : Operation
{
    public override double GetResult()
    {
        if (NumberB == 0)
        {
            throw new ArgumentException("除數不能為 0。");
        }
        return NumberA / NumberB;
    }
}
