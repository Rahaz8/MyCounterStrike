using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Knife : Weapon
{
    public override int MagSize => 1;

    protected override float ReloadTime => 0;

    protected override float Recoil => 0;

    protected override float Spread => 0;

    protected override int Damage => 59;

    protected override float Delay => 0;

    public override void Launch()
    {
        source.Play();
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 1f))
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
            Launch();
            animator.Play("Cut");
        }
    }
}
