using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : Damageable
{
	private Manager manager;

	void Start()
	{
		manager = FindObjectOfType<Manager>();
		value = Random.Range(min_value, max_value);
	}

	private void Update()
	{
		
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
			manager.StopPlayerPlanet();
		}
	}
}
