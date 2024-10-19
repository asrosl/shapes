using GeometryLib.Classes;

namespace Tests;

// Тесты методов на все возможные результаты с помощью XUnit.
// Random используется для разнообразия исходных тестовых данных. При этом указание seed позволяет воспроизводить тесты.
public class ShapeTests
{
    [Theory(DisplayName = "Правильно посчитать площадь треугольника")]
    [InlineData(byte.MaxValue)]
    [InlineData(short.MaxValue)]
    [InlineData(ushort.MaxValue)]
    public void ShouldCalculateValidTriangleArea(int seed)
    {
        // Arrange
        var random = new Random(seed);

        var sideA = random.Next(1, 100);
        var sideB = random.Next(1, 100);

        var (minC, maxC) = GetThirdSideLimits(sideA, sideB);

        // Generate the third side within the valid range.
        var sideC = random.Next(minC, maxC);

        var halfPerimeter = (sideA + sideB + sideC) / 2d;
        var manualArea = Math.Sqrt((halfPerimeter - sideA)
                                   * (halfPerimeter - sideB)
                                   * (halfPerimeter - sideC)
                                   * halfPerimeter);

        var triangle = new Triangle(sideA, sideB, sideC);

        // Act
        var calculatedArea = triangle.CalculateArea();

        // Assert
        Assert.Equal(manualArea, calculatedArea);
    }

    [Theory(DisplayName = "Бросить исключение при попытке создании невозможного треугольника")]
    [InlineData(byte.MaxValue)]
    [InlineData(short.MaxValue)]
    [InlineData(ushort.MaxValue)]
    public void ShouldThrowExceptionWhenTriangleCannotExist(int seed)
    {
        // Arrange
        var random = new Random(seed);

        var sideA = random.Next(1, 100);
        var sideB = random.Next(1, 100);

        var (_, maxC) = GetThirdSideLimits(sideA, sideB);

        // Generate the third side within the valid range.
        var sideC = random.Next(maxC, int.MaxValue);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Triangle(sideA, sideB, sideC));
    }

    [Theory(DisplayName = "Проверить, что треугольник считается прямоугольным")]
    [InlineData(byte.MaxValue)]
    [InlineData(short.MaxValue)]
    [InlineData(ushort.MaxValue)]
    public void ShouldSuccessfullyCheckIfTriangleIsRightAngled(int seed)
    {
        // Arrange
        var random = new Random(seed);

        var sideA = random.Next(1, 100);
        var sideB = random.Next(1, 100);
        var sideC = Math.Sqrt(sideA * sideA + sideB * sideB);

        var triangle = new Triangle(sideA, sideB, sideC);

        // Act
        var isRightAngled = triangle.IsRightAngled();

        // Assert
        Assert.True(isRightAngled);
    }

    [Theory(DisplayName = "Проверить, что треугольник не считается прямоугольным")]
    [InlineData(byte.MaxValue)]
    [InlineData(short.MaxValue)]
    [InlineData(ushort.MaxValue)]
    public void ShouldSuccessfullyCheckIfTriangleIsNotRightAngled(int seed)
    {
        // Arrange
        var random = new Random(seed);

        var sideA = random.Next(1, 100);
        var sideB = random.Next(1, 100);
        var sideC = Math.Sqrt(sideA * sideA + sideB * sideB) + 0.1;

        var triangle = new Triangle(sideA, sideB, sideC);

        // Act
        var isRightAngled = triangle.IsRightAngled();

        // Assert
        Assert.False(isRightAngled);
    }

    [Theory(DisplayName = "Правильно посчитать площадь круга")]
    [InlineData(byte.MaxValue)]
    [InlineData(short.MaxValue)]
    [InlineData(ushort.MaxValue)]
    public void ShouldCalculateValidCircleArea(int seed)
    {
        // Arrange
        var random = new Random(seed);

        var radius = random.Next(1, 100);
        var expectedArea = Math.PI * radius * radius;

        var circle = new Circle(radius);

        // Act
        var actualArea = circle.CalculateArea();

        // Assert
        Assert.Equal(expectedArea, actualArea);
    }

    /// <summary>
    /// Calculate the range for the third side of triangle.
    /// </summary>
    /// <param name="sideA">First side.</param>
    /// <param name="sideB">Second side.</param>
    /// <returns>Min and max third side limits.</returns>
    static (int minC, int maxC) GetThirdSideLimits(int sideA, int sideB)
    {
        // Must be greater than |a - b|.
        var minC = Math.Abs(sideA - sideB);
        // Must be less than a + b.
        var maxC = sideA + sideB;
        return (minC, maxC);
    }
}