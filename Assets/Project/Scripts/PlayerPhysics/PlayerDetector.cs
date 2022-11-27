using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public bool _isGrounded;
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
}
