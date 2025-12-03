using System.Runtime.InteropServices;

public class Shape
{
    private string _color;

    public Shape(string color)
    {
        _color = color;

    }

    public virtual double GetArea()
    {
        return 0;
    }

    public string GetColor()
    {
        return _color;
    }

    public void SetColor(string color)
    {
        _color = color;
    }
}