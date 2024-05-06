using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Despawn());
    }
    private IEnumerator Despawn() 
    { 
        yield return new WaitForSeconds(30);
        Destroy(gameObject);
    }
}
