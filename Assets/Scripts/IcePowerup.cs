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
		if (collision.tag == "Player")
		{
			//FindObjectOfType<Player>().AddInvincibility(data.fire_time);
			//collision.gameObject.GetComponent<Player>().AddInvincibility(data.fire_time);
			manager.AffectPlayer(-data.ice_amount, 0);
			//collision.gameObject.GetComponent<Player>().AddInvincibility(data.fire_time);
			//	collision.gameObject.GetComponent<TrailRenderer>().colorGradient;
			Destroy(gameObject);
		}
	}

	
}
