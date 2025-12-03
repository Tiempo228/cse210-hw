using System;
using System.Collections;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Shapes Project.");

        // Create a Square instance
        Shape square = new Square("Red", 5);
        Shape rectangle = new Rectangle("Green", 10, 5);
        Shape circle = new Circle("Yellow", 5);

        // Call the GetColor() and GetArea() methods and make sure they return the values you expect.
        Console.WriteLine(square.GetColor());
        Console.WriteLine(square.GetArea());

        Console.WriteLine(rectangle.GetColor());
        Console.WriteLine(rectangle.GetArea());

        Console.WriteLine(circle.GetColor());
        Console.WriteLine(circle.GetArea());

        // Create a list to hold shapes
        List<Shape> list = new List<Shape>{
            square, rectangle, circle
        };

        // Iterate through the list of shapes. For each one, call and display the GetColor() and GetArea() methods

        foreach (Shape shape in list)
        {
            Console.WriteLine(shape.GetColor());
            Console.WriteLine(shape.GetArea());
        }


    }
}

