using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Screen : MonoBehaviour
{
	[SerializeField] GameObject[] spawn_locations;
	[SerializeField] GameObject[] powerups;

	private void Start()
	{
		GameData data = FindObjectOfType<Manager>().GetData();
		bool spawn_speed = Random.value < data.boost_frequency;
		bool spawn_fire = Random.value < data.fire_frequency;
		bool spawn_ice = Random.value < data.ice_frequency;
		List<KeyValuePair<bool, int>> spawn = new List<KeyValuePair<bool, int>>();

		if(spawn_speed) 
		{ 
			spawn.Add(new KeyValuePair<bool, int>(spawn_speed, 1));
		}
		if (spawn_fire)
		{
			spawn.Add(new KeyValuePair<bool, int>(spawn_fire, 2));
		}
		if (spawn_ice)
		{
			spawn.Add(new KeyValuePair<bool, int>(spawn_ice, 3));
		}

		if (spawn.Count > 0)
		{
			switch (spawn[Random.Range(0, spawn.Count - 1)].Value)
			{
				case 1:
					Instantiate(powerups[0], spawn_locations[Random.Range(0, spawn_locations.Length)].transform.position, transform.rotation, transform);
					break;
				case 2:
					Instantiate(powerups[1], spawn_locations[Random.Range(0, spawn_locations.Length)].transform.position, transform.rotation, transform);
					break;
				case 3:
					Instantiate(powerups[2], spawn_locations[Random.Range(0, spawn_locations.Length)].transform.position, transform.rotation, transform);
					break;
			}
		}
	}
}
