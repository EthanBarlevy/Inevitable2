using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : Damageable
{
    private Vector3 movement;
    private float rotation;
    private Manager manager;

    [Header("Value")]
    private int value;
    [SerializeField] private int min_value;
    [SerializeField] private int max_value;

    void Start()
    {
        movement = new Vector2(Random.value, Random.value);
        manager = FindObjectOfType<Manager>();
        rotation = Random.value;
        value = Random.Range(min_value, max_value);
    }
    
    void Update()
    {
        if (manager.game_state == Manager.GameState.GAMEPLAY)
        { 
            //transform.position += movement * Time.deltaTime;
        }
        transform.Rotate(new Vector3(0, 0, rotation / 3));
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (manager.GetPlayerNewtons() > newtons)
        {
            manager.AffectPlayer(speed, size);
            manager.AddRokxs(value);
            Destroy(gameObject);
        }
        else 
        {
            manager.StopPlayer();
        }
	}
}
