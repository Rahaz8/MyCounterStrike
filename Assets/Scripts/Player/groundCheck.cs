using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] PlayerController controller;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) return;
        controller.onground = true;
    }
}
