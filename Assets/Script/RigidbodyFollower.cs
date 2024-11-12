using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Chaser : MonoBehaviour
{
    [SerializeField] private Movement _target;

    [SerializeField] private float _speed;
    [SerializeField] private float _stopDistance;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Chase();
    }

    public void Chase()
    {
        Vector3 direction = (_target.transform.position - transform.position).normalized;
        float distance = Vector3.Distance(_target.transform.position, transform.position);

        if (distance > _stopDistance)
            _rigidbody.MovePosition(transform.position + direction * _speed * Time.fixedDeltaTime);
        else
            _rigidbody.velocity = Vector3.zero;
    }
}