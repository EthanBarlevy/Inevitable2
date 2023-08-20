using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePowerup : Powerup
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
			manager.AffectPlayer(0, -manager.GetData().ice_amount);
			//collision.gameObject.GetComponent<Player>().AddInvincibility(data.fire_time);
			//	collision.gameObject.GetComponent<TrailRenderer>().colorGradient;
			Destroy(gameObject);
	}

	
}
