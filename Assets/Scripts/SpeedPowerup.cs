using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerup : Powerup
{
	//GameObject self;
	public Manager manager;

	void Start()
	{
		//self = gameObject;

		manager = FindObjectOfType<Manager>(); //find manager
	}
	public void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			//FindObjectOfType<Player>().AddInvincibility(data.fire_time);
			//collision.gameObject.GetComponent<Player>().AddInvincibility(data.fire_time);
			manager.AffectPlayer(0, -data.boost_speed);
			//collision.gameObject.GetComponent<Player>().AddInvincibility(data.fire_time);
			//	collision.gameObject.GetComponent<TrailRenderer>().colorGradient;
			Destroy(gameObject);
		}
	}

	
}
