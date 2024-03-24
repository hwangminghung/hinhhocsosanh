using System;
using System.Collections;
using System.Collections.Generic;

// Lớp hình học
public abstract class Shape
{
    public abstract double Area();
}

// Lớp hình chữ nhật
public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public override double Area()
    {
        return Width * Height;
    }
}

// Lớp hình vuông
public class Square : Shape
{
    public double Side { get; set; }

    public Square(double side)
    {
        Side = side;
    }

    public override double Area()
    {
        return Side * Side;
    }
}

// Lớp triển khai IComparer để so sánh các đối tượng hình học
public class ShapeComparer : IComparer<Shape>
{
    public int Compare(Shape x, Shape y)
    {
        if (x.Area() < y.Area())
            return -1;
        else if (x.Area() > y.Area())
            return 1;
        else
            return 0;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Shape[] shapes = new Shape[4];
        shapes[0] = new Rectangle(3, 4);
        shapes[1] = new Square(5);
        shapes[2] = new Rectangle(2, 6);
        shapes[3] = new Square(4);

        Console.WriteLine("Before sorting:");
        foreach (var shape in shapes)
        {
            Console.WriteLine(shape.Area());
        }

        Array.Sort(shapes, new ShapeComparer());

        Console.WriteLine("After sorting:");
        foreach (var shape in shapes)
        {
            Console.WriteLine(shape.Area());
        }
    }
}