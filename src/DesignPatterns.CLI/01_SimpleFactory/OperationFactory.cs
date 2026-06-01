using System;

namespace DesignPatterns.CLI.SimpleFactory;

/// <summary>
/// 運算工廠類別
/// </summary>
public static class OperationFactory
{
    /// <summary>
    /// 根據傳入的運算子，實例化對應的運算子類別
    /// </summary>
    /// <param name="operate">運算子字符</param>
    /// <returns>具體的運算類別實例</returns>
    public static Operation CreateOperate(string operate)
    {
        return operate.Trim() switch
        {
            "+" => new OperationAdd(),
            "-" => new OperationSub(),
            "*" or "x" or "X" => new OperationMul(),
            "/" => new OperationDiv(),
            _ => throw new NotSupportedException($"不支援的運算子: '{operate}'")
        };
    }
}
