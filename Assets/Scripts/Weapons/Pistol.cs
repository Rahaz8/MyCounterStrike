using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class Pistol : Weapon
{
    public override int MagSize => 12;

    protected override float ReloadTime => 1;

    protected override float Recoil => 0;

    protected override float Spread => 7;

    protected override int Damage => 30;

    protected override float Delay => 0.25f;

    public override void Launch()
    {
        source.Play();
        if (Physics.Raycast(Camera.main.transform.position, GetSpread(), out RaycastHit hit, 40))
        {
            if (hit.collider.gameObject.TryGetComponent<Entity>(out Entity e))
            {
                e.Damage(Damage);
                Instantiate(blood,hit.point,Quaternion.identity);
            }
            else
            {
                var dec = Instantiate(decal, hit.point, Quaternion.identity);
                dec.transform.rotation = Quaternion.LookRotation(-hit.normal);
                dec.transform.localPosition -= dec.transform.forward * 0.1f;
            }
        }
    }

    public override void Shoot(InputAction.CallbackContext shoot)
    {
        if (shoot.performed)
        {
            if (reloading) return;
            if (ammo == 0)
            {
                Reload();
                return;
            }
            if (!canShoot) return;
            ammo--;
            Launch();
            canShoot = false;
            StartCoroutine(AllowShoot());
        }
    }
}
