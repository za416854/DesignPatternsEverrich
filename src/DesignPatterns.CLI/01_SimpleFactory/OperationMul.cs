namespace DesignPatterns.CLI.SimpleFactory;

/// <summary>
/// 乘法類別
/// </summary>
public class OperationMul : Operation
{
    public override double GetResult()
    {
        return NumberA * NumberB;
    }
}
