using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Woosh : MonoBehaviour
{
    float ypos;
    // Start is called before the first frame update
    void Start()
    {
        ypos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, ypos, transform.position.z);
    }
}
