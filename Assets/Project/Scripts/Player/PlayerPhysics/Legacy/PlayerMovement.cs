using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public void UpdateMovement(float speed, Rigidbody rigidbody, Transform camPosition, float horizontal, float vertical)
    //{
    //    Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
    //    if (direction.magnitude >= 0.1f)
    //    {
    //        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camPosition.eulerAngles.y;
    //        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
    //        rigidbody.AddForce(moveDir.normalized * speed);
    //    }
    //}
    //public void Jump(bool isGrounded, float jumpForce, Rigidbody rigidbody, bool isJump)
    //{
    //    if (isJump && isGrounded)
    //        rigidbody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
    //}
}
