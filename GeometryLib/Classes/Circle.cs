using GeometryLib.Interfaces;

namespace GeometryLib.Classes;

/// <summary>
/// </summary>
/// <param name="Radius">Circle's radius.</param>
public record struct Circle(double Radius) : IShape
{
    /// <inheritdoc />
    public double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}