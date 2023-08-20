using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDelete : MonoBehaviour
{
    [SerializeField] float lifetime;

    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        { 
            Destroy(gameObject);
        }
    }
}
