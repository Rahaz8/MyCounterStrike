
using UnityEngine;
public class BotShotgun : BotWeapon
{
    protected override int Damage => 15;

    protected override int Spread => 7;

    protected override float Delay => 0.5F;
    protected int shots => 6;

    protected override int MagSize => 6;

    protected override float ReloadTime => 2;

    public  override void Shoot()
    {
        if (!canshoot) return;
        if (ammo == 0)
        {
            canshoot = false;
            StartCoroutine(Reload());
            return;
        }
        ammo--;
        source.Play();
        for (int i = 0; i < shots; i++)
        {
            if (Physics.Raycast(bot.position, GetSpread(), out RaycastHit hit, 50))
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
        canshoot = false;
        StartCoroutine(Allow());
    }
}
