using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponChange : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] Weapon[] weapons;
    public void Pistol(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (player.w.reloading) return;
            player.w.gameObject.SetActive(false);
            player.w = weapons[0];
            player.w.gameObject.SetActive(true);
        }
    }
    public void Rifle(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (player.w.reloading) return;
            player.w.gameObject.SetActive(false);
            player.w = weapons[1];
            player.w.gameObject.SetActive(true);
        }
    }
    public void Shotgun(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (player.w.reloading) return;
            player.w.gameObject.SetActive(false);
            player.w = weapons[3];
            player.w.gameObject.SetActive(true);
        }
    }
        public void Knife(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (player.w.reloading) return;
            player.w.gameObject.SetActive(false);
            player.w = weapons[2];
            player.w.gameObject.SetActive(true);
        }
    }
}
