using UnityEngine;

public class CameraInput
{
    private const string MouseXInput = "Mouse X";
    private const string MouseYInput = "Mouse Y";

    public float MouseX {  get; private set; }
    public float MouseY { get; private set; }

    public Vector2 GetMouseInput()
    {
        MouseX = Input.GetAxis(MouseXInput);
        MouseY = Input.GetAxis(MouseYInput);

        return new Vector2(MouseX, MouseY);
    }
}