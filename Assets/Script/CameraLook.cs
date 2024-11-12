using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _camera;

    [SerializeField] private float _horizontalSensitivity;
    [SerializeField] private float _verticalSensitivity;

    private CameraInput _cameraInput;

    private float _cameraCurrentAngleX;

    private float _verticalMinAngle = -89f;
    private float _verticalMaxAngle = 89f;

    public float RotateDirection => _horizontalSensitivity * _cameraInput.MouseY;
    public Vector3 ForwardDirection { get; private set; }
    public Vector3 RightDirection { get; private set; }

    private void Awake()
    {
        _cameraCurrentAngleX = _camera.localEulerAngles.x;
        _cameraInput = new CameraInput();
    }

    private void Update()
    {
        _cameraInput.GetMouseInput();

        ForwardDirection = Vector3.ProjectOnPlane(_camera.forward, Vector3.up).normalized;
        RightDirection = Vector3.ProjectOnPlane(_camera.right, Vector3.up).normalized;

        _cameraCurrentAngleX += _cameraInput.MouseX * _verticalSensitivity;

        _cameraCurrentAngleX = Mathf.Clamp(_cameraCurrentAngleX, _verticalMinAngle, _verticalMaxAngle);

        _camera.localEulerAngles = Vector3.right * _cameraCurrentAngleX;
    }
}