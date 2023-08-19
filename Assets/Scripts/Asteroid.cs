using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Vector3 movement;
    private float rotation;
    [SerializeField] private Manager manager;

    [Header("Value")]
    private int value;
    [SerializeField] private int min_value;
    [SerializeField] private int max_value;

    void Start()
    {
        movement = new Vector2(Random.value, Random.value);
        rotation = Random.value;
        value = Random.Range(min_value, max_value);
    }
    
    void Update()
    {
        transform.position += movement * Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, rotation));
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        manager.AddRokxs(value);
        Destroy(gameObject);
	}
}
