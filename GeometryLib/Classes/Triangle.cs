using GeometryLib.Interfaces;

namespace GeometryLib.Classes;

/// <summary>
/// Triangle.
/// </summary>
public record struct Triangle : IShape
{
    /// <summary>
    /// Triangle constructor.
    /// </summary>
    /// <param name="sideA">First side.</param>
    /// <param name="sideB">Second side.</param>
    /// <param name="sideC">Third side.</param>
    /// <exception cref="ArgumentException">Triangle with provided sides cannot exist.</exception>
    public Triangle(double sideA, double sideB, double sideC)
    {
        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
        CheckIfTriangleCanExist(); // Проверка, что треугольник может существовать
    }

    /// <summary>
    /// Triangle's first side.
    /// </summary>
    public double SideA { get; }

    /// <summary>
    /// Triangle's second side.
    /// </summary>
    public double SideB { get; }

    /// <summary>
    /// Triangle's third side.
    /// </summary>
    public double SideC { get; }

    /// <inheritdoc />
    public double CalculateArea()
    {
        var halfPerimeter = (SideA + SideB + SideC) / 2;
        return Math.Sqrt(halfPerimeter * (halfPerimeter - SideA) * (halfPerimeter - SideB) * (halfPerimeter - SideC));
    }

    /// <summary>
    /// Checks if triangle is right-angled.
    /// </summary>
    /// <returns>True - if triangle is right-angled. Otherwise - False.</returns>
    public bool IsRightAngled()
    {
        var aSquared = SideA * SideA;
        var bSquared = SideB * SideB;
        var cSquared = SideC * SideC;

        const double tolerance = 0.000001;
        var isRightAngled = Math.Abs(aSquared + bSquared - cSquared) < tolerance
                            || Math.Abs(aSquared + cSquared - bSquared) < tolerance
                            || Math.Abs(bSquared + cSquared - aSquared) < tolerance;

        return isRightAngled;
    }

    /// <summary>
    /// Checks if triangle with provided sides can exist.
    /// </summary>
    /// <exception cref="ArgumentException">Triangle with provided sides cannot exist.</exception>
    void CheckIfTriangleCanExist()
    {
        if (SideA + SideB <= SideC || SideA + SideC <= SideB || SideB + SideC <= SideA)
            throw new ArgumentException("Triangle is not possible");
    }
}