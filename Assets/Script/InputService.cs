using UnityEngine;

public class InputService
{
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";
    private const string MouseXInput = "Mouse X";
    private const string MouseYInput = "Mouse Y";

    public float MouseX { get; private set; }
    public float MouseY { get; private set; }
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }

    public void UpdateInput()
    {
        Horizontal = Input.GetAxis(HorizontalAxis);
        Vertical = Input.GetAxis(VerticalAxis);
    }

    public Vector2 GetDirection()
    {
        MouseX = Input.GetAxis(MouseXInput);
        MouseY = Input.GetAxis(MouseYInput);

        return new Vector2(MouseX, MouseY);
    }
}
