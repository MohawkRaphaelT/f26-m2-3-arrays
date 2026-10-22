using System;
using System.Numerics;

namespace MohawkGame2D;

public class Eyeball
{
    float x;
    float y;
    Color irisColor;
    float radius;
    float angle;

    public void Setup()
    {
        // Get random position inside the window
        x = Random.Integer(Window.Width);
        y = Random.Integer(Window.Height);
        // Random eye color
        irisColor = Random.Color();
    }

    public void Update()
    {
        Draw.LineSize = 1;
        Draw.LineColor = Color.Black;
        // Cornea
        Draw.FillColor = Color.White;
        Draw.Circle(x, y, 50);
        // Iris
        Draw.FillColor = irisColor;
        Draw.Circle(x, y, 25);
        // Pupil
        Draw.FillColor = Color.Black;
        Draw.Circle(x, y, 15);
    }
}
