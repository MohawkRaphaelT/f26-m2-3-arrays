using System;
using System.Numerics;

namespace MohawkGame2D;

public class Eyeball
{
    Vector2 position;
    Color irisColor;
    float corneaRadius;
    float irisRadius;
    float pupilRadius;

    Color[] validEyeColors = [
            Color.Red,
            Color.Green,
            Color.Blue,
            new Color("aabbcc"),
        ];


    public void Setup()
    {
        // Get random position inside the window
        position = Random.Vector2(Window.Size);

        // Random eye color
        int randomColorIndex = Random.Integer(validEyeColors.Length);
        irisColor = validEyeColors[randomColorIndex];
        // Random size for eye
        corneaRadius = Random.Integer(50, 100 + 1);
        // Choose a random proportional size compared to the cornea
        irisRadius = Random.Float(0.5f, 0.7f) * corneaRadius;
        pupilRadius = Random.Float(0.3f, 0.4f) * corneaRadius;
    }

    public void Update()
    {
        // Calculate where the iris should be.
        // We want it ot point towards the mouse cursor.
        
        // Get the vector from eye (point a), to mouse (point b), b - a
        Vector2 eyeToMouse = Input.GetMousePosition() - position;
        // Get the direction to the mouse from the eye's position
        Vector2 direction = Vector2.Normalize(eyeToMouse);
        float distance = eyeToMouse.Length();

        // Maximum distance to move the iris before it touches the edge of the cornea
        float distanceToMoveIris = corneaRadius - irisRadius;

        // Where to position iris relative to cornea
        Vector2 irisCentre;
        
        // Check to see if mouse is inside eye
        bool isMouseOverEye = distance < distanceToMoveIris;
        if (isMouseOverEye == true)
        {
            // Position iris where the mouse cursor is
            irisCentre = eyeToMouse;
        }
        else
        {
            // Calculate where to position iris (and pupil) so that the edge of
            // the iris touches the edge of the cornea
            irisCentre = direction * distanceToMoveIris;
        }

        Draw.LineSize = 1;
        Draw.LineColor = Color.Black;
        // Cornea
        Draw.FillColor = Color.White;
        Draw.Circle(position, corneaRadius);
        // Iris
        Draw.FillColor = irisColor;
        Draw.Circle(position + irisCentre, irisRadius);
        // Pupil
        Draw.FillColor = Color.Black;
        Draw.Circle(position + irisCentre, pupilRadius);
    }
}
