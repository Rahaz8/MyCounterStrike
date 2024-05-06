using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class Bot : Entity
{
    public override int HP => 100;

    public override int ARMOR => 50;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] BOTweapon weapon;
    [SerializeField] Transform player;
    private void Update()
    {
        agent.destination = player.position;
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 50))
        {
            if (hit.collider.gameObject.TryGetComponent<Entity>(out Entity e))
            {
                if (e is Bot) return;
                weapon.Shoot();
            }
        }
            
    }

    public override void Die()
    {
        Destroy(gameObject);
    }
}
