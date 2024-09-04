using System;
using System.Collections.Generic;

public struct Point
{
    public double X { get; }
    public double Y { get; }

    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return $"({X},{Y})";
    }

    public double DistanceTo(Point other)
    {
        double dx = X - other.X;
        double dy = Y - other.Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }

    public double DistanceToOrigin()
    {
        return Math.Sqrt(X * X + Y * Y);
    }
}

public class Triangle
{
    public Point Vertex1 { get; }
    public Point Vertex2 { get; }
    public Point Vertex3 { get; }

    public Triangle(Point vertex1, Point vertex2, Point vertex3)
    {
        Vertex1 = vertex1;
        Vertex2 = vertex2;
        Vertex3 = vertex3;
    }

    public double Perimeter()
    {
        double side1 = Vertex1.DistanceTo(Vertex2);
        double side2 = Vertex2.DistanceTo(Vertex3);
        double side3 = Vertex3.DistanceTo(Vertex1);
        return side1 + side2 + side3;
    }

    public double Area()
    {
        double a = Vertex1.DistanceTo(Vertex2);
        double b = Vertex2.DistanceTo(Vertex3);
        double c = Vertex3.DistanceTo(Vertex1);
        double s = (a + b + c) / 2;
        return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
    }

    public void Print()
    {
        Console.WriteLine($"Triangle vertices: {Vertex1}, {Vertex2}, {Vertex3}");
        Console.WriteLine($"Perimeter: {Perimeter()}");
        Console.WriteLine($"Area: {Area()}");
    }

    public Point ClosestVertexToOrigin()
    {
        double distance1 = Vertex1.DistanceToOrigin();
        double distance2 = Vertex2.DistanceToOrigin();
        double distance3 = Vertex3.DistanceToOrigin();

        if (distance1 <= distance2 && distance1 <= distance3)
            return Vertex1;
        else if (distance2 <= distance1 && distance2 <= distance3)
            return Vertex2;
        else
            return Vertex3;
    }
}

public class Program
{
    public static void StudentMain()
    {
        var triangles = new List<Triangle>
        {
            new Triangle(new Point(0, 0), new Point(1, 0), new Point(0, 1)),
            new Triangle(new Point(0, 0), new Point(2, 0), new Point(1, 2)),
            new Triangle(new Point(1, 1), new Point(4, 1), new Point(1, 3))
        };

        Triangle closestTriangle = null;
        Point closestVertex = new Point(double.MaxValue, double.MaxValue);

        foreach (var triangle in triangles)
        {
            triangle.Print();
            Console.WriteLine();

            var currentClosestVertex = triangle.ClosestVertexToOrigin();
            if (currentClosestVertex.DistanceToOrigin() < closestVertex.DistanceToOrigin())
            {
                closestVertex = currentClosestVertex;
                closestTriangle = triangle;
            }
        }

        Console.WriteLine("Triangle with a vertex closest to the origin:");
        closestTriangle.Print();
    }

    public static void Main(string[] args)
    {
        StudentMain();
    }
}
