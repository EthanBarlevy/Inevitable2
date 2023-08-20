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
			//FindObjectOfType<Player>().AddInvincibility(data.fire_time);
			//collision.gameObject.GetComponent<Player>().AddInvincibility(data.fire_time);
 			manager.AffectPlayer(-manager.GetData().boost_speed, 0);
			//collision.gameObject.GetComponent<Player>().AddInvincibility(data.fire_time);
			//	collision.gameObject.GetComponent<TrailRenderer>().colorGradient;
			Destroy(gameObject);
	}

	
}
