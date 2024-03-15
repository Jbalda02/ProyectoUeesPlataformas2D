using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selfdestruct : MonoBehaviour
{
    public float destroyDelay;
    private IEnumerator _destroyAfterSeconds;

    void Update()
    {
        _destroyAfterSeconds = DestroyAfterSeconds(destroyDelay);
    }

    IEnumerator DestroyAfterSeconds(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
    
}
