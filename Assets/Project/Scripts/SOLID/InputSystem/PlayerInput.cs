using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public InputHandler _inputHandler;
    public float fuel { get; private set; }
    public void Initialize(float fuelAmount) => fuel = fuelAmount;
    public void Movement(float speed, Rigidbody rigidbody, Transform camPosition)
    {
        float horizontal = _inputHandler.GetAxisHorizontal();
        float vertical = _inputHandler.GetAxisVertical();
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camPosition.eulerAngles.y;
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rigidbody.AddForce(moveDir.normalized * speed);
        }
    }
    public void Jump(bool isGrounded, float jumpForce, Rigidbody rigidbody)
    {
        bool isJump = _inputHandler.GetJump();
        if (isJump && isGrounded)
            rigidbody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
    }
    public void Jetpack(bool isGrounded, Rigidbody rigidbody, float rechargeRate, float fuelAmount, float maxFuel, float boostStrength)
    {
        bool jetpack = _inputHandler.GetJetpackJump();
        if (jetpack && fuel > 0f)
        {
            rigidbody.AddForce(new Vector3(0, boostStrength, 0), ForceMode.Impulse);
            fuel -= Time.deltaTime;
        }
        else if (jetpack == false && isGrounded && fuel < maxFuel)
            fuel += rechargeRate * Time.deltaTime;
    }
}
