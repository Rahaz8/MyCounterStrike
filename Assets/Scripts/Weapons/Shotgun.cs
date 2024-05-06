using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class Shotgun : Weapon
{
    public override int MagSize => 5;

    protected override float ReloadTime => 2;

    protected override float Recoil => 0;

    protected override float Spread => 7;

    protected override int Damage => 18;
    protected int shots => 6;

    protected override float Delay => 0.5f;

    public override void Launch()
    {
        source.Play();
        for (int i = 0; i < shots; i++)
        {
            if (Physics.Raycast(Camera.main.transform.position, GetSpread(), out RaycastHit hit, 18))
            {
                if (hit.collider.gameObject.TryGetComponent<Entity>(out Entity e))
                {
                    int damage = 0;
                    float distance = Vector3.Distance(Camera.main.transform.position, hit.point);
                    if (distance <= 1)
                        damage = Damage;
                    else if (distance >= 17) damage = 5;
                    else
                    {
                        damage = (int)Mathf.Lerp(Damage, 5, Mathf.Clamp01(distance / 17));
                    }
                    e.Damage(damage);
                    Instantiate(blood, hit.point, Quaternion.identity);
                }
                else
                {
                    var dec = Instantiate(decal, hit.point, Quaternion.identity);
                    dec.transform.rotation = Quaternion.LookRotation(-hit.normal);
                    dec.transform.localPosition -= dec.transform.forward * 0.1f;
                }
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
