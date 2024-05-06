using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class M4A1 : Weapon
{
    public override int MagSize => 30;

    protected override float ReloadTime => 2;

    protected override float Recoil => 0;

    protected override float Spread => 6F;

    protected override int Damage => 34;

    protected override float Delay => 0.13f;

    public override void Launch()
    {
        source.Stop();
        source.Play();
        if (Physics.Raycast(Camera.main.transform.position, GetSpread(), out RaycastHit hit, 50))
        {
            if (hit.collider.gameObject.TryGetComponent<Entity>(out Entity e))
            {
                e.Damage(Damage);
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
            StartCoroutine("Auto");
        }
        else if (shoot.canceled) 
        {
            StopCoroutine("Auto");
        }
    }
    private IEnumerator Auto()
    {
        while (ammo != 0) 
        {
            ammo--;
            Launch();
            yield return new WaitForSeconds(Delay);
        }
    }
}
