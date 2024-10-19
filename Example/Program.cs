using GeometryLib.Classes;
using GeometryLib.Interfaces;

// Массив неопределенных фигур
IShape[] shapes = [new Triangle(3, 4, 5), new Circle(1)];

foreach (var shape in shapes)
    // Расчёт площади в runtime
    Console.WriteLine(shape.CalculateArea());

// Проверка созданного треугольника на прямоугольность
var triangle = new Triangle(3, 4, 5);
var notPrefix = triangle.IsRightAngled() ? "" : "not ";
Console.WriteLine(
    $"A triangle with sides {triangle.SideA}, {triangle.SideB}, {triangle.SideC} is {notPrefix}right-angled");


/*
Предположу, что в БД есть таблицы Products, Categories и Product_Category для N-to-N связей.
Код создания БД:

CREATE TABLE Products (
    ProductId INT PRIMARY KEY,
    ProductName VARCHAR(50)
);

CREATE TABLE Categories (
    CategoryId INT PRIMARY KEY,
    CategoryName VARCHAR(50)
);

CREATE TABLE Product_Category (
    ProductId INT,
    CategoryId INT,
    PRIMARY KEY (ProductId, CategoryId),
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId),
    FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId)
);

Выбираем все продукты с категориями и без (null)

SELECT Products.ProductName, Categories.CategoryName
FROM Products
LEFT JOIN Product_Category ON Products.ProductId = Product_Category.ProductId
LEFT JOIN Categories ON Product_Category.CategoryId = Categories.CategoryId;
*/