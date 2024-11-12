using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    [SerializeField] private CameraFollow _cameraFollow;
    [SerializeField] private float _speed;
    [SerializeField] private float _stafeSpeed;

    private CharacterController _characterController;
    private KeyboardInput _playerInput;

    private void Awake()
    {
        _playerInput = new KeyboardInput();
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _playerInput.UpdateInput();

        Vector3 forward = _cameraFollow.ForwardDirection * _playerInput.Vertical;
        Vector3 right = _cameraFollow.RightDirection * _playerInput.Horizontal;

        Vector3 direction = (forward + right).normalized * _speed * _stafeSpeed;
        direction *= Time.deltaTime;

        transform.Rotate(Vector3.forward * _cameraFollow.RotateDirection);

        if (_characterController.isGrounded)
            _characterController.Move(direction + Vector3.down);
        else
            _characterController.Move(direction + Physics.gravity * Time.deltaTime);
    }
}