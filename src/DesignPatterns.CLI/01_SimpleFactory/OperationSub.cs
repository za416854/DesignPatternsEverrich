namespace DesignPatterns.CLI.SimpleFactory;

/// <summary>
/// 減法類別
/// </summary>
public class OperationSub : Operation
{
    public override double GetResult()
    {
        return NumberA - NumberB;
    }
}
