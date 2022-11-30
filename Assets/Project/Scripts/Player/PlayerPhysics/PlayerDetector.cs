using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public bool _isGrounded { get; private set; }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Ground"))
            _isGrounded = true;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("Ground"))
            _isGrounded = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Ground"))
            _isGrounded = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Score"))
        {
            GameEvents._gameEvents.Add();
            GameEvents._gameEvents.AddOnText();
        }

    }
}
