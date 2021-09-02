using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public void ReactToHit()
    {
        WanderingAI behaviour = GetComponent<WanderingAI>();
        if (behaviour != null)
        {
            behaviour.SetAlive(false);
        }
        StartCoroutine(Die());
    }
    IEnumerator Die()
    {
        transform.Rotate(-75, 0, 0);
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
