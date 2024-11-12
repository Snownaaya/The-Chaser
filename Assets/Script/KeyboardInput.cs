using UnityEngine;

public class KeyboardInput
{
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";

    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }

    public void UpdateInput()
    {
        Horizontal = Input.GetAxis(HorizontalAxis);
        Vertical = Input.GetAxis(VerticalAxis);
    }
}