using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Vector3 movement;

    void Start()
    {
        movement = new Vector2(Random.value, Random.value);
    }

    
    void Update()
    {
        transform.position += movement * Time.deltaTime;
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        Destroy(gameObject);
	}
}
