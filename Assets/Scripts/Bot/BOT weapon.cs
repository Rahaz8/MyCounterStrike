using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public abstract class BOTweapon : MonoBehaviour
{
    protected abstract int Damage { get; }
    protected abstract int Magsize { get; }
    protected abstract int Spread { get; }
    protected abstract float Delay { get; }
    [SerializeField] protected Transform bot;
    protected abstract float ReloadTime { get; }
    [SerializeField] protected GameObject blood, decal;
    [SerializeField] protected AudioSource source;
    protected bool canshoot = true;
    protected int ammo;
    private void Start()
    {
        ammo = Magsize;
    }
    public abstract void Shoot();
    protected Vector3 GetSpread()
    {
        
        float s1 = Random.Range(-Spread, Spread);
        float l = s1 * s1;
        float l2 = (float)System.Math.Sqrt(Spread * Spread - l);
        float s2 = Random.Range(-l2, l2);
        var y = Quaternion.AngleAxis(s1, bot.right);
        var x = Quaternion.AngleAxis(s2, bot.up);
        return y * x * bot.forward;
    }
    protected IEnumerator Allow()
    {
        yield return new WaitForSeconds(Delay);
        canshoot = true;
    }
    protected IEnumerator Reload()
    {
        yield return new WaitForSeconds(ReloadTime);
        canshoot = true;
        ammo = Magsize;
    }
}
