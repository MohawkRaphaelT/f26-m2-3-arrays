using System;
using System.Numerics;

namespace MohawkGame2D;

public class Eyeball
{
    Vector2 position;
    Color irisColor;
    float radius;
    Vector2 irisOffset;

    public void Setup()
    {
        // Get random position inside the window
        position = Random.Vector2(Window.Size);

        // Random eye color
        irisColor = Random.Color();
        // Random size for eye
        radius = Random.Integer(5, 50 + 1);
        // Random look direction
        irisOffset = Random.PointOnCircle() * radius / 2;
    }

    public void Update()
    {
        Draw.LineSize = 1;
        Draw.LineColor = Color.Black;
        // Cornea
        Draw.FillColor = Color.White;
        Draw.Circle(position, radius);
        // Iris
        Draw.FillColor = irisColor;
        Draw.Circle(position + irisOffset, radius * 0.5f);
        // Pupil
        Draw.FillColor = Color.Black;
        Draw.Circle(position + irisOffset, radius * 0.3f);
    }
}
