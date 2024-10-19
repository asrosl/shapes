namespace GeometryLib.Interfaces;

// Чтобы добавить новую фигуру, нужно лишь унаследовать структуру/класс от этого интерфейса и реализовать метод.

/// <summary>
/// Interface for geometric shapes.
/// </summary>
public interface IShape
{
    /// <summary>
    /// Calculates the area of the shape.
    /// </summary>
    /// <returns>The area.</returns>
    public double CalculateArea();
}