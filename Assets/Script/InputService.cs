using UnityEngine;

public class InputService
{
    private readonly string HorizontalAxis = "Horizontal";
    private readonly string VerticalAxis = "Vertical";
    private readonly string MouseXInput = "Mouse X";
    private readonly string MouseYInput = "Mouse Y";

    public float MouseX { get; private set; }
    public float MouseY { get; private set; }
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }

    public InputService(string horizontalAxis = "Horizontal", string verticalAxis = "Vertical", string mouseXInput = "Mouse X", string mouseYInput = "Mouse Y")
    {
        HorizontalAxis = horizontalAxis;
        VerticalAxis = verticalAxis;
        MouseXInput = mouseXInput;
        MouseYInput = mouseYInput;
    }

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
