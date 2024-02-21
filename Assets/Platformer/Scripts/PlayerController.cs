using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float _acceleration;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _jumpImpulse;
    [SerializeField] private float _jumpBoost;

    private bool _isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float horizMovement = Input.GetAxis("Horizontal");

        rb.velocity += Vector3.right * (horizMovement * Time.deltaTime * _acceleration);

        // Jump Check
        Collider col = GetComponent<Collider>();
        float halfHeight = col.bounds.extents.y + 0.03f;

        Vector3 startPoint = transform.position;
        Vector3 endPoint = startPoint + (Vector3.down * halfHeight);

        _isGrounded = Physics.Raycast(startPoint, Vector3.down, 2f);

        Color lineColor = _isGrounded ? Color.red : Color.blue;
        Debug.DrawLine(startPoint, endPoint, lineColor, 0f, false);

        if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
                rb.AddForce(Vector3.up * _jumpImpulse, ForceMode.Impulse);
        }
        else if(!_isGrounded && Input.GetKey(KeyCode.Space))
        {
            if(rb.velocity.y > 0)
            {
               rb.AddForce(Vector3.up * _jumpBoost, ForceMode.Force);
            }
        }

        // Speed Regulation

        if(Mathf.Abs(rb.velocity.x) > _maxSpeed)
        {
            Vector3 newVelocity = rb.velocity;
            newVelocity.x = Mathf.Clamp(newVelocity.x, -_maxSpeed, _maxSpeed);
            rb.velocity = newVelocity;
        }

        // Turning Speed Regulation

        if (Mathf.Abs(horizMovement) < 0.5f)
        {
            Vector3 newVel = rb.velocity;
            newVel.x *= 1f - Time.deltaTime;
            rb.velocity = newVel;
        }

        float yaw = (rb.velocity.x > 0) ? 90 : -90;
        transform.rotation = Quaternion.Euler(0f, yaw, 0f);
    }
}
