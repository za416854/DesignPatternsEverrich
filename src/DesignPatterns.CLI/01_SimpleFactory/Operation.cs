namespace DesignPatterns.CLI.SimpleFactory;

/// <summary>
/// 運算基礎類別 (大話設計模式：第一章)
/// </summary>
public abstract class Operation
{
    public double NumberA { get; set; }
    public double NumberB { get; set; }

    /// <summary>
    /// 取得運算結果
    /// </summary>
    public abstract double GetResult();
}
