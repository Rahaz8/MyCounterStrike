using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public  abstract class Weapon : MonoBehaviour
{
    public abstract int MagSize { get; }
    protected abstract float ReloadTime { get; }
    protected abstract float Recoil { get; }
    protected abstract float Spread { get; }
    protected abstract int Damage { get; }
    protected abstract float Delay {  get; }
    public int ammo;
    public bool reloading,canShoot = true;
    [SerializeField] protected Animator animator;
    [SerializeField] protected AudioSource source;
    [SerializeField] public Sprite sprite;
    [SerializeField] protected GameObject decal,blood;
    [SerializeField] PlayerController player;
    private void Start()
    {
        ammo = MagSize;
    }
    public abstract void Shoot(InputAction.CallbackContext shoot);
    public abstract void Launch();
    public void Reload()
    {
        if (reloading) return;
        if (ammo == MagSize) return;
        reloading = true;
        animator.Play("Reload");
        StartCoroutine(EndReload());
    }
    private IEnumerator EndReload()
    {
        yield return new WaitForSeconds(ReloadTime);
        reloading = false;
        ammo = MagSize;
    }
    protected IEnumerator AllowShoot()
    {
        yield return new WaitForSeconds(Delay);
        canShoot = true;
    }
    protected Vector3 GetSpread()
    {
        Camera cam = Camera.main;
        float spread = Spread;
        if (player.walk && !player.crouch) spread *= 2;
        if (player.crouch && !player.walk) spread /= 2;
        float s1 =Random.Range(-spread,spread);
        float l = s1 * s1;
        float l2 = (float) System.Math.Sqrt(spread * spread - l);
        float s2 = Random.Range(-l2, l2);
        var y = Quaternion.AngleAxis(s1, cam.transform.right);
        var x = Quaternion.AngleAxis(s2, cam.transform.up);
        return y * x * cam.transform.forward;
    }
}
