using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterControllerMover : MonoBehaviour
{
    [SerializeField] private CameraFollow _cameraFollow;
    [SerializeField] private float _speed;
    [SerializeField] private float _stafeSpeed;

    private CharacterController _characterController;
    private InputService _playerInput;

    private void Awake()
    {
        _playerInput = new InputService();
        _characterController = GetComponent<CharacterController>();
    }

    private void OnValidate()
    {
        if(_cameraFollow == null)
            throw new ArgumentNullException(nameof(_cameraFollow));

        if (_speed <= 0)
            throw new ArgumentOutOfRangeException(nameof(_speed));

        if(_stafeSpeed <= 0)
            throw new ArgumentOutOfRangeException(nameof(_stafeSpeed));
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _playerInput.UpdateInput();

        Vector3 forward = _cameraFollow.ForwardDirection * _playerInput.Vertical;
        Vector3 right = _cameraFollow.RightDirection * _playerInput.Horizontal;

        Vector3 direction = (forward + right).normalized;
        Vector3 velocity = direction * Time.deltaTime * _speed * _stafeSpeed;

        transform.Rotate(Vector3.forward * _cameraFollow.RotateDirection);

        if (_characterController.isGrounded)
            _characterController.Move(velocity + Vector3.down);
        else
            _characterController.Move(velocity + Physics.gravity * Time.deltaTime);
    }
}