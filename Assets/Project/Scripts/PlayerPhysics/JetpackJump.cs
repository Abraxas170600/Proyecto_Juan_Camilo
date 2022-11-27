using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackJump : MonoBehaviour
{
    public float fuel { get; private set; }
    public void Initialize(float fuelAmount) => fuel = fuelAmount;
    public void Jetpack(bool isGrounded, Rigidbody rigidbody, float rechargeRate, float fuelAmount, float maxFuel, float boostStrength, bool jetpack)
    {
        if (jetpack && fuel > 0f)
        {
            rigidbody.AddForce(new Vector3(0, boostStrength, 0), ForceMode.Impulse);
            fuel -= Time.deltaTime;
        }
        else if (jetpack == false && isGrounded && fuel < maxFuel)
            fuel += rechargeRate * Time.deltaTime;
    }
}
