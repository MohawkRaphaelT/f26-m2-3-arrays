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
        // Random size for eye
        radius = Random.Integer(5, 50 + 1);
        // Random look direction
        angle = Random.AngleRadians();
    }

    public void Update()
    {
        // Update look angle
        // Move eye around circle once per second
        angle += MathF.Tau * Time.DeltaTime / 5; // once every 5 seconds

        // Calculate look direction using angle
        float directionX = MathF.Cos(angle);
        float directionY = MathF.Sin(angle);
        // Iris and pupil position
        float positionX = directionX * radius / 2f;
        float positionY = directionY * radius / 2f;

        Draw.LineSize = 1;
        Draw.LineColor = Color.Black;
        // Cornea
        Draw.FillColor = Color.White;
        Draw.Circle(x, y, radius);
        // Iris
        Draw.FillColor = irisColor;
        Draw.Circle(x + positionX, y + positionY, radius * 0.5f);
        // Pupil
        Draw.FillColor = Color.Black;
        Draw.Circle(x + positionX, y + positionY, radius * 0.3f);
    }
}
