namespace DesignPatterns.CLI.SimpleFactory;

/// <summary>
/// 加法類別
/// </summary>
public class OperationAdd : Operation
{
    public override double GetResult()
    {
        return NumberA + NumberB;
    }
}
