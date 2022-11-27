using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _horizontal;
    private float _vertical;
    private bool _isJump = false;

    void Update()
    {
        ProcessInputs();
    }
    private void ProcessInputs()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        _isJump = Input.GetButtonDown("Jump");
    }
    public void UpdateMovement(float speed, Rigidbody rigidbody, Transform camPosition)
    {
        Vector3 direction = new Vector3(_horizontal, 0f, _vertical).normalized;
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camPosition.eulerAngles.y;
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rigidbody.AddForce(moveDir.normalized * speed);
        }
    }
    public void Jump(bool isGrounded, float jumpForce, Rigidbody rigidbody)
    {
        if (_isJump && isGrounded)
        {
            rigidbody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }
}
