using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public abstract int Hp { get; }
    public abstract int Armor { get; }
    public int hp;
    public int armor;
    [SerializeField] public AudioSource source;
    private void Start()
    {
        hp = Hp;
        armor = Armor;
    }
    public void Damage(int damage)
    {
        if (damage < armor)
        {
            armor -= damage;
            return;
        }
        if (armor != 0)
        {
            damage -= armor;
            hp -= damage;
            armor = 0;
        }
        else
        {
            hp -= damage;
            if (hp < 0)
            {
                hp = 0;
            }
        }
        if (hp <= 0)
        {
            Die();
        }
    }
    public abstract void Die();

}
